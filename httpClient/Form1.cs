using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace httpServer
{
    public partial class Form1 : Form // клиент
    {
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

        private async void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (IPAddress.TryParse(IPTextBox.Text, out IPAddress s))
                    await PostAndRead(textBox2.Text, textBox3.Text, textBox4.Text, listBox1, IPTextBox.Text,
                        PortTextBox.Text,textBox5, textBox6, textBox7);
                else
                    MessageBox.Show("Неправильно введен IP");
            }
            catch
            {
                listBox1.Items.Add(" ");
                listBox1.Items.Add("Произошла ошибка при отправке запроса");
                listBox1.Items.Add(" ");
            }

            }

        static async Task PostAndRead(string A_, string B_, string C_, ListBox lb, string ip,
            string port, TextBox d, TextBox e, TextBox f)
        {
            string A = Convert.ToBase64String(Encoding.UTF8.GetBytes(A_));
            string B = Convert.ToBase64String(Encoding.UTF8.GetBytes(B_));
            string C = Convert.ToBase64String(Encoding.UTF8.GetBytes(C_));

            JsonCommand c1 = new JsonCommand() { A = A, B = B, C = C };
            string c1json = JsonSerializer.Serialize<JsonCommand>(c1);
            string url = "http://" + ip + ":" + port + "/";
            var client = new HttpClient();
            // отправвляем
            var response = await client.PostAsync(url, new StringContent(c1json, Encoding.UTF8));
            lb.Items.Add("Отправлено: " + c1json);
            // получаем ответ
            var content = await client.GetStringAsync(url);
            lb.Items.Add("Сервер: " + content);
            //разложение строки с сервера
            JsonCommand cs = new JsonCommand();
            cs = JsonSerializer.Deserialize<JsonCommand>(content);
            d.Text = Encoding.ASCII.GetString(Convert.FromBase64String(cs.D)); 
            e.Text = Encoding.ASCII.GetString(Convert.FromBase64String(cs.E));
            f.Text = Encoding.ASCII.GetString(Convert.FromBase64String(cs.F));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IPTextBox.Text = "127.0.0.1";

            this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
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


        private void PortTextBox_TextChanged(object sender, EventArgs e)
        {
            if (PortTextBox.Text.Trim() != "")
                if ((int.TryParse(PortTextBox.Text, out var xe) == false))
                {
                    MessageBox.Show("Значение порта может представлять собой только число");
                    PortTextBox.Text = PortTextBox.Text.Remove(PortTextBox.Text.Length - 1);
                }

        }
    }
}
