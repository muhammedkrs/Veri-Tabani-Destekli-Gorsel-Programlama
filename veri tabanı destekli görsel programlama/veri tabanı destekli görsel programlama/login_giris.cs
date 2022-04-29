using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace veri_tabanı_destekli_görsel_programlama
{
    public partial class login_giris : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
      
        SqlDataReader dr;
        SqlCommand cmd;
        DataSet ds;
        public static string sqlcon = @"Data Source=MONSTER-MUHAMME\SQLEXPRESS;Initial Catalog=görsel programlama sql;Integrated Security=True";
        public login_giris()
        {
            InitializeComponent();

        }
        public int deneme_sayisi = 0;
        public static string kullanicimSession = "";

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        

        private void login_giris_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(VeriTabani.Login_kontrol(textBox1.Text, textBox2.Text))//giriş başarılıysa
            {
                MessageBox.Show("Giriş Başarılı...");
                this.Hide();//login ekranını gizle
                kullanicimSession = textBox1.Text;
                Form1 a = new Form1();//form 1 sınıfından nesne
                a.Show(); //form 1 i aç
                
            }
            else
            {
                deneme_sayisi++;
                MessageBox.Show("Hatalı giriş yaptınız!");
                if(deneme_sayisi==3)
                {
                    MessageBox.Show("3 defa hatalı giriş yaptığınız için program kapanıyor...");
                    Application.Exit();
                }

            }

        }
    }
}
