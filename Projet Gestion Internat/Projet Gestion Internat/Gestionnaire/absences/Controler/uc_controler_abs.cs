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
    public partial class uc_controler_abs : UserControl
    {

        int i=0; bool b = true;
        public uc_controler_abs()
        {
            InitializeComponent();
        }

        private void uc_controler_abs_Load(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("select distinct nom_filiere from filiere ", Form1.cx);

            Form1.cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            Form1.cx.Close();
            dt.Rows.Add("Tous");
            comboBox5.DataSource = dt;
            comboBox5.DisplayMember = "nom_filiere";
            
            comboBox5.Text = "Tous";
            comboBox1.Items.Add("Tous");
            comboBox1.Items.Add("Repas");
            comboBox1.Items.Add("Detoir");
            comboBox3.Items.Add("Tous");
            comboBox3.Items.Add('A');
            comboBox3.Items.Add('B');
            comboBox3.Items.Add('C');
            comboBox3.Items.Add('D');
            comboBox2.Items.Add("Tous");
            comboBox2.Items.Add(1);
            comboBox2.Items.Add(2);
            comboBox2.Items.Add(3);
            comboBox2.Items.Add(4);
            comboBox2.Items.Add(5);
            comboBox2.Items.Add(6);
            comboBox2.Items.Add(7);
            comboBox2.Items.Add(8);
            comboBox1.Text = "Tous";
            comboBox2.Text = "Tous";
            comboBox3.Text = "Tous";
            comboBox4.Text = "Tous";


            SqlCommand cmd2 = new SqlCommand("controler_abs", Form1.cx);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@type", "Tous");
            cmd2.Parameters.AddWithValue("@detoir", "Tous");
            cmd2.Parameters.AddWithValue("@chambre", "Tous");
            cmd2.Parameters.AddWithValue("@buanderie", i);
            cmd2.Parameters.AddWithValue("@nom_fl", "Tous");
            cmd2.Parameters.AddWithValue("@group_fl", "Tous");
            Form1.cx.Open();
            DataTable dt2 = new DataTable();
            SqlDataReader dr2 = cmd2.ExecuteReader();
            dt2.Load(dr2);
            dr2.Close();
            Form1.cx.Close();
            dataGridView1.DataSource = dt2;

            b = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { comboBox2.Enabled = false; i = 1; }
            else
            {
                i = 0;
                comboBox2.Text = "";
                comboBox2.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (b == false)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("controler_abs", Form1.cx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@type", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@detoir", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@chambre", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@buanderie", i);
                    cmd.Parameters.AddWithValue("@nom_fl", comboBox5.Text);
                    cmd.Parameters.AddWithValue("@group_fl", comboBox4.Text);
                    Form1.cx.Open();
                    DataTable dt = new DataTable();
                    SqlDataReader dr = cmd.ExecuteReader();
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

        private void button2_Click(object sender, EventArgs e)
        {

            if (b == false)
            {

                Form1.cx.Open();
                SqlTransaction tr;
                tr = Form1.cx.BeginTransaction();
                try
                {
                    if (comboBox1.Text == "Tous") throw new Exception("Vous devez spécifier le type d'absence");

                    foreach (DataGridViewRow r in dataGridView1.Rows)
                    {

                        if (Convert.ToBoolean(r.Cells[0].Value).ToString() == "True")
                        {

                            
                            SqlCommand cmd2 = new SqlCommand("select count(*) from autorisation join stagiaire on stagiaire.cfe=autorisation.#cfe where dateadd(day,duree_autorisation,date_autorisation)>getdate() and #cfe=" + int.Parse(r.Cells[4].Value.ToString()), Form1.cx);
                            cmd2.Transaction = tr;
                            int a = (int)cmd2.ExecuteScalar();
                           
                            SqlCommand cmd3 = new SqlCommand("select count(*) from sanction join stagiaire on stagiaire.cfe=sanction.#cfe where dateadd(day,duree_sanc,date_sanc)>getdate() and #cfe=" + int.Parse(r.Cells[4].Value.ToString()), Form1.cx);
                            cmd3.Transaction = tr;
                            int s = (int)cmd3.ExecuteScalar();

                            SqlCommand cmd = new SqlCommand("insert into absence values(@type,getdate(),@des_abs,datename(hour,getdate()) + ':' + datename(minute,getdate()),@justification_abs,@id_gest,cast(@cfe as bigint))", Form1.cx);
                            cmd.Parameters.AddWithValue("@type", comboBox1.Text);

                            if(r.Cells[1].Value==null)
                            cmd.Parameters.AddWithValue("@des_abs", "");
                            else
                            cmd.Parameters.AddWithValue("@des_abs", r.Cells[1].Value.ToString());

                            if (a > 0)
                                cmd.Parameters.AddWithValue("@justification_abs", "Il/Elle était autorisé(e)");
                            else if (s > 0)
                                cmd.Parameters.AddWithValue("@justification_abs", "Il/Elle était sanctioné(e)");
                            else
                            {
                                if(r.Cells[2].Value==null)
                                    cmd.Parameters.AddWithValue("@justification_abs", "");
                                else
                                    cmd.Parameters.AddWithValue("@justification_abs", r.Cells[2].Value.ToString());
                            }

                            cmd.Parameters.AddWithValue("@cfe", r.Cells[4].Value.ToString());
                            cmd.Parameters.AddWithValue("@id_gest", Form1.id_gest);

                            SqlCommand cmd4 = new SqlCommand("insert into [dbo].[stagiaire_gestionnaire] values(getdate(),'Sanction',@cfe,@id_gest)", Form1.cx);
                            cmd4.Parameters.AddWithValue("@id_gest", Form1.id_gest);
                            cmd4.Parameters.AddWithValue("@cfe", int.Parse(r.Cells[4].Value.ToString()));
                            cmd.Transaction = tr;
                            cmd4.Transaction = tr;

                            cmd4.ExecuteNonQuery();
                            cmd.ExecuteNonQuery();

                            





                        }
                        
                    }
                    tr.Commit();
                    Form1.cx.Close();
                    MessageBox.Show("Les stagiaires séléctionnés sont enregistrés dans la liste des absents");
                }

                catch (Exception ex)
                {
                    tr.Rollback();
                    Form1.cx.Close();
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (b == false)
            {
                SqlCommand cmd = new SqlCommand("select groupe from filiere where nom_filiere='" + comboBox5.Text + "'", Form1.cx);

                Form1.cx.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();
                Form1.cx.Close();
                dt.Rows.Add("Tous");
                comboBox4.DataSource = dt;
                comboBox4.DisplayMember = "groupe";
                if (comboBox5.Text == "Tous")
                {
                    comboBox4.Text = "Tous";
                }
            }
        }

        private void tb_connecter_Click(object sender, EventArgs e)
        {
            if (b == false)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("controler_abs", Form1.cx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@type", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@detoir", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@chambre", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@buanderie", i);
                    cmd.Parameters.AddWithValue("@nom_fl", comboBox5.Text);
                    cmd.Parameters.AddWithValue("@group_fl", comboBox4.Text);
                    Form1.cx.Open();
                    DataTable dt = new DataTable();
                    SqlDataReader dr = cmd.ExecuteReader();
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

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (b == false)
            {

                Form1.cx.Open();
                SqlTransaction tr;
                tr = Form1.cx.BeginTransaction();
                try
                {
                    if (comboBox1.Text == "Tous") throw new Exception("Vous devez spécifier le type d'absence");

                    foreach (DataGridViewRow r in dataGridView1.Rows)
                    {

                        if (Convert.ToBoolean(r.Cells[0].Value).ToString() == "True")
                        {


                            SqlCommand cmd2 = new SqlCommand("select count(*) from autorisation join stagiaire on stagiaire.cfe=autorisation.#cfe where dateadd(day,duree_autorisation,date_autorisation)>getdate() and #cfe=" + int.Parse(r.Cells[4].Value.ToString()), Form1.cx);
                            cmd2.Transaction = tr;
                            int a = (int)cmd2.ExecuteScalar();

                            SqlCommand cmd3 = new SqlCommand("select count(*) from sanction join stagiaire on stagiaire.cfe=sanction.#cfe where dateadd(day,duree_sanc,date_sanc)>getdate() and #cfe=" + int.Parse(r.Cells[4].Value.ToString()), Form1.cx);
                            cmd3.Transaction = tr;
                            int s = (int)cmd3.ExecuteScalar();

                            SqlCommand cmd = new SqlCommand("insert into absence values(@type,getdate(),@des_abs,datename(hour,getdate()) + ':' + datename(minute,getdate()),@justification_abs,@id_gest,cast(@cfe as bigint))", Form1.cx);
                            cmd.Parameters.AddWithValue("@type", comboBox1.Text);

                            if (r.Cells[1].Value == null)
                                cmd.Parameters.AddWithValue("@des_abs", "");
                            else
                                cmd.Parameters.AddWithValue("@des_abs", r.Cells[1].Value.ToString());

                            if (a > 0)
                                cmd.Parameters.AddWithValue("@justification_abs", "Il/Elle était autorisé(e)");
                            else if (s > 0)
                                cmd.Parameters.AddWithValue("@justification_abs", "Il/Elle était sanctioné(e)");
                            else
                            {
                                if (r.Cells[2].Value == null)
                                    cmd.Parameters.AddWithValue("@justification_abs", "");
                                else
                                    cmd.Parameters.AddWithValue("@justification_abs", r.Cells[2].Value.ToString());
                            }

                            cmd.Parameters.AddWithValue("@cfe", r.Cells[4].Value.ToString());
                            cmd.Parameters.AddWithValue("@id_gest", Form1.id_gest);

                            SqlCommand cmd4 = new SqlCommand("insert into [dbo].[stagiaire_gestionnaire] values(getdate(),'Sanction',@cfe,@id_gest)", Form1.cx);
                            cmd4.Parameters.AddWithValue("@id_gest", Form1.id_gest);
                            cmd4.Parameters.AddWithValue("@cfe", int.Parse(r.Cells[4].Value.ToString()));
                            cmd.Transaction = tr;
                            cmd4.Transaction = tr;

                            cmd4.ExecuteNonQuery();
                            cmd.ExecuteNonQuery();







                        }

                    }
                    tr.Commit();
                    Form1.cx.Close();
                    MessageBox.Show("Les stagiaires séléctionnés sont enregistrés dans la liste des absents");
                }

                catch (Exception ex)
                {
                    tr.Rollback();
                    Form1.cx.Close();
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
    }
        
    
