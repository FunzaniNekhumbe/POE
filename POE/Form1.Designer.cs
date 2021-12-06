
namespace POE
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.leftbtn = new System.Windows.Forms.Button();
            this.rightbtn = new System.Windows.Forms.Button();
            this.downbtn = new System.Windows.Forms.Button();
            this.upbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnbuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(962, 519);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(94, 19);
            this.radioButton1.TabIndex = 13;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(962, 322);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(211, 144);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = "";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(962, 63);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(211, 184);
            this.listBox1.TabIndex = 11;
            // 
            // leftbtn
            // 
            this.leftbtn.Location = new System.Drawing.Point(83, 625);
            this.leftbtn.Name = "leftbtn";
            this.leftbtn.Size = new System.Drawing.Size(75, 23);
            this.leftbtn.TabIndex = 8;
            this.leftbtn.Text = "LEFT";
            this.leftbtn.UseVisualStyleBackColor = true;
            // 
            // rightbtn
            // 
            this.rightbtn.Location = new System.Drawing.Point(293, 625);
            this.rightbtn.Name = "rightbtn";
            this.rightbtn.Size = new System.Drawing.Size(75, 23);
            this.rightbtn.TabIndex = 9;
            this.rightbtn.Text = "RIGHT";
            this.rightbtn.UseVisualStyleBackColor = true;
            // 
            // downbtn
            // 
            this.downbtn.Location = new System.Drawing.Point(178, 683);
            this.downbtn.Name = "downbtn";
            this.downbtn.Size = new System.Drawing.Size(75, 23);
            this.downbtn.TabIndex = 10;
            this.downbtn.Text = "DOWN";
            this.downbtn.UseVisualStyleBackColor = true;
            // 
            // upbtn
            // 
            this.upbtn.Location = new System.Drawing.Point(178, 562);
            this.upbtn.Name = "upbtn";
            this.upbtn.Size = new System.Drawing.Size(75, 23);
            this.upbtn.TabIndex = 7;
            this.upbtn.Text = "UP";
            this.upbtn.UseVisualStyleBackColor = true;
            this.upbtn.Click += new System.EventHandler(this.upbtn_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnbuy
            // 
            this.btnbuy.Location = new System.Drawing.Point(604, 683);
            this.btnbuy.Name = "btnbuy";
            this.btnbuy.Size = new System.Drawing.Size(75, 23);
            this.btnbuy.TabIndex = 14;
            this.btnbuy.Text = "Buy";
            this.btnbuy.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 768);
            this.Controls.Add(this.btnbuy);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.leftbtn);
            this.Controls.Add(this.rightbtn);
            this.Controls.Add(this.downbtn);
            this.Controls.Add(this.upbtn);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button leftbtn;
        private System.Windows.Forms.Button rightbtn;
        private System.Windows.Forms.Button downbtn;
        private System.Windows.Forms.Button upbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnbuy;
    }
}

