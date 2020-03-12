using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Kayıtlar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataTable tablo = new DataTable();
        OleDbDataAdapter kayitlar = new OleDbDataAdapter();

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        void listele()
        {
            OleDbDataAdapter adaptor = new OleDbDataAdapter("SELECT * FROM kalanlar", db.baglanti);
            DataSet ds = new DataSet();
            ds.Clear();
            adaptor.Fill(ds, "kalanlar");
            dataGridView1.DataSource = ds.Tables["kalanlar"];
            adaptor.Dispose();

            textBox3.Text = dataGridView1.RowCount.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 frm2 = new Form2();
            frm2.Show();
            db.kes();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
            db.kes();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            db.kes();
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            int adet = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["fiyatMiktar"].Value.ToString());

            decimal fiyat = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["fiyatMiktar"].Value.ToString());

            decimal toplam = adet * fiyat;

            MessageBox.Show(toplam.ToString());
        }
    }
}
