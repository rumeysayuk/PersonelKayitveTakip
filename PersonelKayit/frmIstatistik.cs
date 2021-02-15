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

namespace PersonelKayit
{
    public partial class frmIstatistik : Form
    {
        public frmIstatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-J7TKCO6\\SQLEXPRESS;Initial Catalog=personelVeriTabani;Integrated Security=True");

        private void frmIstatistik_Load(object sender, EventArgs e)
        {
            //DBConnection dbCon = new DBConnection();
            //SqlParameter[] sqlParameters = new SqlParameter[6];
            //string query = @"Select (Select count(*) from Tbl_personel) personelSayisi
            //  ,(Select count(*) from Tbl_personel where perDurum = 1) evli
            //   ,(Select count(*) from Tbl_personel where perDurum=0) bekar
            //   ,(Select count(DISTINCT perSehir) From Tbl_personel)  sehirAdedi
            //   ,(Select Sum(perMaas) From Tbl_personel) toplamMaas
            //   ,(Select Avg(perMaas) From Tbl_personel) ortalamaMas";
            //   sqlParameters[0] = new SqlParameter("", lblToplamPersonel);
            //   sqlParameters[1] = new SqlParameter("", lblEvliPersonel);
            //   sqlParameters[2] = new SqlParameter("", lblBekarPersonel); 
            //   sqlParameters[3] = new SqlParameter("", lblSehirSayisi);
            //   sqlParameters[4] = new SqlParameter("", lblToplamMaas);
            //   sqlParameters[5] = new SqlParameter("", lblMaasOrtalama);
            //Int32 dt = dbCon.executeFrmIstatistik(query, sqlParameters);
            //Console.WriteLine(dt );

            //Toplam Personel Sayısı
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select Count(*) From Tbl_personel", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblToplamPersonel.Text = dr1[0].ToString();
            }
            baglanti.Close();
            //Evli Personel Sayisi 
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select Count(*) From Tbl_personel where perDurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblEvliPersonel.Text = dr2[0].ToString();
            }
            baglanti.Close();
            //Bekar personel Sayisi
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select Count(*) From Tbl_personel where perDurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblBekarPersonel.Text = dr3[0].ToString();
            }
            baglanti.Close();
            //Şehir Sayisi
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select Count (distinct(perSehir)) From Tbl_personel ", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblSehirSayisi.Text = dr4[0].ToString();
            }
            baglanti.Close();
            //Toplam Maaş
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select Sum(perMaas) From Tbl_personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblToplamMaas.Text = dr5[0].ToString();
            }
            baglanti.Close();
            //Ortalama Maaş
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select Avg(perMaas) From Tbl_personel ", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblMaasOrtalama.Text = dr6[0].ToString();
            }
            baglanti.Close();
            baglanti.Open();

            baglanti.Close();


        }


        
    }
}
