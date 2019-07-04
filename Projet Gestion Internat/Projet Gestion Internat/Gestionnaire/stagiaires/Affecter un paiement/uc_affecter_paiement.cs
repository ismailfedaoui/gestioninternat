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
    public partial class uc_affecter_paiement : UserControl
    {
        int i;
        public uc_affecter_paiement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    
        private void uc_affecter_paiement_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Add("Complete");
            comboBox2.Items.Add("Demi pension");
            SqlCommand cmd2 = new SqlCommand("select count(*) from stagiaire", Form1.cx);
            Form1.cx.Open();
            i = (int)cmd2.ExecuteScalar();
            Form1.cx.Close();
        }

        private void tb_connecter_Click(object sender, EventArgs e)
        {

            try
            {


                int nombre_mois = 0;
                List<int> l_mois = new List<int>();
                if (checkBox2.Checked) { nombre_mois++; l_mois.Add(11); }
                if (checkBox3.Checked) { nombre_mois++; l_mois.Add(10); }
                if (checkBox4.Checked) { nombre_mois++; l_mois.Add(12); }
                if (checkBox5.Checked) { nombre_mois++; l_mois.Add(1); }
                if (checkBox6.Checked) { nombre_mois++; l_mois.Add(2); }
                if (checkBox7.Checked) { nombre_mois++; l_mois.Add(3); }
                if (checkBox8.Checked) { nombre_mois++; l_mois.Add(4); }
                if (checkBox9.Checked) { nombre_mois++; l_mois.Add(5); }
                if (checkBox10.Checked) { nombre_mois++; l_mois.Add(9); }
                if (checkBox1.Checked) { nombre_mois++; l_mois.Add(6); }

                if ((int.Parse(textBox2.Text) / nombre_mois) != 200 & comboBox2.Text == "Complete")
                {
                    throw new Exception("Vous devez saisir un montant correspondant pour le nombre des mois séléctionées (200Dhs/Mois).");
                }
                else if ((int.Parse(textBox2.Text) / nombre_mois) != 100 & comboBox2.Text == "Demi pension")
                {
                    throw new Exception("Vous devez saisir un montant correspondant pour le nombre des mois séléctionées (100Dhs/Mois).");
                }

                else if (i > 144) throw new Exception("Tous les chambres et les buanderies sont saturés.");
                else
                {

                    SqlCommand cmd2 = new SqlCommand("insert into reçu values(@num_r,@date_paiement,@montant,@pension,@cfe,@nombre_mois)", Form1.cx);
                    cmd2.Parameters.AddWithValue("@num_r", textBox1.Text);
                    cmd2.Parameters.AddWithValue("@date_paiement", dateTimePicker1.Value.ToShortDateString());
                    cmd2.Parameters.AddWithValue("@montant", int.Parse(textBox2.Text));
                    cmd2.Parameters.AddWithValue("@pension", comboBox2.Text);
                    cmd2.Parameters.AddWithValue("@cfe", uc_scan.v_cfe);
                    cmd2.Parameters.AddWithValue("@nombre_mois", nombre_mois);
                    SqlCommand cmd3 = new SqlCommand("insert into stagiaire_gestionnaire values(getdate(),'Nouveau paiement',@cfe,@id_gest)", Form1.cx);
                    cmd3.Parameters.AddWithValue("@cfe", uc_scan.v_cfe);
                    cmd3.Parameters.AddWithValue("@id_gest", Form1.id_gest);
                    Form1.cx.Open();
                    cmd2.ExecuteNonQuery();
                    foreach (int i in l_mois)
                    {
                        SqlCommand cmd5 = new SqlCommand("insert into contribution_reçu values(" + i + ",'" + textBox1.Text + "')", Form1.cx);

                        cmd3.ExecuteNonQuery();

                    }
                    Form1.cx.Close();
                }

            }

            catch (Exception ex)
            {
                Form1.cx.Close();
                MessageBox.Show(ex.Message);
            }



        }

        private void label7_Click(object sender, EventArgs e)
        {
            
        }

        private void label7_Click_1(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            uc_rapport_contr uc_rapport_contr = new uc_rapport_contr();
            panel1.Controls.Add(uc_rapport_contr);
        }

        private void tb_connecter_Click_1(object sender, EventArgs e)
        {

        }
    } }