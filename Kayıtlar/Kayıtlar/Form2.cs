using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kayıtlar
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO kalanlar (tarih, fiyatMiktar, aciklama)" + "VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + richTextBox1.Text + "')";
                cmd.Parameters.AddWithValue("@tarih", textBox1.Text);
                cmd.Parameters.AddWithValue("@fiyatMiktar", textBox2.Text);
                cmd.Parameters.AddWithValue("aciklama", richTextBox1.Text);
                cmd.Connection = db.baglanti;
                db.baglanti.Open();
                cmd.ExecuteNonQuery();

                db.kes();
                MessageBox.Show("KAYIT YAPILDI");
                textBox1.Clear();
                textBox2.Clear();
                richTextBox1.Clear();
                this.Hide();
                Form1 frm1 = new Form1();
                frm1.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show("KAYIT YAPILAMADI!! HATA: "+ ex.Message);
            }
            db.kes();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;

            textBox1.Text = String.Format("{0:d/M/yyyy}", dt);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm1 = new Form1();
            frm1.Show();
            db.kes();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Form1 frm1 = new Form1();
            frm1.Show();
            db.kes();
        }
    }
}
