﻿
namespace veri_tabanı_destekli_görsel_programlama
{
    partial class SifreDegistir
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
            this.textBox_EskiSifre = new System.Windows.Forms.TextBox();
            this.textBox_YeniSifre = new System.Windows.Forms.TextBox();
            this.textBox_YeniSifreOnay = new System.Windows.Forms.TextBox();
            this.textBox_Captcha = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_captcha = new System.Windows.Forms.Label();
            this.label_mesaj = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_EskiSifre
            // 
            this.textBox_EskiSifre.Location = new System.Drawing.Point(152, 42);
            this.textBox_EskiSifre.Name = "textBox_EskiSifre";
            this.textBox_EskiSifre.Size = new System.Drawing.Size(100, 22);
            this.textBox_EskiSifre.TabIndex = 0;
            // 
            // textBox_YeniSifre
            // 
            this.textBox_YeniSifre.Location = new System.Drawing.Point(152, 89);
            this.textBox_YeniSifre.Name = "textBox_YeniSifre";
            this.textBox_YeniSifre.Size = new System.Drawing.Size(100, 22);
            this.textBox_YeniSifre.TabIndex = 1;
            // 
            // textBox_YeniSifreOnay
            // 
            this.textBox_YeniSifreOnay.Location = new System.Drawing.Point(152, 136);
            this.textBox_YeniSifreOnay.Name = "textBox_YeniSifreOnay";
            this.textBox_YeniSifreOnay.Size = new System.Drawing.Size(100, 22);
            this.textBox_YeniSifreOnay.TabIndex = 2;
            // 
            // textBox_Captcha
            // 
            this.textBox_Captcha.Location = new System.Drawing.Point(224, 185);
            this.textBox_Captcha.Name = "textBox_Captcha";
            this.textBox_Captcha.Size = new System.Drawing.Size(51, 22);
            this.textBox_Captcha.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(190, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "Sifre Degistir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Eski Şifre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Yeni Şifre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Yeni Şifre (Tekrar)";
            // 
            // label_captcha
            // 
            this.label_captcha.AutoSize = true;
            this.label_captcha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_captcha.Location = new System.Drawing.Point(12, 185);
            this.label_captcha.Name = "label_captcha";
            this.label_captcha.Size = new System.Drawing.Size(191, 25);
            this.label_captcha.TabIndex = 8;
            this.label_captcha.Text = "Yeni Şifre (Tekrar)";
            // 
            // label_mesaj
            // 
            this.label_mesaj.AutoSize = true;
            this.label_mesaj.Location = new System.Drawing.Point(14, 241);
            this.label_mesaj.Name = "label_mesaj";
            this.label_mesaj.Size = new System.Drawing.Size(67, 17);
            this.label_mesaj.TabIndex = 9;
            this.label_mesaj.Text = "Eski Şifre";
            this.label_mesaj.Click += new System.EventHandler(this.label5_Click);
            // 
            // SifreDegistir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_mesaj);
            this.Controls.Add(this.label_captcha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_Captcha);
            this.Controls.Add(this.textBox_YeniSifreOnay);
            this.Controls.Add(this.textBox_YeniSifre);
            this.Controls.Add(this.textBox_EskiSifre);
            this.Name = "SifreDegistir";
            this.Text = " Şifre Değiştir";
            this.Load += new System.EventHandler(this.SifreDegistir_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_EskiSifre;
        private System.Windows.Forms.TextBox textBox_YeniSifre;
        private System.Windows.Forms.TextBox textBox_YeniSifreOnay;
        private System.Windows.Forms.TextBox textBox_Captcha;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_captcha;
        private System.Windows.Forms.Label label_mesaj;
    }
}