using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KUTUPHANE
{
    public partial class ogrencislem : Form
    {
        public ogrencislem()
        {
            InitializeComponent();
        }
        SqlConnection sql = new SqlConnection("Data Source=ANB-LAB3-BL22;Initial Catalog=Kutuphane1;User ID=sa;Password=123456");
        SqlCommand com;
        private void ogrencislem_Load(object sender, EventArgs e)
        {
            listele();
        }
        void listele()
        {
            SqlDataAdapter adapter=new SqlDataAdapter("select * from Ogrenci",sql);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["Ogrenci_No"].HeaderText = "ÖĞRENCİ NUMARASI";
            dataGridView1.Columns["OGR_Ad"].HeaderText = "ÖĞRENCİ ADI";
            dataGridView1.Columns["OGR_Soyad"].HeaderText = "ÖĞRENCİ SOYADI";
            dataGridView1.Columns["OGR_Sinif"].HeaderText = "ÖĞRENCİ SINIFI";
            dataGridView1.Columns["OGR_Cinsiyet"].HeaderText = "ÖĞRENCİ CİNSİYET";
            dataGridView1.Columns["OGR_Tel"].HeaderText = "ÖĞRENCİ TELEFON";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (sql.State != ConnectionState.Open)
                {
                    sql.Open();

                }
                com = new SqlCommand("insert into Ogrenci(Ogrenci_No,OGR_Ad,OGR_Soyad,OGR_Sinif,OGR_Cinsiyet,OGR_Tel) values(@No,@Ad,@Soyad,@Sinif,@Cinsiyet,@Tel)", sql);
                com.Parameters.AddWithValue("@No", int.Parse(textBox1.Text));
                com.Parameters.AddWithValue("@Ad", textBox2.Text);
                com.Parameters.AddWithValue("@Soyad", textBox3.Text);
                com.Parameters.AddWithValue("@Sinif", int.Parse( comboBox1.SelectedItem.ToString())) ;
                com.Parameters.AddWithValue("@Cinsiyet",Convert.ToString( comboBox2.SelectedItem.ToString()));
                com.Parameters.AddWithValue("@Tel", textBox4.Text);
                listele();

                com.ExecuteNonQuery();
                sql.Close();
                MessageBox.Show("işlem başarılı");
               
            }
            catch (Exception)
            {

                MessageBox.Show("hata");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sql.State != ConnectionState.Open)
            {
                sql.Open();
            }
            com = new SqlCommand("update Ogrenci set  OGR_Ad=@Ad,OGR_Soyad=@Soyad,OGR_Sinif=@Sinif,OGR_Cinsiyet=@Cinsiyet,OGR_Tel=@Tel where Ogrenci_No=@NO ", sql);
            com.Parameters.AddWithValue("@Ad",textBox1.Text);
            com.Parameters.AddWithValue("@Soyad",textBox2.Text);
            com.Parameters.AddWithValue("@Sinif",int.Parse(comboBox1.SelectedItem.ToString()));
            com.Parameters.AddWithValue("@Cinsiyet",comboBox2.SelectedItem.ToString());
            com.Parameters.AddWithValue("@Tel",textBox4.Text);
            com.Parameters.AddWithValue("@NO", dataGridView1.CurrentRow.Cells["Ogrenci_No"].Value.ToString());
            com.ExecuteNonQuery();
            listele();
            Temizle();
            sql.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                if (sql.State != ConnectionState.Open)
                {
                    sql.Open();
                }
                string sil = "delete  from Ogrenci where Ogrenci_No=@NO";
                 com = new SqlCommand(sil, sql);

                com.Parameters.AddWithValue("@NO", dataGridView1.CurrentRow.Cells["Ogrenci_No"].Value.ToString());
                com.ExecuteNonQuery();
                listele();
                sql.Close();
            
            
        }


        void Temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.SelectedItem = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox2.SelectedItem = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
