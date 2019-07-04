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
    public partial class supprimer_filiere : Form
    {
        public supprimer_filiere()
        {
            InitializeComponent();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select groupe from filiere where nom_filiere='" + comboBox6.Text + "'", Form1.cx);

            Form1.cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            Form1.cx.Close();

            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "groupe";
        }

        private void supprimer_filiere_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select distinct nom_filiere from filiere ", Form1.cx);

            Form1.cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            Form1.cx.Close();

            comboBox6.DataSource = dt;
            comboBox6.DisplayMember = "nom_filiere";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Si vous supprimez cette filiére, tous les emplois de temps liés seront supprimés mais les stagiaires sont gardés. Vous êtes sûre de vouloir supprimer ?", "Attention", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (r == DialogResult.Yes) {
                SqlCommand cmd = new SqlCommand("delete from filiere where groupe=@grp ", Form1.cx);
                cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                Form1.cx.Open();
                cmd.ExecuteNonQuery();
                Form1.cx.Close();
            }
        }

        private void tb_connecter_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Si vous supprimez cette filiére, tous les emplois de temps liés seront supprimés mais les stagiaires sont gardés. Vous êtes sûre de vouloir supprimer ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("delete from filiere where groupe=@grp ", Form1.cx);
                cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                Form1.cx.Open();
                cmd.ExecuteNonQuery();
                Form1.cx.Close();
            }
        }
    }
}
