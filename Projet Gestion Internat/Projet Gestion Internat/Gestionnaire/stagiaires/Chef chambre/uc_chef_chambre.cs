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
    public partial class uc_chef_chambre : UserControl
    {
        int l = -1;
        int i = 0;
        public uc_chef_chambre()
        {
            InitializeComponent();
        }

        private void uc_chef_chambre_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select distinct num_chambre as 'Chambre',max(date_debut_resp) as 'Date début',respo_chambre.#id_detoir as 'Detoir',cfe, nom + ' ' + prenom as 'Nom complet' from respo_chambre join stagiaire on respo_chambre.#cfe=stagiaire.cfe join chambre on chambre.id_chambre = respo_chambre.#id_chambre group  by cfe, nom + ' ' + prenom, respo_chambre.#id_detoir,num_chambre having max(date_debut_resp) in (select max(date_debut_resp) as 'Date début' from respo_chambre join stagiaire on respo_chambre.#cfe=stagiaire.cfe join chambre on chambre.id_chambre = respo_chambre.#id_chambre group  by respo_chambre.#id_detoir,num_chambre)", Form1.cx);
            Form1.cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            Form1.cx.Close();
            dataGridView1.DataSource = dt;
            comboBox1.Items.Add('A');
            comboBox1.Items.Add('B');
            comboBox1.Items.Add('C');
            comboBox1.Items.Add('D');
            comboBox2.Items.Add('1');
            comboBox2.Items.Add('2');
            comboBox2.Items.Add('3');
            comboBox2.Items.Add('4');
            comboBox2.Items.Add('5');
            comboBox2.Items.Add('6');
            comboBox2.Items.Add('7');
            comboBox2.Items.Add('8');

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { comboBox2.Enabled = false; SqlCommand cmd = new SqlCommand("select cfe, nom+' '+prenom as 'Nom complet' ,buanderie.#id_detoir,max(date_debut_resp) as 'Date début' from respo_chambre join stagiaire on respo_chambre.#cfe=stagiaire.cfe join buanderie on buanderie.id_buanderie=respo_chambre.#id_buanderie group  by cfe, nom+' '+prenom ,buanderie.#id_detoir", Form1.cx);
                Form1.cx.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                Form1.cx.Close();
                dataGridView1.DataSource = dt;
            }
            else { comboBox2.Enabled = true; SqlCommand cmd = new SqlCommand("select cfe, nom+' '+prenom as 'Nom complet' ,chambre.#id_detoir,num_chambre,max(date_debut_resp) as 'Date début' from respo_chambre join stagiaire on respo_chambre.#cfe=stagiaire.cfe join chambre on chambre.id_chambre=respo_chambre.#id_chambre group  by cfe, nom+' '+prenom ,chambre.#id_detoir,num_chambre", Form1.cx);
                Form1.cx.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                Form1.cx.Close();
                dataGridView1.DataSource = dt;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            if (l < dataGridView1.Rows.Count - 1)
            {
                l++;
            }
            afficher(l);
        }
        void afficher(int pos)
        {
            textBox1.Text = dataGridView1.Rows[pos].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[pos].Cells[2].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[pos].Cells[3].Value.ToString();
            dataGridView1.ClearSelection();
            dataGridView1.Rows[pos].Selected = true;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            afficher(dataGridView1.Rows.Count - 1);
        }

        private void tb_connecter_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd23 = new SqlCommand("select count(*) from stagiaire where cfe=" + textBox1.Text, Form1.cx);
                Form1.cx.Open();
                i = (int)cmd23.ExecuteScalar();
                Form1.cx.Close();
                if (i == 0) throw new Exception("ce stagiaire n'existe pas.");
                else
                {



                    if (checkBox1.Checked)

                    {
                        SqlCommand cmda = new SqlCommand("select #id_detoir from buanderie join stagiaire on stagiaire.#id_buanderie=buanderie.id_buanderie where cfe=" + textBox1.Text, Form1.cx);
                        Form1.cx.Open();
                        SqlDataReader dra = cmda.ExecuteReader();
                        DataTable dta = new DataTable();
                        dta.Load(dra);
                        dra.Close();
                        Form1.cx.Close();
                        if (dta.Rows[0][0].ToString() == comboBox1.Text)
                        {
                            SqlCommand cmd = new SqlCommand("insert into respo_chambre values(getdate(),@cfe,null,(select id_buanderie from buanderie where #id_detoir=@detoir),@detoir) ", Form1.cx);
                            cmd.Parameters.AddWithValue("@cfe", int.Parse(textBox1.Text));
                            cmd.Parameters.AddWithValue("@detoir", comboBox1.Text);

                            SqlCommand cmd4 = new SqlCommand("insert into [dbo].[stagiaire_gestionnaire] values(getdate(),'nouveau chef chambre',@cfe,@id_gest)", Form1.cx);
                            cmd4.Parameters.AddWithValue("@id_gest", Form1.id_gest);
                            cmd4.Parameters.AddWithValue("@cfe", int.Parse(textBox1.Text));

                            Form1.cx.Open();
                            cmd.ExecuteNonQuery();
                            cmd4.ExecuteNonQuery();
                            Form1.cx.Close();
                        }
                        else throw new Exception("Ce stagiaire n'habite pas dans ce buanderie.");
                    }
                    else
                    {

                        SqlCommand cmda2 = new SqlCommand("select #id_detoir,num_chambre from chambre join stagiaire on stagiaire.#id_chambre=chambre.id_chambre where cfe=" + textBox1.Text, Form1.cx);
                        Form1.cx.Open();
                        SqlDataReader dra2 = cmda2.ExecuteReader();
                        DataTable dta2 = new DataTable();
                        dta2.Load(dra2);
                        dra2.Close();
                        Form1.cx.Close();
                        if (dta2.Rows[0][0].ToString() == comboBox1.Text && dta2.Rows[0][1].ToString() == comboBox2.Text)
                        {
                            SqlCommand cmd2 = new SqlCommand("insert into respo_chambre values(getdate(),@cfe,(select max(id_chambre) from chambre where num_chambre=@chambre),@detoir) ", Form1.cx);
                            cmd2.Parameters.AddWithValue("@cfe", int.Parse(textBox1.Text));
                            cmd2.Parameters.AddWithValue("@detoir", comboBox1.Text);
                            cmd2.Parameters.AddWithValue("@chambre", comboBox2.Text);

                            SqlCommand cmd4 = new SqlCommand("insert into [dbo].[stagiaire_gestionnaire] values(getdate(),'nouveau chef chambre',@cfe,@id_gest)", Form1.cx);
                            cmd4.Parameters.AddWithValue("@id_gest", Form1.id_gest);
                            cmd4.Parameters.AddWithValue("@cfe", int.Parse(textBox1.Text));
                            Form1.cx.Open();
                            cmd2.ExecuteNonQuery();
                            cmd4.ExecuteNonQuery();
                            Form1.cx.Close();
                        }
                        else throw new Exception("Ce stagiaire n'habite pas dans cette chambre.");

                    }
                }
            }
            catch (Exception ex)
            {
                Form1.cx.Close();
                MessageBox.Show(ex.Message);
            }

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            afficher(dataGridView1.Rows.Count - 1);
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            if (l > 0)
            {
                l--;
            }
            afficher(l);
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            afficher(0);
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (l < dataGridView1.Rows.Count - 1)
            {
                l++;
            }
            afficher(l);
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("rechercher_chef_chambre", Form1.cx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cfe",textBox2.Text);
            cmd.Parameters.AddWithValue("@detoir", comboBox3.Text);
            cmd.Parameters.AddWithValue("@buanderie", i);
            cmd.Parameters.AddWithValue("@chambre", comboBox4.Text);
            cmd.Parameters.AddWithValue("@date1", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@date2", maskedTextBox2.Text);
            Form1.cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            Form1.cx.Close();
            dataGridView1.DataSource = dt;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked)
                i = 1;
            else
                i = 0;
        }
    }
}
