using System.Security.AccessControl;

namespace lab4Semak3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.startButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.IPTextBox = new System.Windows.Forms.TextBox();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.timerRAB = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(663, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(109, 57);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "вкл";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(663, 92);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(108, 61);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "выкл";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // IPTextBox
            // 
            this.IPTextBox.Location = new System.Drawing.Point(18, 19);
            this.IPTextBox.Name = "IPTextBox";
            this.IPTextBox.Size = new System.Drawing.Size(69, 20);
            this.IPTextBox.TabIndex = 2;
            // 
            // PortTextBox
            // 
            this.PortTextBox.Location = new System.Drawing.Point(113, 19);
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(82, 20);
            this.PortTextBox.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(18, 123);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(82, 20);
            this.textBox3.TabIndex = 4;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(131, 123);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(91, 20);
            this.textBox4.TabIndex = 5;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(256, 125);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(86, 20);
            this.textBox5.TabIndex = 6;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(131, 177);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(79, 20);
            this.textBox6.TabIndex = 7;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(18, 177);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(82, 20);
            this.textBox7.TabIndex = 7;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(256, 177);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(86, 20);
            this.textBox8.TabIndex = 7;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(25, 229);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(461, 199);
            this.listBox1.TabIndex = 8;
            // 
            // timerRAB
            // 
            this.timerRAB.Enabled = true;
            this.timerRAB.Tick += new System.EventHandler(this.timerRAB_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.PortTextBox);
            this.Controls.Add(this.IPTextBox);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.startButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Timer timerRAB;

        private System.Windows.Forms.TextBox IPTextBox;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox PortTextBox;

        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;

        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;

        private System.Windows.Forms.Button exitButton;

        private System.Windows.Forms.Button startButton;

        #endregion
    }
}