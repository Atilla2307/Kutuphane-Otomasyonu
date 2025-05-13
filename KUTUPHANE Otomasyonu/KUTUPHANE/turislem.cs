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
    public partial class turislem : Form
    {
        public turislem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (baglanti.State != ConnectionState.Open)
            {
                baglanti.Open();
            }
            SqlCommand com = new SqlCommand("insert into Kitap_Turleri values(@tur_Ad)", baglanti);
            com.Parameters.AddWithValue("@tur_Ad", textBox1.Text);
            com.ExecuteNonQuery();
            baglanti.Close();
            turlerisırala();
        }

        private void turislem_Load(object sender, EventArgs e)
        {
            turlerisırala();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ANB-LAB3-BL22;Initial Catalog=Kutuphane1;User ID=sa;Password=123456");
        void turlerisırala()
        {
            try
            {

                SqlDataAdapter adp = new SqlDataAdapter("select * from Kitap_Turleri", baglanti);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["Tur_ID"].Width = 150;
                dataGridView1.Columns["Tur_Ad"].Width = 300;

            }
            catch (Exception)
            {

                throw;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (baglanti.State != ConnectionState.Open)
            {
                baglanti.Open();
            }
            SqlCommand com = new SqlCommand("delete from Kitap_Turleri where Tur_ID=@tur_ID ", baglanti);
            com.Parameters.AddWithValue("@tur_ID", dataGridView1.CurrentRow.Cells["Tur_ID"].Value.ToString());
            com.ExecuteNonQuery();
            baglanti.Close();
            turlerisırala();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["Tur_Ad"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }
                SqlCommand komut = new SqlCommand("update Kitap_Turleri set Tur_Ad=@Tur_Ad where Tur_ID=@TUR_ID", baglanti);

                komut.Parameters.AddWithValue("@TUR_ID", int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                komut.Parameters.AddWithValue("@Tur_Ad", textBox1.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                textBox1.Clear();
                MessageBox.Show("Güncelleme tamamlandı", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                turlerisırala();
            }


            catch (Exception)
            {
                MessageBox.Show("başarısız");
            }
        }
    }
}
