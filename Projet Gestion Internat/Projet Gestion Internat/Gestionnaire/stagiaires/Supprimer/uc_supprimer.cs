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
    public partial class uc_supprimer : UserControl
    {

        DataTable dt = new DataTable();
        OpenFileDialog o = new OpenFileDialog();
        public uc_supprimer()
        {
            InitializeComponent();
        }

        private void uc_supprimer_Load(object sender, EventArgs e)
        {
            SqlCommand cmd43 = new SqlCommand("select pension from reçu where #cfe=" + uc_scan.v_cfe + " and date_paiement=(select max(date_paiement) from reçu where #cfe=" + uc_scan.v_cfe + ")", Form1.cx);
            SqlCommand cmd2 = new SqlCommand("select count(*) from stagiaire where cfe=" + uc_scan.v_cfe.ToString() + " and #id_buanderie != null", Form1.cx);
            Form1.cx.Open();
            SqlDataReader dr2 = cmd43.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dr2.Close();
            int u = (int)cmd2.ExecuteScalar();
            Form1.cx.Close();
            if (dt2.Rows[0][0].ToString() == "Demi pension") groupBox3.Enabled = false;
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Vous êtes sûre de vouloir supprimer ce stagiaire ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("delete stagiaire where cfe=" +uc_scan.v_cfe, Form1.cx);
                Form1.cx.Open();
                cmd.ExecuteNonQuery();
                Form1.cx.Close();
                this.Controls.Clear();
                MessageBox.Show("Ce stagiaire a été supprimé(e).");
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

            DialogResult r = MessageBox.Show("Vous êtes sûre de vouloir supprimer ce stagiaire ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("delete stagiaire where cfe=" + uc_scan.v_cfe, Form1.cx);
                Form1.cx.Open();
                cmd.ExecuteNonQuery();
                Form1.cx.Close();
                this.Controls.Clear();
                MessageBox.Show("Ce stagiaire a été supprimé(e).");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
