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
    public partial class uc_afficher_tous : UserControl
    {
        public static string type;
        public static string pension;
        public static string sexe;
        public static string detoir;
        public static string chambre;
        public static string date1;
        public static string date2;
        public static string mois;
        public static string group_fl;
        public static string nom_fl;
        public static int buanderie;

        int i = 0;
        public uc_afficher_tous()
        {
            InitializeComponent();
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
                maskedTextBox1.Enabled = true;
                maskedTextBox2.Enabled = true;
                comboBox3.Enabled = false;
            }
        
        }

        private void uc_afficher_tous_Load(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("select distinct nom_filiere from filiere ", Form1.cx);

            Form1.cx.Open();
            SqlDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dr2.Close();
            Form1.cx.Close();
            dt2.Rows.Add("Tous");
            comboBox2.DataSource = dt2;
            comboBox2.DisplayMember = "nom_filiere";
            comboBox2.Text = "Tous";

            maskedTextBox1.Enabled = false;
            maskedTextBox2.Enabled = false;
            checkBox1.Checked = true;

            comboBox4.Items.Add("Tous");
            comboBox4.Items.Add("Normal");
            comboBox4.Items.Add("Maitre");
            comboBox4.Items.Add("Exonéré");
            comboBox4.Text = "Tous";

            comboBox5.Items.Add("Tous");
            comboBox5.Items.Add("Complete");
            comboBox5.Items.Add("Demi pension");
            comboBox5.Text = "Tous";

            comboBox8.Items.Add("Tous");
            comboBox8.Items.Add('A');
            comboBox8.Items.Add('B');
            comboBox8.Items.Add('C');
            comboBox8.Items.Add('D');
            comboBox8.Text = "Tous";

            comboBox7.Items.Add("Tous");
            comboBox7.Items.Add('1');
            comboBox7.Items.Add('2');
            comboBox7.Items.Add('3');
            comboBox7.Items.Add('4');
            comboBox7.Items.Add('5');
            comboBox7.Items.Add('6');
            comboBox7.Items.Add('7');
            comboBox7.Items.Add('8');
            comboBox7.Text = "Tous";

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

            comboBox1.Items.Add("Tous");
            comboBox1.Items.Add("Garçon");
            comboBox1.Items.Add("Fille");
            comboBox1.Text = "Tous";
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
           

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked) { comboBox7.Enabled = false; i = 1; }
            else { comboBox7.Enabled = true; i = 0; }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select groupe from filiere where nom_filiere='" + comboBox2.Text + "'", Form1.cx);

            Form1.cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            Form1.cx.Close();
            dt.Rows.Add("Tous");
            comboBox6.DataSource = dt;
            comboBox6.DisplayMember = "groupe";
        }

        private void tb_connecter_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("rechercher_stagiaire", Form1.cx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@type", comboBox4.Text);
            type = comboBox4.Text;
            cmd.Parameters.AddWithValue("@pension", comboBox5.Text);
            pension = comboBox5.Text;
            cmd.Parameters.AddWithValue("@sexe", comboBox1.Text);
            sexe = comboBox1.Text;
            cmd.Parameters.AddWithValue("@nom_fl", comboBox2.Text);
            nom_fl = comboBox2.Text;
            cmd.Parameters.AddWithValue("@group_fl", comboBox6.Text);
            group_fl = comboBox6.Text;
            cmd.Parameters.AddWithValue("@date1", maskedTextBox1.Text);
            date1 = maskedTextBox1.Text;
            cmd.Parameters.AddWithValue("@date2", maskedTextBox2.Text);
            date2 = maskedTextBox2.Text;
            cmd.Parameters.AddWithValue("@detoir", comboBox8.Text);
            detoir = comboBox8.Text;
            cmd.Parameters.AddWithValue("@chambre", comboBox7.Text);
            chambre = comboBox7.Text;
            if (checkBox1.Checked)
            {
                cmd.Parameters.AddWithValue("@mois", comboBox3.Text);
                mois = comboBox3.Text;
            }
            else
            {
                cmd.Parameters.AddWithValue("@mois", "");
                mois = "";
            }
            cmd.Parameters.AddWithValue("@buanderie", i);
            buanderie = i;
            Form1.cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            Form1.cx.Close();
            dataGridView1.DataSource = dt;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            imprimer_stg f =new imprimer_stg();
            f.Show();
        }
    }
}
