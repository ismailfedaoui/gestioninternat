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
    public partial class uc_sanctions : UserControl
    {
        int l = -1;
        public uc_sanctions()
        {
            InitializeComponent();
        }

        private void uc_sanctions_Load(object sender, EventArgs e)
        {
            SqlCommand cmd11 = new SqlCommand("select distinct nom_filiere from filiere ", Form1.cx);

            Form1.cx.Open();
            SqlDataReader dr11 = cmd11.ExecuteReader();
            DataTable dt11 = new DataTable();
            dt11.Load(dr11);
            dr11.Close();
            Form1.cx.Close();
            dt11.Rows.Add("Tous");
            comboBox4.DataSource = dt11;
            comboBox4.DisplayMember = "nom_filiere";
            comboBox4.Text = "Tous";

            comboBox3.Enabled = false;

            SqlCommand cmd = new SqlCommand("select cfe , s.prenom,s.nom,type_sanc,motif_sanc ,date_sanc,duree_sanc,g.prenom+' '+g.nom from sanction sa join stagiaire s on sa.#cfe=s.cfe join gestionnaire g on sa.#id_gest=g.id_gest ", Form1.cx);
            Form1.cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            Form1.cx.Close();
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            comboBox1.Text = "";
            richTextBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into sanction values(@type,@motif,getdate(),@duree,@id_gest,@cfe)", Form1.cx);
            cmd.Parameters.AddWithValue("@type", comboBox1.Text);
            cmd.Parameters.AddWithValue("@motif", richTextBox1.Text);
            cmd.Parameters.AddWithValue("@duree", int.Parse(textBox5.Text));
            cmd.Parameters.AddWithValue("@id_gest", 1);
            cmd.Parameters.AddWithValue("@cfe", int.Parse(textBox1.Text));
            SqlCommand cmd2 = new SqlCommand("insert into [dbo].[stagiaire_gestionnaire] values(getdate(),'Sanction',@cfe,@id_gest)", Form1.cx);
            cmd2.Parameters.AddWithValue("@id_gest", 1);
            cmd2.Parameters.AddWithValue("@cfe", int.Parse(textBox1.Text));
            Form1.cx.Open();
            cmd.ExecuteNonQuery();

            cmd2.ExecuteNonQuery();
            Form1.cx.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            afficher(0);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (l > 0)
            {
                l--;
            }
            afficher(l);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            if (l < dataGridView1.Rows.Count-1 )
            {
                l++;
            }
            afficher(l);
        }
        void afficher(int pos)
        {
            textBox1.Text = dataGridView1.Rows[pos].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[pos].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[pos].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[pos].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[pos].Cells[6].Value.ToString();
            richTextBox1.Text = dataGridView1.Rows[pos].Cells[4].Value.ToString();
            dataGridView1.ClearSelection();
            dataGridView1.Rows[pos].Selected = true;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            afficher(dataGridView1.Rows.Count - 1);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("select groupe from filiere where nom_filiere='" + comboBox4.Text + "'", Form1.cx);

            Form1.cx.Open();
            SqlDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dr2.Close();
            Form1.cx.Close();
            dt2.Rows.Add("Tous");
            comboBox2.DataSource = dt2;
            comboBox2.DisplayMember = "groupe";
            comboBox2.Text = "Tous";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("rechercher_sanction", Form1.cx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cfe", textBox6.Text);
                cmd.Parameters.AddWithValue("@date1", maskedTextBox2.Text);
                cmd.Parameters.AddWithValue("@date2", maskedTextBox3.Text);
                if(checkBox1.Checked)
                cmd.Parameters.AddWithValue("@mois", comboBox3.Text);
                else
                    cmd.Parameters.AddWithValue("@mois", "");
                cmd.Parameters.AddWithValue("@group_fl", comboBox2.Text);
                cmd.Parameters.AddWithValue("@nom_fl", comboBox4.Text);
                Form1.cx.Open();
                DataTable dt = new DataTable();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                dr.Close();
                Form1.cx.Close();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex) { Form1.cx.Close(); MessageBox.Show(ex.Message); }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                comboBox3.Enabled = true;
                maskedTextBox2.Enabled = false;
                maskedTextBox3.Enabled = false;

            }
            else
            {
                comboBox3.Enabled = false;
                maskedTextBox2.Enabled = true;
                maskedTextBox3.Enabled = true;
                comboBox3.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int a;
                if (int.TryParse(textBox1.Text, out a))
                {
                    SqlCommand cmd2 = new SqlCommand("select count(*) from stagiaire where cfe=" + int.Parse(textBox1.Text), Form1.cx);
                    SqlCommand cmd = new SqlCommand("select nom,prenom from stagiaire where cfe=" + int.Parse(textBox1.Text), Form1.cx);
                    Form1.cx.Open();
                    int k = (int)cmd2.ExecuteScalar();
                    DataTable dt = new DataTable();
                    if (k > 0)
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        dt.Load(dr);
                        dr.Close();
                        textBox2.Text = dt.Rows[0][0].ToString();
                        textBox3.Text = dt.Rows[0][1].ToString();
                    }
                    else
                    {
                        textBox2.Clear();
                        textBox3.Clear();
                    }
                    Form1.cx.Close();

                }
                else
                {
                    textBox2.Clear();
                    textBox3.Clear();
                }
            }
            else
            {
                textBox2.Clear();
                textBox3.Clear();
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            comboBox1.Text = "";
            richTextBox1.Clear();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into sanction values(@type,@motif,getdate(),@duree,@id_gest,@cfe)", Form1.cx);
            cmd.Parameters.AddWithValue("@type", comboBox1.Text);
            cmd.Parameters.AddWithValue("@motif", richTextBox1.Text);
            cmd.Parameters.AddWithValue("@duree", int.Parse(textBox5.Text));
            cmd.Parameters.AddWithValue("@id_gest", 1);
            cmd.Parameters.AddWithValue("@cfe", int.Parse(textBox1.Text));
            SqlCommand cmd2 = new SqlCommand("insert into [dbo].[stagiaire_gestionnaire] values(getdate(),'Sanction',@cfe,@id_gest)", Form1.cx);
            cmd2.Parameters.AddWithValue("@id_gest", 1);
            cmd2.Parameters.AddWithValue("@cfe", int.Parse(textBox1.Text));
            Form1.cx.Open();
            cmd.ExecuteNonQuery();

            cmd2.ExecuteNonQuery();
            Form1.cx.Close();
        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            afficher(0);
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            if (l > 0)
            {
                l--;
            }
            afficher(l);
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {

            if (l < dataGridView1.Rows.Count - 1)
            {
                l++;
            }
            afficher(l);
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            afficher(dataGridView1.Rows.Count - 1);
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("rechercher_sanction", Form1.cx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cfe", textBox6.Text);
                cmd.Parameters.AddWithValue("@date1", maskedTextBox2.Text);
                cmd.Parameters.AddWithValue("@date2", maskedTextBox3.Text);
                if (checkBox1.Checked)
                    cmd.Parameters.AddWithValue("@mois", comboBox3.Text);
                else
                    cmd.Parameters.AddWithValue("@mois", "");
                cmd.Parameters.AddWithValue("@group_fl", comboBox2.Text);
                cmd.Parameters.AddWithValue("@nom_fl", comboBox4.Text);
                Form1.cx.Open();
                DataTable dt = new DataTable();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                dr.Close();
                Form1.cx.Close();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex) { Form1.cx.Close(); MessageBox.Show(ex.Message); }

        }
    }
}
