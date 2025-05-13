using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KUTUPHANE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kitap kitap = new kitap();
            kitap.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            turislem tur = new turislem();
            tur.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ogrencislem ogr = new ogrencislem();
            ogr.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            oduncislem odunc = new oduncislem();
            odunc.ShowDialog();
        }
    }
}
