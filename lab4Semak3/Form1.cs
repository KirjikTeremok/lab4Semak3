using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4Semak3
{
    public partial class Form1 : Form //  сервер
    {
        private int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        class JsonCommand
        {
            [JsonPropertyName("A")]
            public string A { get; set; }
            [JsonPropertyName("B")]
            public string B { get; set; }
            [JsonPropertyName("C")]
            public string C { get; set; }

            [JsonPropertyName("D")]
            public string D { get; set; }
            [JsonPropertyName("E")]
            public string E { get; set; }
            [JsonPropertyName("F")]
            public string F { get; set; }
        }

        volatile HttpListener listener;
        

        private void startButton_Click(object sender, EventArgs e)
        {
            try
            {
                timerRAB.Enabled = true;
                listener = new HttpListener();
                listener.Prefixes.Clear();
                listener.Prefixes.Add("http://" + IPTextBox.Text + ":" + PortTextBox.Text + "/");
                listener.Start();
                listBox1.Items.Add("Ожидание подключения");
                IPTextBox.Enabled = false;
                PortTextBox.Enabled = false;

            }
            catch { MessageBox.Show("IP или порт введены неверно"); }

          
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            timerRAB.Enabled = false;
            listBox1.Items.Add("Сервер остановлен");
            listener?.Close();
            IPTextBox.Enabled = true;
            PortTextBox.Enabled = true;
        }

        volatile static string D_;
        volatile static string E_;
        volatile static string F_;
        volatile static string cjson;

        private async void timerRAB_Tick(object sender, EventArgs e)
        {
            HttpListenerContext context;
            HttpListenerRequest request;
            HttpListenerResponse response;

            await Task.Run(() =>
            {
                try
                {
                    context = listener.GetContext();
                    request = context.Request;
                    response = context.Response;

                    //получения строки от клиента
                    string text;
                    using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
                    {
                        text = reader.ReadToEnd();
                    }

                    if (text.Trim() != "")
                    {
                        this.Invoke(new Action(() =>
                        {
                            Form1.D_ = Convert.ToBase64String(Encoding.UTF8.GetBytes(textBox7.Text));
                            Form1.E_ = Convert.ToBase64String(Encoding.UTF8.GetBytes(textBox6.Text));
                            Form1.F_ = Convert.ToBase64String(Encoding.UTF8.GetBytes(textBox8.Text));

                            JsonCommand c = new JsonCommand() {D = Form1.D_, E = Form1.E_, F = Form1.F_};
                            cjson = JsonSerializer.Serialize<JsonCommand>(c);

                            listBox1.Items.Add("Клиент: " + text);
                            listBox1.Items.Add("Ответ: " + Form1.cjson);

                            JsonCommand jc = new JsonCommand();
                            jc = JsonSerializer.Deserialize<JsonCommand>(text);
                            textBox3.Text = Encoding.ASCII.GetString(Convert.FromBase64String(jc.A));
                            textBox4.Text = Encoding.ASCII.GetString(Convert.FromBase64String(jc.B));
                            textBox5.Text = Encoding.ASCII.GetString(Convert.FromBase64String(jc.C));
                            count++;
                            
                        }));
                    }

                    string responseString = cjson;
                    byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                    Stream output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    output.Close();
                }
                catch
                {
                    // ignored
                }
            });

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IPTextBox.Text = "127.0.0.1";

            this.listBox1.DrawMode = DrawMode.OwnerDrawVariable;
            this.listBox1.MeasureItem += lst_MeasureItem;
            this.listBox1.DrawItem += lst_DrawItem;
        }
        private void lst_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(listBox1.Items[e.Index].ToString(), listBox1.Font, listBox1.Width).Height;
        }
        
        private void lst_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            listener.Close();

        }
        
    }
}