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
using System.IO;

namespace Projet_Gestion_Internat
{
    public partial class uc_details_scan : UserControl
    {
        public static string tel_respo;
        DataTable dt = new DataTable();
        OpenFileDialog o = new OpenFileDialog();
        public uc_details_scan()
        {
            InitializeComponent();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fr_envoyer_sms f = new fr_envoyer_sms();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fr_exporter_carte f = new fr_exporter_carte();
            f.Show();
        }

        private void uc_details_scan_Load(object sender, EventArgs e)
        {
            SqlCommand cmd5 = new SqlCommand("select count(*) from respo_chambre join stagiaire on stagiaire.cfe=respo_chambre.#cfe  join chambre on chambre.id_chambre=respo_chambre.#id_chambre  where " + uc_scan.v_cfe.ToString() + " in (select  top 1 #cfe from respo_chambre join chambre on chambre.id_chambre=respo_chambre.#id_chambre  where chambre.id_chambre=stagiaire.#id_chambre order by date_debut_resp desc)", Form1.cx);
            SqlCommand cmd7 = new SqlCommand("select am09,am10,am11,pm12,m13,pm14,pm15,pm16,pm17,pm18 from emploi join filiere on id_filiere=Emploi.#id_filiere join stagiaire on stagiaire.#id_filiere=id_filiere where cfe=" + uc_scan.v_cfe.ToString(), Form1.cx);
            SqlCommand cmd1 = new SqlCommand("select count(*) from autorisation where #cfe=" + uc_scan.v_cfe.ToString(), Form1.cx);
            SqlCommand cmd3 = new SqlCommand("select count(*) from absence where justification_abs is null and #cfe=" + uc_scan.v_cfe.ToString(), Form1.cx);
            SqlCommand cmd4 = new SqlCommand("select count(*) from absence where justification_abs is not null and #cfe=" + uc_scan.v_cfe.ToString(), Form1.cx);
            SqlCommand cmd6 = new SqlCommand("select count(*) from sanction where #cfe=" + uc_scan.v_cfe.ToString(), Form1.cx);
            checkBox1.Checked = false;
            SqlCommand cmd2 = new SqlCommand("select count(*) from stagiaire where cfe=" + uc_scan.v_cfe.ToString() + " and #id_buanderie != null", Form1.cx);
            SqlCommand cmd43 = new SqlCommand("select pension from reçu where #cfe=" + uc_scan.v_cfe + " and date_paiement=(select max(date_paiement) from reçu where #cfe=" + uc_scan.v_cfe + ")", Form1.cx);
            Form1.cx.Open();
            SqlDataReader dr2 = cmd43.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dr2.Close();
            Form1.cx.Close();
            if (dt2.Rows[0][0].ToString() == "Demi pension") groupBox3.Enabled = false;
            Form1.cx.Open();
            SqlDataReader dr7 = cmd7.ExecuteReader();
            DataTable dt7 = new DataTable();
            dt7.Load(dr7);
            dr7.Close();
            int l = (int)cmd5.ExecuteScalar();
            int i = (int)cmd1.ExecuteScalar();
            int k = (int)cmd6.ExecuteScalar();
            int u = (int)cmd2.ExecuteScalar();
            int aj = (int)cmd4.ExecuteScalar();
            int anj = (int)cmd3.ExecuteScalar();
            Form1.cx.Close();
            richTextBox2.Text = "Il/Elle doit être dans les detoirs";
            if (DateTime.Now.DayOfWeek.ToString() == "Monday")
            {
                if (DateTime.Now.Hour.ToString() == "8") richTextBox2.Text = "Il/Elle doit être dans le restaurant pour les repas.";
                if (DateTime.Now.Hour.ToString() == "9") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[0][0].ToString();
                if (DateTime.Now.Hour.ToString() == "10") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[0][1].ToString();
                if (DateTime.Now.Hour.ToString() == "11") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[0][2].ToString();
                if (DateTime.Now.Hour.ToString() == "12") richTextBox2.Text = "Il/Elle doit être dans le restaurant pour les repas.";
                if (DateTime.Now.Hour.ToString() == "13") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[0][4].ToString();
                if (DateTime.Now.Hour.ToString() == "14") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[0][5].ToString();
                if (DateTime.Now.Hour.ToString() == "15") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[0][6].ToString();
                if (DateTime.Now.Hour.ToString() == "16") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[0][7].ToString();
                if (DateTime.Now.Hour.ToString() == "17") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[0][8].ToString();
                if (DateTime.Now.Hour.ToString() == "18") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[0][9].ToString();
                if (DateTime.Now.Hour.ToString() == "20") richTextBox2.Text = "Il/Elle doit être dans le restaurant pour les repas.";

            }
            if (DateTime.Now.DayOfWeek.ToString() == "Tuesday")
            {
                if (DateTime.Now.Hour.ToString() == "8") richTextBox2.Text = "Il/Elle doit être dans le restaurant pour les repas.";
                if (DateTime.Now.Hour.ToString() == "9") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[1][0].ToString();
                if (DateTime.Now.Hour.ToString() == "10") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[1][1].ToString();
                if (DateTime.Now.Hour.ToString() == "11") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[1][2].ToString();
                if (DateTime.Now.Hour.ToString() == "12") richTextBox2.Text = "Il/Elle doit être dans le restaurant pour les repas.";
                if (DateTime.Now.Hour.ToString() == "13") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[1][4].ToString();
                if (DateTime.Now.Hour.ToString() == "14") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[1][5].ToString();
                if (DateTime.Now.Hour.ToString() == "15") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[1][6].ToString();
                if (DateTime.Now.Hour.ToString() == "16") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[1][7].ToString();
                if (DateTime.Now.Hour.ToString() == "17") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[1][8].ToString();
                if (DateTime.Now.Hour.ToString() == "18") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[1][9].ToString();
                if (DateTime.Now.Hour.ToString() == "20") richTextBox2.Text = "Il/Elle doit être dans le restaurant pour les repas.";

            }
            if (DateTime.Now.DayOfWeek.ToString() == "Wednesday")
            {
                if (DateTime.Now.Hour.ToString() == "8") richTextBox2.Text = "Il/Elle doit être dans le restaurant pour les repas.";
                if (DateTime.Now.Hour.ToString() == "9") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[2][0].ToString();
                if (DateTime.Now.Hour.ToString() == "10") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[2][1].ToString();
                if (DateTime.Now.Hour.ToString() == "11") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[2][2].ToString();
                if (DateTime.Now.Hour.ToString() == "12") richTextBox2.Text = "Il/Elle doit être dans le restaurant pour les repas.";
                if (DateTime.Now.Hour.ToString() == "13") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[2][4].ToString();
                if (DateTime.Now.Hour.ToString() == "14") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[2][5].ToString();
                if (DateTime.Now.Hour.ToString() == "15") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[2][6].ToString();
                if (DateTime.Now.Hour.ToString() == "16") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[2][7].ToString();
                if (DateTime.Now.Hour.ToString() == "17") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[2][8].ToString();
                if (DateTime.Now.Hour.ToString() == "18") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[2][9].ToString();
                if (DateTime.Now.Hour.ToString() == "20") richTextBox2.Text = "Il/Elle doit être dans le restaurant pour les repas.";

            }
            if (DateTime.Now.DayOfWeek.ToString() == "Thursday")
            {
                if (DateTime.Now.Hour.ToString() == "8") richTextBox2.Text = "Il/Elle doit être dans le restaurant pour les repas.";
                if (DateTime.Now.Hour.ToString() == "9") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[3][0].ToString();
                if (DateTime.Now.Hour.ToString() == "10") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[3][1].ToString();
                if (DateTime.Now.Hour.ToString() == "11") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[3][2].ToString();
                if (DateTime.Now.Hour.ToString() == "12") richTextBox2.Text = "Il/Elle doit être dans le restaurant pour les repas.";
                if (DateTime.Now.Hour.ToString() == "13") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[3][4].ToString();
                if (DateTime.Now.Hour.ToString() == "14") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[3][5].ToString();
                if (DateTime.Now.Hour.ToString() == "15") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[3][6].ToString();
                if (DateTime.Now.Hour.ToString() == "16") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[3][7].ToString();
                if (DateTime.Now.Hour.ToString() == "17") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[3][8].ToString();
                if (DateTime.Now.Hour.ToString() == "18") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[3][9].ToString();
                if (DateTime.Now.Hour.ToString() == "20") richTextBox2.Text = "Il/Elle doit être dans le restaurant pour les repas.";

            }
            if (DateTime.Now.DayOfWeek.ToString() == "Friday")
            {
                if (DateTime.Now.Hour.ToString() == "8") richTextBox2.Text = "Il/Elle doit être dans le restaurant pour les repas.";
                if (DateTime.Now.Hour.ToString() == "9") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[4][0].ToString();
                if (DateTime.Now.Hour.ToString() == "10") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[4][1].ToString();
                if (DateTime.Now.Hour.ToString() == "11") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[4][2].ToString();
                if (DateTime.Now.Hour.ToString() == "12") richTextBox2.Text = "Il/Elle doit être dans le restaurant pour les repas.";
                if (DateTime.Now.Hour.ToString() == "13") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[4][4].ToString();
                if (DateTime.Now.Hour.ToString() == "14") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[4][5].ToString();
                if (DateTime.Now.Hour.ToString() == "15") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[4][6].ToString();
                if (DateTime.Now.Hour.ToString() == "16") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[4][7].ToString();
                if (DateTime.Now.Hour.ToString() == "17") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[4][8].ToString();
                if (DateTime.Now.Hour.ToString() == "18") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[4][9].ToString();
                if (DateTime.Now.Hour.ToString() == "20") richTextBox2.Text = "Il/Elle doit être dans le restaurant pour les repas.";

            }
            if (DateTime.Now.DayOfWeek.ToString() == "Saturday")
            {
                if (DateTime.Now.Hour.ToString() == "8") richTextBox2.Text = "Il/Elle doit être dans le restaurant pour les repas.";
                if (DateTime.Now.Hour.ToString() == "9") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[5][0].ToString();
                if (DateTime.Now.Hour.ToString() == "10") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[5][1].ToString();
                if (DateTime.Now.Hour.ToString() == "11") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[5][2].ToString();
                if (DateTime.Now.Hour.ToString() == "12") richTextBox2.Text = "Il/Elle doit être dans le restaurant pour les repas.";
                if (DateTime.Now.Hour.ToString() == "13") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[5][4].ToString();
                if (DateTime.Now.Hour.ToString() == "14") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[5][5].ToString();
                if (DateTime.Now.Hour.ToString() == "15") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[5][6].ToString();
                if (DateTime.Now.Hour.ToString() == "16") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[5][7].ToString();
                if (DateTime.Now.Hour.ToString() == "17") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[5][8].ToString();
                if (DateTime.Now.Hour.ToString() == "18") richTextBox2.Text = "Il/Elle doit être dans le " + dt7.Rows[5][9].ToString();
                if (DateTime.Now.Hour.ToString() == "20") richTextBox2.Text = "Il/Elle doit être dans le restaurant pour les repas.";

            }
            if (DateTime.Now.DayOfWeek.ToString() == "Sunday")
            {
                richTextBox2.Text = "Il/Elle doit être dehors l'etablissement parceque c'est dimanche.";
            }


            if (l > 0) label30.Text = label30.Text + " OUI";
            else label30.Text = label30.Text + " NON";
            label28.Text = label28.Text + " " + i.ToString();
            label27.Text = label27.Text + " " + k.ToString();
            label25.Text = label25.Text + " " + aj.ToString();
            label26.Text = label26.Text + " " + anj.ToString();
            label32.Text = label32.Text + " " + (aj + anj).ToString();
            SqlCommand cmd;
            if (u > 0)
                cmd = new SqlCommand("select nom ,prenom ,sexe ,telephone ,nationalité, type_stagiaire,nom_filiere,niveau,groupe,annee,datenaissance,Rue,ville,cp,nom_respo,prenom_respo,sexe_respo,tel_respo,lien,buanderie.#id_detoir,photo,buanderie.num_lit,buanderie.num_armoire,QR_code from stagiaire join filiere on stagiaire.#id_filiere=filiere.id_filiere full outer join buanderie on stagiaire.#id_buanderie=buanderie.id_buanderie where cfe=" + uc_scan.v_cfe.ToString(), Form1.cx);

            else
                cmd = new SqlCommand("select nom ,prenom  ,sexe ,telephone ,nationalité, type_stagiaire,nom_filiere,niveau,groupe,annee,datenaissance,Rue,ville,cp,nom_respo,prenom_respo,sexe_respo,tel_respo,lien,chambre.#id_detoir,photo,num_chambre,chambre.num_lit,chambre.num_armoire,QR_code from stagiaire join filiere on stagiaire.#id_filiere=filiere.id_filiere full outer join chambre  on stagiaire.#id_chambre=chambre.id_chambre where cfe=" + uc_scan.v_cfe.ToString(), Form1.cx);

            Form1.cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            dr.Close();
            Form1.cx.Close();

            textBox1.Text = uc_scan.v_cfe.ToString();
            textBox2.Text = dt.Rows[0][0].ToString();
            textBox3.Text = dt.Rows[0][1].ToString();
            comboBox1.Text = dt.Rows[0][2].ToString();
            textBox4.Text = dt.Rows[0][3].ToString();
            textBox5.Text = dt.Rows[0][4].ToString();
            comboBox2.Text = dt.Rows[0][5].ToString();
            comboBox4.Text = dt.Rows[0][6].ToString();
            comboBox6.Text = dt.Rows[0][7].ToString();
            comboBox5.Text = dt.Rows[0][8].ToString();
            comboBox11.Text = dt.Rows[0][9].ToString();
            maskedTextBox1.Text = dt.Rows[0][10].ToString();
            richTextBox1.Text = dt.Rows[0][11].ToString();
            textBox9.Text = dt.Rows[0][12].ToString();
            textBox10.Text = dt.Rows[0][13].ToString();
            textBox8.Text = dt.Rows[0][14].ToString();
            textBox11.Text = dt.Rows[0][15].ToString();
            comboBox3.Text = dt.Rows[0][16].ToString();
            textBox12.Text = dt.Rows[0][17].ToString();
            textBox13.Text = dt.Rows[0][18].ToString();
            comboBox7.Text = dt.Rows[0][19].ToString();
            if (DBNull.Value.ToString() == dt.Rows[0][20].ToString())
            {
                if (dt.Rows[0][2].ToString() == "Garçon")
                    pictureBox1.Load(Application.StartupPath + @"\facebookprofilepic.jpg");
                else
                    pictureBox1.Load(Application.StartupPath + @"\femme.jpg");
            }
            else
            {
                byte[] temp = (byte[])dt.Rows[0][20];
                MemoryStream stream = new MemoryStream(temp);
                stream.Write(temp, 0, temp.Length);
                pictureBox1.Image = Image.FromStream(stream);
            }
            if (u > 0)
            {
                checkBox1.Checked = true;
                comboBox8.Enabled = false;
                comboBox9.Text = dt.Rows[0][21].ToString();
                comboBox10.Text = dt.Rows[0][22].ToString();
            }
            else
            {

                comboBox8.Text = dt.Rows[0][21].ToString();
                comboBox9.Text = dt.Rows[0][22].ToString();
                comboBox10.Text = dt.Rows[0][23].ToString();
            }

            SqlCommand cd = new SqlCommand("select [#num_contribution] from contribution_reçu join reçu on contribution_reçu.[#num_reçu]=reçu.[num_reçu] where #cfe=" + uc_scan.v_cfe.ToString(), Form1.cx);
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
            foreach (DataRow r in dtb.Rows)
            {
                if (checkBox6.Checked == false)
                    checkBox6.Enabled = false;
                if (checkBox11.Checked == false)
                    checkBox11.Enabled = false;
                if (checkBox7.Checked == false)
                    checkBox7.Enabled = false;
                if (checkBox8.Checked == false)
                    checkBox8.Enabled = false;
                if (checkBox9.Checked == false)
                    checkBox9.Enabled = false;
                if (checkBox2.Checked == false)
                    checkBox2.Enabled = false;
                if (checkBox10.Checked == false)
                    checkBox10.Enabled = false;
                if (checkBox3.Checked == false)
                    checkBox3.Enabled = false;
                if (checkBox4.Checked == false)
                    checkBox4.Enabled = false;
                if (checkBox5.Checked == false)
                    checkBox5.Enabled = false;
                tel_respo = textBox12.Text;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            fr_exporter_carte f = new fr_exporter_carte();
            f.Show();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            fr_envoyer_sms f = new fr_envoyer_sms();
            f.Show();
        }
    }
}
