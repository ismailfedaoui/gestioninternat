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

namespace Projet_Gestion_Internat
{
    public partial class form_pesuo_gest : Form
    {
        public static string pseudo;
        public form_pesuo_gest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select count(*) from gestionnaire where pseudo='"+textBox1.Text+"'",Form1.cx);
            Form1.cx.Open();
            int u = (int)cmd.ExecuteScalar();
            Form1.cx.Close();
            if (u > 0)
            {
                pseudo = textBox1.Text;
                fr_mot_de_passe_oublié f = new fr_mot_de_passe_oublié();
                this.Hide();
                f.Show();
            }
            else { MessageBox.Show("Ce pseudo n'existe pas, Veuillez vérifier votre Pseudo"); }
        }
    }
}
