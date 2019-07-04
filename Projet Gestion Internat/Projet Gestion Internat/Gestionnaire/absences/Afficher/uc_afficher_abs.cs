using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Projet_Gestion_Internat
{
    public partial class uc_afficher_abs : UserControl
    {
        DataTable dt = new DataTable();
        int i = 0;
        public uc_afficher_abs()
        {
            InitializeComponent();
        }

        private void uc_afficher_abs_Load(object sender, EventArgs e)
        {
            comboBox3.Items.Add("Tous");
            comboBox3.Items.Add("9");
            comboBox3.Items.Add("10");
            comboBox3.Items.Add("11");
            comboBox3.Items.Add("12");
            comboBox3.Items.Add("1");
            comboBox3.Items.Add("2");
            comboBox3.Items.Add("3");
            comboBox3.Items.Add("4");
            comboBox3.Items.Add("5");
            comboBox3.Items.Add("6");
            comboBox3.Text = "Tous";
            comboBox3.Enabled = false;

            comboBox4.Items.Add("Tous");
            comboBox4.Items.Add("Repas");
            comboBox4.Items.Add("Detoir");
            comboBox4.Text = "Tous";
           
            SqlCommand cmd = new SqlCommand("select distinct nom_filiere from filiere ", Form1.cx);

            Form1.cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            Form1.cx.Close();
            dt.Rows.Add("Tous");
            comboBox6.DataSource = dt;
            comboBox6.DisplayMember = "nom_filiere";
            comboBox6.Text = "Tous";
            DataGridViewImageColumn c = new DataGridViewImageColumn();
            c.HeaderText = "Supprimer";
            c.Name= "Supprimer";
            c.Image = Properties.Resources.k;
            
            dataGridView1.Columns.Add(c);

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
            comboBox5.DataSource = dt;
            dt.Rows.Add("Tous");
            comboBox5.DisplayMember = "groupe";
            comboBox5.Text = "Tous";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                comboBox3.Enabled = true;
                maskedTextBox1.Enabled = false;
                maskedTextBox2.Enabled = false;
            }
            else
            {
                comboBox3.Enabled = false;
                maskedTextBox1.Enabled = true;
                maskedTextBox2.Enabled = true;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Supprimer" )
            {
                DialogResult r = MessageBox.Show("Vous voulez supprimer cette absence", "Tentative de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == r)
                {
                    SqlCommand cmd = new SqlCommand("delete from absence where num_abs=" + dataGridView1.CurrentRow.Cells[1].Value.ToString(), Form1.cx);

                    Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();

                    MessageBox.Show("cette absence a étè supprimé", "suppression effectuée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tb_connecter_Click(object sender, EventArgs e)
        {
            try
            {
                

                SqlCommand cmd = new SqlCommand("rechercher_abs", Form1.cx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@type", comboBox4.Text);
                cmd.Parameters.AddWithValue("@nom_fl", comboBox6.Text);
                cmd.Parameters.AddWithValue("@group_fl", comboBox5.Text);
                if (checkBox1.Checked)
                    cmd.Parameters.AddWithValue("@mois", comboBox3.Text);
                else cmd.Parameters.AddWithValue("@mois", "");
                cmd.Parameters.AddWithValue("@d1", maskedTextBox1.Text);
                cmd.Parameters.AddWithValue("@d2", maskedTextBox2.Text);

                Form1.cx.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                dt.Rows.Clear();
                dt.Load(dr);
                dr.Close();
                Form1.cx.Close();
               
                 dataGridView1.DataSource = dt;
             
            }
            catch (Exception ex)
            {
                Form1.cx.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
