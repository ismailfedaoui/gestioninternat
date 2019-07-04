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
    public partial class fr_modifier_p : Form
    {
        bool b = true;
        public fr_modifier_p()
        {
            InitializeComponent();
        }

        private void fr_modifier_p_Load(object sender, EventArgs e)
        {
            try {
                comboBox1.Items.Add("Complete");
                comboBox1.Items.Add("Demi pension");

            if (uc_modifier.tous == "oui")
            {
                SqlCommand cmd = new SqlCommand("select num_reçu from reçu where #cfe=" + uc_scan.v_cfe, Form1.cx);
                Form1.cx.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();
                Form1.cx.Close();
                comboBox12.DataSource = dt;
                comboBox12.DisplayMember = "num_reçu";
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select [numreçu_a_modifier] from gestionnaire where id_gest=" + Form1.id_gest, Form1.cx);
                Form1.cx.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();
                Form1.cx.Close();

                SqlCommand cmd3 = new SqlCommand("select count(*) from reçu where num_reçu ='" + dt.Rows[0][0].ToString() + "' and #cfe=" + uc_scan.v_cfe.ToString(), Form1.cx);
                Form1.cx.Open();
                int i = (int)cmd3.ExecuteScalar();
                Form1.cx.Close();

                if (i == 0) throw new Exception("Ce numero  de reçu n'est pas parmi les numéros de reçus de ce stagiaire");
                comboBox12.Text = dt.Rows[0][0].ToString();
            } }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            b = false;
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.cx.Open();
            SqlTransaction tr;
            tr = Form1.cx.BeginTransaction();
            try
            {
                SqlCommand cmd8 = new SqlCommand("select num_reçu from reçu where date_paiement=(select min(date_paiement) from reçu join stagiaire on cfe=#cfe where cfe=@cfe)", Form1.cx);
                cmd8.Parameters.AddWithValue("@cfe", uc_scan.v_cfe);
                cmd8.Transaction = tr;
                SqlDataReader dr8 = cmd8.ExecuteReader();
                DataTable dt8 = new DataTable();
                dt8.Load(dr8);
                dr8.Close();

                int nombre_mois = 0;
                List<int> l_mois = new List<int>();
                if (checkBox2.Checked) { nombre_mois++; l_mois.Add(6); }
                if (checkBox3.Checked) { nombre_mois++; l_mois.Add(11); }
                if (checkBox4.Checked) { nombre_mois++; l_mois.Add(10); }
                if (checkBox5.Checked) { nombre_mois++; l_mois.Add(12); }
                if (checkBox6.Checked) { nombre_mois++; l_mois.Add(1); }
                if (checkBox7.Checked) { nombre_mois++; l_mois.Add(3); }
                if (checkBox8.Checked) { nombre_mois++; l_mois.Add(4); }
                if (checkBox9.Checked) { nombre_mois++; l_mois.Add(5); }
                if (checkBox10.Checked) { nombre_mois++; l_mois.Add(9); }
                if (checkBox11.Checked) { nombre_mois++; l_mois.Add(2); }

                if (dt8.Rows[0][0].ToString() == comboBox12.Text)
                {
                    if (((int.Parse(textBox13.Text) - 100) / nombre_mois) != 200 & comboBox1.Text == "Complete")
                    {
                        throw new Exception("Vous devez saisir un montant correspondant pour le nombre des mois séléctionées (200Dhs/Mois + 100DHs) parceque c'est son premier numéro de reçu.");
                    }
                    else if (((int.Parse(textBox13.Text) - 100) / nombre_mois) != 100 & comboBox1.Text == "Demi pension")
                    {
                        throw new Exception("Vous devez saisir un montant correspondant pour le nombre des mois séléctionées (100Dhs/Mois + 100DHs) parceque c'est son premier numéro de reçu.");
                    }
                }
                else
                {
                    if ((int.Parse(textBox13.Text) / nombre_mois) != 200 & comboBox1.Text == "Complete")
                    {
                        throw new Exception("Vous devez saisir un montant correspondant pour le nombre des mois séléctionées (200Dhs/Mois).");
                    }
                    else if ((int.Parse(textBox13.Text) / nombre_mois) != 100 & comboBox1.Text == "Demi pension")
                    {
                        throw new Exception("Vous devez saisir un montant correspondant pour le nombre des mois séléctionées (100Dhs/Mois).");
                    }
                }


                SqlCommand cmd = new SqlCommand("update reçu set montant=@montant,pension=@pension where num_reçu='" + comboBox12.Text + "'", Form1.cx);
               
                cmd.Parameters.AddWithValue("@montant", textBox13.Text);
                cmd.Parameters.AddWithValue("@pension", comboBox1.Text);
                cmd.Transaction = tr;
                cmd.ExecuteNonQuery();
                

                SqlCommand cmd2 = new SqlCommand("delete from contribution_reçu where #num_reçu='" + comboBox12.Text + "'", Form1.cx);
                cmd2.Transaction = tr;
                cmd2.ExecuteNonQuery();

                foreach (int i in l_mois)
                {
                    SqlCommand cmd3 = new SqlCommand("insert into contribution_reçu values(" + i + ",'" + comboBox12.Text + "')", Form1.cx);
                    cmd3.Transaction = tr;
                    cmd3.ExecuteNonQuery();

                }
                tr.Commit();
                MessageBox.Show("ce reçu a été bien modifié");
                Form1.cx.Close();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                Form1.cx.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox12_Click(object sender, EventArgs e)
        {
              if (b == false)
            {
               
                SqlCommand cmd2 = new SqlCommand("select date_paiement,montant,pension from reçu where num_reçu='" + comboBox12.Text + "'", Form1.cx);
                Form1.cx.Open();
                SqlDataReader dr2 = cmd2.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(dr2);
                Form1.cx.Close();
                maskedTextBox1.Text = dt2.Rows[0][0].ToString();
                textBox13.Text = dt2.Rows[0][1].ToString();
                comboBox1.Text = dt2.Rows[0][2].ToString();
                SqlCommand cd = new SqlCommand("select [#num_contribution] from contribution_reçu join reçu on contribution_reçu.[#num_reçu]=reçu.[num_reçu] where #num_reçu=@reçu and #cfe=" + uc_scan.v_cfe.ToString(), Form1.cx);
                cd.Parameters.AddWithValue("@reçu", comboBox12.Text);
                Form1.cx.Open();
                SqlDataReader sdr = cd.ExecuteReader();
                DataTable dtb = new DataTable();
                dtb.Load(sdr);
                sdr.Close();
                Form1.cx.Close();
                foreach (DataRow r in dtb.Rows)
                {
                    if (r[0].ToString() == "1") checkBox6.Checked = true;

                    if (r[0].ToString() == "2") checkBox11.Checked = true;

                    if (r[0].ToString() == "3") checkBox7.Checked = true;

                    if (r[0].ToString() == "4") checkBox8.Checked = true;

                    if (r[0].ToString() == "5") checkBox9.Checked = true;

                    if (r[0].ToString() == "6") checkBox2.Checked = true;

                    if (r[0].ToString() == "9") checkBox10.Checked = true;

                    if (r[0].ToString() == "10") checkBox3.Checked = true;

                    if (r[0].ToString() == "11") checkBox4.Checked = true;

                    if (r[0].ToString() == "12") checkBox5.Checked = true;

                }
               
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Form1.cx.Open();
            SqlTransaction tr;
            tr = Form1.cx.BeginTransaction();
            try
            {
                SqlCommand cmd8 = new SqlCommand("select num_reçu from reçu where date_paiement=(select min(date_paiement) from reçu join stagiaire on cfe=#cfe where cfe=@cfe)", Form1.cx);
                cmd8.Parameters.AddWithValue("@cfe", uc_scan.v_cfe);
                cmd8.Transaction = tr;
                SqlDataReader dr8 = cmd8.ExecuteReader();
                DataTable dt8 = new DataTable();
                dt8.Load(dr8);
                dr8.Close();

                int nombre_mois = 0;
                List<int> l_mois = new List<int>();
                if (checkBox2.Checked) { nombre_mois++; l_mois.Add(6); }
                if (checkBox3.Checked) { nombre_mois++; l_mois.Add(11); }
                if (checkBox4.Checked) { nombre_mois++; l_mois.Add(10); }
                if (checkBox5.Checked) { nombre_mois++; l_mois.Add(12); }
                if (checkBox6.Checked) { nombre_mois++; l_mois.Add(1); }
                if (checkBox7.Checked) { nombre_mois++; l_mois.Add(3); }
                if (checkBox8.Checked) { nombre_mois++; l_mois.Add(4); }
                if (checkBox9.Checked) { nombre_mois++; l_mois.Add(5); }
                if (checkBox10.Checked) { nombre_mois++; l_mois.Add(9); }
                if (checkBox11.Checked) { nombre_mois++; l_mois.Add(2); }

                if (dt8.Rows[0][0].ToString() == comboBox12.Text)
                {
                    if (((int.Parse(textBox13.Text) - 100) / nombre_mois) != 200 & comboBox1.Text == "Complete")
                    {
                        throw new Exception("Vous devez saisir un montant correspondant pour le nombre des mois séléctionées (200Dhs/Mois + 100DHs) parceque c'est son premier numéro de reçu.");
                    }
                    else if (((int.Parse(textBox13.Text) - 100) / nombre_mois) != 100 & comboBox1.Text == "Demi pension")
                    {
                        throw new Exception("Vous devez saisir un montant correspondant pour le nombre des mois séléctionées (100Dhs/Mois + 100DHs) parceque c'est son premier numéro de reçu.");
                    }
                }
                else
                {
                    if ((int.Parse(textBox13.Text) / nombre_mois) != 200 & comboBox1.Text == "Complete")
                    {
                        throw new Exception("Vous devez saisir un montant correspondant pour le nombre des mois séléctionées (200Dhs/Mois).");
                    }
                    else if ((int.Parse(textBox13.Text) / nombre_mois) != 100 & comboBox1.Text == "Demi pension")
                    {
                        throw new Exception("Vous devez saisir un montant correspondant pour le nombre des mois séléctionées (100Dhs/Mois).");
                    }
                }


                SqlCommand cmd = new SqlCommand("update reçu set montant=@montant,pension=@pension where num_reçu='" + comboBox12.Text + "'", Form1.cx);

                cmd.Parameters.AddWithValue("@montant", textBox13.Text);
                cmd.Parameters.AddWithValue("@pension", comboBox1.Text);
                cmd.Transaction = tr;
                cmd.ExecuteNonQuery();


                SqlCommand cmd2 = new SqlCommand("delete from contribution_reçu where #num_reçu='" + comboBox12.Text + "'", Form1.cx);
                cmd2.Transaction = tr;
                cmd2.ExecuteNonQuery();

                foreach (int i in l_mois)
                {
                    SqlCommand cmd3 = new SqlCommand("insert into contribution_reçu values(" + i + ",'" + comboBox12.Text + "')", Form1.cx);
                    cmd3.Transaction = tr;
                    cmd3.ExecuteNonQuery();

                }
                tr.Commit();
                MessageBox.Show("ce reçu a été bien modifié");
                Form1.cx.Close();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                Form1.cx.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
