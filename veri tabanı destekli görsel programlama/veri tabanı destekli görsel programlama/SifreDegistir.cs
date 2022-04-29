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
    public partial class SifreDegistir : Form
    {
         SqlConnection con;
         SqlDataAdapter da;
         SqlDataReader dr;
         SqlCommand cmd;
        public static string sqlcon = @"Data Source=MONSTER-MUHAMME\SQLEXPRESS;Initial Catalog=görsel programlama sql;Integrated Security=True";
        public int sonuc = 0;
        public SifreDegistir()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox_Captcha.Text.Equals(sonuc.ToString()))//girilen değer istenen ile aynıysa çalışır
            {
                label_mesaj.Text = "";
                if(textBox_YeniSifre.Text==textBox_YeniSifreOnay.Text)//yeni şifre ile tekrarı  aynı ise çalışır
                {
                    EskiSifreKontrol();
                }
                else
                {
                    label_mesaj.Text = "yeni şifre ile tekrarı aynı değil...";
                }
            }
            else
            {
                label_mesaj.Text = "Captcha hatalı girildi...";
            }
        }
        public void EskiSifreKontrol()
        {
            string sorgu = "select sifre from tablo_login where kullanici=@user and sifre=@pass";//veritabanında seçilen satırın bilgileri
            con = new SqlConnection(sqlcon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", login_giris.kullanicimSession);
            cmd.Parameters.AddWithValue("@pass", VeriTabani.MD5Sifrele(textBox_EskiSifre.Text));
            con.Open();
            dr = cmd.ExecuteReader();
            //eğer veri geldiyse
            if (dr.Read())
            {
                //eski sifre doğruysa yapılacak islem

                string sql = "update tablo_login set sifre='" + VeriTabani.MD5Sifrele(textBox_YeniSifre.Text) + "'";//güncelleme islemi
                VeriTabani.komutyolla(sql);
                MessageBox.Show("Şifre Değiştirme İşlemi Başarılı...");

            }
            else
            {
                //yanlıssa yapılcak islem

                label_mesaj.Text = "Eski Şifreniz Hatalı...";

            }
            con.Close();

        }

        private void SifreDegistir_Load(object sender, EventArgs e)//rastgele iki sayının toplamını giriş olarak alımı
        {
            Random r = new Random();
            int ilk = r.Next(0, 100);
            int ikinci = r.Next(0, 100);
            sonuc = ilk + ikinci;
            label_captcha.Text = ilk.ToString()+"+" + ikinci.ToString()+"=";
            //label_mesaj.Text = login_giris.kullanicimSession;
        }
    }
}
