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
    public partial class frmAnaForm : Form
    {
        DBConnection dbCon = new DBConnection();
        public frmAnaForm()
        {
            InitializeComponent();
            btnSil.Enabled = false;
            btnGuncelle.Enabled = false;
        }
        // SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-J7TKCO6\\SQLEXPRESS;Initial Catalog=personelVeriTabani;Integrated Security=True");
        void temizle()
        {
            txtId.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtMeslek.Text = "";
            maskTxtMaas.Text = "";
            comboSehir.Text = "";
            radioBekar.Checked = false;
            radioEvli.Checked = false;
            txtAd.Focus();
            btnSil.Enabled = false;
            btnGuncelle.Enabled = false;
            btnKaydet.Enabled = true;
        }
        void Listele()
        {
            string query1 = @"SELECT [perId],[perAd],[perSoyad],[perSehir],[perMaas],
                            [perDurum],
                            CASE [perDurum] WHEN  1 THEN 'Evli'
                            ELSE 'Sap'
                            END AS evlilikDurum
                            ,[perMeslek] FROM [dbo].[Tbl_personel] ORDER BY perId DESC ";
            SqlParameter[] sqlParameters1 = new SqlParameter[0];
            DataTable dt1 = dbCon.executeSelect(query1, sqlParameters1);
            dataGridView1.DataSource = dt1;
            btnSil.Enabled = true;          
           btnGuncelle.Enabled = true;
        }
        void minSinir()
        {
            if (txtAd.TextLength <= 2 || txtSoyad.TextLength <= 2 || txtMeslek.TextLength <= 5 || comboSehir.Height < 4)
            {
                MessageBox.Show("Eksik karakter");
            }
            else
            {

            }
        }
        void maxSinir()
        {
            txtAd.MaxLength = 15;
            txtSoyad.MaxLength = 23;
            txtMeslek.MaxLength = 30;
            comboSehir.MaxLength = 13;

        }
        bool mukerrer()
        {
                string query2 = (@"SELECT count(distinct perAd) Ad,count(distinct perSoyad) soyad FROM [dbo].[Tbl_personel] where perAd=@perAd and perSoyad=@perSoyad");
            SqlParameter[] sqlParameters2 = new SqlParameter[2];
            sqlParameters2[0] = new SqlParameter("@perAd", txtAd.Text);
            sqlParameters2[1] = new SqlParameter("@perSoyad", txtSoyad.Text);
            bool durum = dbCon.executeTekrar(query2, sqlParameters2);
            if (durum == true)
            {
                MessageBox.Show("personel kayıtlı ");

                
            }
            Listele();
            temizle();
            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
            maxSinir();
            btnSil.Enabled = false;
            txtAd.Select();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {  
            minSinir(); 
            maxSinir();

            string query = @"insert into Tbl_personel(perAd, perSoyad, perSehir, perMaas, perDurum, perMeslek) values(@perAd, @perSoyad, @perSehir, @perMaas, @perDurum, @perMeslek)";
           
            
            SqlParameter[] sqlParameters = new SqlParameter[6];

            if (String.IsNullOrEmpty(txtAd.Text) || String.IsNullOrEmpty(txtSoyad.Text) || String.IsNullOrEmpty(comboSehir.Text) || String.IsNullOrEmpty(txtMeslek.Text) || (radioEvli.Checked == false && radioBekar.Checked == false) || comboSehir.SelectedIndex == 0)
            {

                txtAd.BackColor = Color.Yellow;
                txtSoyad.BackColor = Color.Yellow;
                comboSehir.BackColor = Color.Yellow;
                txtMeslek.BackColor = Color.Yellow;
                radioBekar.BackColor = Color.Yellow;
                radioEvli.BackColor = Color.Yellow;
                btnSil.Enabled = false;
                MessageBox.Show("Boş alan bıraktınız veya sayi girmeyi deniyorsunuz");
            }
            mukerrer();
            if (mukerrer() == true)
            {
                Console.WriteLine("Eşleşen kullanıcı bulundu");
            }

            else
            {
                sqlParameters[0] = new SqlParameter("@perAd", txtAd.Text);
                sqlParameters[1] = new SqlParameter("@perSoyad", txtSoyad.Text);
                sqlParameters[2] = new SqlParameter("@perSehir", comboSehir.Text);
                sqlParameters[3] = new SqlParameter("@perMaas", maskTxtMaas.Text);
                sqlParameters[4] = new SqlParameter("@perDurum", radioEvli.Checked);
                sqlParameters[5] = new SqlParameter("@perMeslek", txtMeslek.Text);

                Int32 idsi = dbCon.executeInsert(query, sqlParameters);
                if (idsi > 0)
                {
                    MessageBox.Show("personel eklendi numarası: " + idsi.ToString());
                    txtId.Text = idsi.ToString();

                    btnSil.Enabled = true;
                    btnGuncelle.Enabled = true;
                    btnKaydet.Enabled = false;
                    Listele();
                    temizle();
                    var fullName = (txtAd.Text + txtSoyad.Text);
                    MessageBox.Show(fullName);
                }
                else MessageBox.Show("personel eklenemedi");
            }
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            maxSinir();
            minSinir();
            SqlParameter[] sqlParameters = new SqlParameter[7];//hata var parametlreler null
            string query = @"UPDATE [dbo].[Tbl_personel]
                           SET [perAd] = @perAd
                           ,[perSoyad] = @perSoyad
                           ,[perSehir] = @perSehir
                           ,[perMaas] = @perMaas
                           ,[perDurum] = @perDurum
                           ,[perMeslek] = @perMeslek
                           WHERE perId=@perId";
            if (String.IsNullOrEmpty(txtAd.Text) || String.IsNullOrEmpty(txtSoyad.Text) || String.IsNullOrEmpty(comboSehir.Text) || String.IsNullOrEmpty(maskTxtMaas.Text) || String.IsNullOrEmpty(txtMeslek.Text) || (radioEvli.Checked == false && radioBekar.Checked == false))
            {

                txtAd.BackColor = Color.Yellow;
                txtSoyad.BackColor = Color.Yellow;
                comboSehir.BackColor = Color.Yellow;
                maskTxtMaas.BackColor = Color.Yellow;
                txtMeslek.BackColor = Color.Yellow;
                radioBekar.BackColor = Color.Yellow;
                radioEvli.BackColor = Color.Yellow;
                MessageBox.Show("Boş alan bıraktınız veya sayi girmeyi deniyorsunuz");
            }
            else
            {
                sqlParameters[0] = new SqlParameter("@perAd", txtAd.Text);
                sqlParameters[1] = new SqlParameter("@perSoyad", txtSoyad.Text);
                sqlParameters[2] = new SqlParameter("@perSehir", comboSehir.Text);
                sqlParameters[3] = new SqlParameter("@perMaas", maskTxtMaas.Text);
                sqlParameters[4] = new SqlParameter("@perDurum", radioEvli.Checked);
                sqlParameters[5] = new SqlParameter("@perMeslek", txtMeslek.Text);
                sqlParameters[6] = new SqlParameter("@perId", txtId.Text);

                Int32 idsi = dbCon.executeUpdate(query, sqlParameters);
                if (idsi > 0)
                {
                    MessageBox.Show("personel güncellendi");
                    ///burAYA
                    Listele();
                }
                else{
                    MessageBox.Show("personel güncellendi");
                }
            }
            btnKaydet.Enabled = false;

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            comboSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            maskTxtMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            if (dataGridView1.Rows[secilen].Cells[6].Value.ToString()=="Evli")
            {
                radioEvli.Checked = true;
                radioBekar.Checked = false;
            }
            else
            {

                radioEvli.Checked = false;
                radioBekar.Checked = true;
            }

            

            txtMeslek.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();

            btnKaydet.Enabled = true;
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
        }



        private void btnSil_Click(object sender, EventArgs e)
        {
            maxSinir();
            string query = @"DELETE FROM [dbo].[Tbl_personel] WHERE perId=@perId";

            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@perId", txtId.Text);

            bool durum = dbCon.executeDelete(query, sqlParameters);
            if (durum == true)
            {
                MessageBox.Show("personel silindi. ");
                Listele();
                temizle();
            }
            else if(String.IsNullOrEmpty(txtAd.Text) || String.IsNullOrEmpty(txtSoyad.Text) || String.IsNullOrEmpty(comboSehir.Text) || String.IsNullOrEmpty(txtMeslek.Text) || (radioEvli.Checked == false && radioBekar.Checked == false) || comboSehir.SelectedIndex == 0)
            {
                btnSil.Enabled = false;
                temizle();
                Listele();
                MessageBox.Show("Alanları doldurmayı dene ");

            }


        }



        private void btnIstatistik_Click(object sender, EventArgs e)
        {
            frmIstatistik fr = new frmIstatistik();
            fr.Show();
        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
            frmGrafik frg = new frmGrafik();
            frg.Show();
        }

    }
}
