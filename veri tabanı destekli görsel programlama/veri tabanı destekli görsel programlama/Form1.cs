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
    public partial class Form1 : Form
    {   //Data Source=MONSTER-MUHAMME\SQLEXPRESS;Initial Catalog="görsel programlama sql";Integrated Security=True
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        public static string sqlcon = @"Data Source=MONSTER-MUHAMME\SQLEXPRESS;Initial Catalog=görsel programlama sql;Integrated Security=True";//veritabanı sunucu bilgisi
        void GridDoldur()
        {
            con = new SqlConnection(sqlcon);
            da = new SqlDataAdapter("select * from tablo_login", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "tablo_login");
            dataGridView1.DataSource = ds.Tables["tablo_login"];//tablo_login bilgisini datagridwiev1 e getir.
            con.Close();

        }
        public Form1()
        {
            InitializeComponent();
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GridDoldur();
            VeriTabani.GridhepsiniDoldur(dataGridView1, " tablo_login");
            dataGridView1.Columns[2].Visible = false;//tablonun 2.indisindeki kolonu gizle
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
           // dateTimePicker1.Value = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {//yeni kayıt için boşaltma yapılır
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            dateTimePicker1.Value=DateTime.Now;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "insert into tablo_login (kullanici,sifre,tarih) values(@user,@pass,@tarih)";//belli parametrelere göre ekleme(giriş) yapar
           // VeriTabani.komutyolla(sql);
            con = new SqlConnection(sqlcon); 
             
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@user", textBox2.Text);//kullanıcı adı için giriş alıp ekleme yapar
            cmd.Parameters.AddWithValue("@pass",VeriTabani.MD5Sifrele(textBox3.Text) );//şifre için giriş alıp MD5 modelinde ekleme yapar
            cmd.Parameters.AddWithValue("@tarih",DateTime.Now);//tarih ekler
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            GridDoldur();

        }
        public void ekleme_sorgu(string sql)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            GridDoldur();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "delete from tablo_login where kullanici=@user and sifre=@pass and KulID=@kID  ";
            //VeriTabani.komutyolla(sql);
             con = new SqlConnection(sqlcon);

             cmd = new SqlCommand();
             cmd.Parameters.AddWithValue("@user", textBox2.Text);
             cmd.Parameters.AddWithValue("@pass", textBox3.Text);
             cmd.Parameters.AddWithValue("@kID", Convert.ToInt32(textBox1.Text));
            // cmd.Parameters.AddWithValue("@tarih", DateTime.Now);
             con.Open();
             cmd.Connection = con;
             cmd.CommandText = sql;
             cmd.ExecuteNonQuery();
             con.Close();
             GridDoldur();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sql = " update tablo_login set  sifre=@pass where kullanici=@user and  KulID=@kID  ";
            //VeriTabani.komutyolla(sql);
             con = new SqlConnection(sqlcon);

              cmd = new SqlCommand();
              cmd.Parameters.AddWithValue("@user", textBox2.Text);
              cmd.Parameters.AddWithValue("@pass",VeriTabani.MD5Sifrele(textBox3.Text));
              cmd.Parameters.AddWithValue("@kID", Convert.ToInt32(textBox1.Text));
              con.Open();
              cmd.Connection = con;
              cmd.CommandText = sql;
              cmd.ExecuteNonQuery();
              con.Close();
              GridDoldur();
        }

        private void şifreDeğiştirmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SifreDegistir a = new SifreDegistir();
            a.ShowDialog();
        }
    }
}

