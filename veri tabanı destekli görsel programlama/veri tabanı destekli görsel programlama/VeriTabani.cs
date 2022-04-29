using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace veri_tabanı_destekli_görsel_programlama
{
    class VeriTabani
    {
        VeriTabani()
        {

        }
         static SqlConnection con;
         static SqlDataAdapter da;
        static SqlDataReader dr;
         static SqlCommand cmd;
         static System.Data.DataSet ds;
        public static string sqlcon = @"Data Source=MONSTER-MUHAMME\SQLEXPRESS;Initial Catalog=görsel programlama sql;Integrated Security=True";

        public static bool Baglantidurum(DataGrid dataGridView1)
        {//veri tabanı bağlantısı kontrol 
            using (con = new SqlConnection(sqlcon))
            {
                try
                {
                    con.Open();
                    return true;
                }
                catch(SqlException exp)
                {
                    MessageBox.Show(exp.Message);
                    return false;
                }
            }
            

        }
       public static DataGridView GridhepsiniDoldur(DataGridView gridim,string sql_select_sorgusu)
        {
            con = new SqlConnection(sqlcon);
            da = new SqlDataAdapter("select * from"+sql_select_sorgusu, con);
            ds = new System.Data.DataSet();
            con.Open();
            da.Fill(ds, sql_select_sorgusu);
            gridim.DataSource = ds.Tables[sql_select_sorgusu];
            con.Close();
            return gridim;

        }
        public static bool Login_kontrol(string kullanici_adi,string sifre)
        {
            string sorgu = "select * from tablo_login where kullanici=@user and sifre=@pass";//veritabanında kayıtlı olan bilgileri burda girilen bilgilerle aynı mı diye kontrol eder. 
            con = new SqlConnection(sqlcon);
            cmd = new SqlCommand(sorgu, con);//komut kodu
            cmd.Parameters.AddWithValue("@user", kullanici_adi);//parametre alınarak bilgiler kontrol edilir.
            cmd.Parameters.AddWithValue("@pass", VeriTabani.MD5Sifrele(sifre));//parametre alınarak md5 şifreleme yöntemine göre kontrol edilir
            con.Open();
            dr = cmd.ExecuteReader();
            //eğer veri geldiyse
            if (dr.Read())//bilgiler okunur
            {
               // MessageBox.Show("Giriş Başarılı...");
                con.Close();
                return true;
              
            }
            else
            {
                 //MessageBox.Show("Kullanıcı adı ya da şifre hatalı!");
                con.Close();
                return false;
                
            }
            
        }

        public static string MD5Sifrele(string sifrelenecekmetin)
        {//kullanıcının girdiği şifreyi MD5 şifreleme yöntemine göre yazar
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dizi = Encoding.UTF8.GetBytes(sifrelenecekmetin);//yeni bir dizi oluşturulup girilen şifre boyutuna göre depolama yapar.
            //dizinin hash değeri çıkarılıyor
            dizi = md5.ComputeHash(dizi);//Belirtilen bayt dizisi için karma değeri hesaplar.
            StringBuilder sb = new StringBuilder();
            foreach (byte item in dizi)
                sb.Append(item.ToString("x2").ToLower());//16 karakterlik şifrelme yapar
            return sb.ToString();
        }
        public static string SHA256Sifrele(string sifrelenecekmetin)
        {//kullanıcın girdiği şifreyi SHA256 şifreleme yöntemine göre yazar 
            SHA256 sha256Hash = SHA256.Create();
            byte[] dizi = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(sifrelenecekmetin));
            StringBuilder nd = new StringBuilder();//metin sınıfından yeni bir nesne oluşturuldu
            foreach (byte item in dizi)
                nd.Append(item.ToString("x2").ToLower());//16 karakterlik şifreleme yapar
            return nd.ToString();
        }
        public static void komutyolla(string sql)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            
        }
    }
}

