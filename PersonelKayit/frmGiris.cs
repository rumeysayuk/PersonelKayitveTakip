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
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            DBConnection dbCon = new DBConnection();
            string query = @"Select * From Tbl_yonetici where KullaniciAd=@kullaniciAd and Sifre=@sifre";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@kullaniciAd", txtKAd.Text);
            sqlParameters[1] = new SqlParameter("@sifre", txtSifre.Text);
            DataTable dt = dbCon.executeSelect(query, sqlParameters);
            if (dt!=null)
            {
               
                    frmAnaForm frmAnaForm = new frmAnaForm();
                    frmAnaForm.Show();
                    this.Hide();
            }

            
            else
            {
                MessageBox.Show("Hatali giris yaptınız");
            }



            //SqlCommand komut = new SqlCommand("Select * From Tbl_yonetici where KullaniciAd=@kullaniciAd and Sifre=@sifre",baglanti);
            //komut.Parameters.AddWithValue("@kullaniciAd", txtKAd.Text);
            //komut.Parameters.AddWithValue("@sifre", txtSifre.Text);
            //SqlDataReader dr = komut.ExecuteReader();
            //if (dr.Read())
            //{
                
            //}
            //else
            //{
            //    MessageBox.Show("Hatali giris yaptınız");
            //}
        }
    }
}
