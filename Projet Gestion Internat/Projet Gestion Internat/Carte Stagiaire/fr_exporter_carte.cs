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
using System.IO;
namespace Projet_Gestion_Internat
{
    public partial class fr_exporter_carte : Form
    {
        public fr_exporter_carte()
        {
            InitializeComponent();
        }

        private void fr_exporter_carte_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select carte from stagiaire where cfe="+uc_scan.v_cfe,Form1.cx);
            Form1.cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            Form1.cx.Close();
            byte[] temp = (byte[])dt.Rows[0][0];
            MemoryStream stream = new MemoryStream(temp);
            stream.Write(temp, 0, temp.Length);
            pictureBox3.Image = Image.FromStream(stream);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            imprimer_carte f = new imprimer_carte();
            this.Hide();
            f.Show();
        }
    }
}
