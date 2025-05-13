using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KUTUPHANE
{
    public partial class kitap : Form
    {
        public kitap()
        {
            InitializeComponent();
        }
        SqlConnection sql = new SqlConnection("Data Source=ANB-LAB3-BL22;Initial Catalog=Kutuphane1;User ID=sa;Password=123456");
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void kitap_Load(object sender, EventArgs e)
        {
            
            kitapturyukle();
            kitapListele();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ANB-LAB3-BL22;Initial Catalog=Kutuphane1;User ID=sa;Password=123456");

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (baglanti.State != ConnectionState.Open)
            {
                baglanti.Open();
            }
            SqlCommand komut = new SqlCommand("insert into KitaPlar(Kitap_Adi,Yazar,YayinEvi,Sayfa_Sayisi,Tur_ID) values(@Ad,@Yazar,@Y_Evi,@S_Sayisi,@TurID)",baglanti);
            SqlCommand com = new SqlCommand("insert into Kitap_Turleri(Tur_Ad) values(@TurAD)",baglanti);
            komut.Parameters.AddWithValue("@Ad",txtKitapAdi.Text);
            komut.Parameters.AddWithValue("@Yazar",txtYazar.Text);
            komut.Parameters.AddWithValue("@Y_Evi",txtYayinEvi.Text);
            komut.Parameters.AddWithValue("@S_Sayisi",int.Parse( txtSayfaSayisi.Text));
            com.Parameters.AddWithValue("@TurAD",comboKitapTur.SelectedValue.ToString());
            komut.Parameters.AddWithValue("@TurID", int.Parse(comboKitapTur.SelectedValue.ToString()));
            com.ExecuteNonQuery();
            komut.ExecuteNonQuery();
            baglanti.Close();
            kitapListele();
        }
        void kitapturyukle()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Kitap_Turleri",baglanti);
            DataTable table = new DataTable();
            adapter.Fill(table);
            comboKitapTur.DataSource = table;
            comboKitapTur.ValueMember = "Tur_ID";
            comboKitapTur.DisplayMember = "Tur_Ad";
        }
        void kitapListele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select Kitap_ID,Kitap_Turleri.Tur_ID,Kitap_Adi,Yazar,YayinEvi,Sayfa_Sayisi,Kitap_Turleri.Tur_Ad from KitaPlar,Kitap_Turleri where KitaPlar.Tur_ID=Kitap_Turleri.Tur_ID ", baglanti);
            DataTable table = new DataTable();
            adp.Fill(table);
            dataGridView1.DataSource = table;
            
            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }
                SqlCommand komut = new SqlCommand("delete from KitaPlar where Kitap_ID=@ID", baglanti);
                komut.Parameters.AddWithValue("@ID", int.Parse(dataGridView1.CurrentRow.Cells["Kitap_ID"].Value.ToString()));
                komut.ExecuteNonQuery();
                kitapListele();
                baglanti.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Hata");
            }
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (baglanti.State != ConnectionState.Open)
            {
                baglanti.Open();
            }
            SqlCommand komut = new SqlCommand("update KitaPlar set Kitap_Adi=@Kitap_Adi,Yazar=@Yazar,YayinEvi=@Y_Evi,Sayfa_Sayisi=@S_Sayisi where Kitap_ID=@ID", baglanti);
            SqlCommand kom = new SqlCommand("update Kitap_Turleri set Kitap_Turleri.Tur_Ad = @TURAD where Tur_ID=@ID");
            kom.Parameters.AddWithValue("@TURAD", comboKitapTur.SelectedValue.ToString());
            kom.Parameters.AddWithValue("@Tur_ID",int.Parse (dataGridView1.CurrentRow.Cells[1].Value.ToString()));
            komut.Parameters.AddWithValue("@Kitap_Adi",txtKitapAdi.Text);
            komut.Parameters.AddWithValue("@Yazar",txtYazar.Text);
            komut.Parameters.AddWithValue("@Y_Evi", txtYayinEvi.Text);
            komut.Parameters.AddWithValue("S_Sayisi",int.Parse( txtSayfaSayisi.Text));
            komut.Parameters.AddWithValue("@ID", int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            komut.ExecuteNonQuery();
            baglanti.Close();
            kitapListele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKitapAdi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtYazar.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtYayinEvi.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtSayfaSayisi.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }
    }
}
