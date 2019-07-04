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
    public partial class uc_gestionnaires : UserControl
    {
        int l = -1;
        string opertion = "";
        DataTable dt = new DataTable();
        OpenFileDialog o = new OpenFileDialog();
        bool b;
        public uc_gestionnaires()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (l < dt.Rows.Count - 1)
            {
                l++;
            }
            afficher(l);
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            afficher(dt.Rows.Count - 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (l > 0)
            {
                l--;
            }
            afficher(l);

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                opertion = "ajouter";
                   SqlCommand cmd2 = new SqlCommand("select count(*) from gestionnaire where pseudo='" + textBox6.Text + "'", Form1.cx);
                Form1.cx.Open();
                int i = (int)cmd2.ExecuteScalar();
                Form1.cx.Close();
                if(i > 0) throw new Exception("Vous ne peuvez pas créer des comptes de gestionnaires avec le même Pseudo.");
                SqlCommand cmd = new SqlCommand("insert into gestionnaire values(@nom,@prenom,@sexe,@tel,@pseudo,@mdp,@photo,getdate(),null,1,@autoriser_tous_r,@autoriser_r)", Form1.cx);
                cmd.Parameters.AddWithValue("@nom", textBox1.Text);
                cmd.Parameters.AddWithValue("@prenom", textBox2.Text);
                cmd.Parameters.AddWithValue("@sexe", comboBox1.Text);
                cmd.Parameters.AddWithValue("@tel", textBox3.Text);
                cmd.Parameters.AddWithValue("@pseudo", textBox6.Text);
                cmd.Parameters.AddWithValue("@mdp", textBox7.Text);
                if (checkBox2.Checked) cmd.Parameters.AddWithValue("@autoriser_r", textBox5.Text);
                else cmd.Parameters.AddWithValue("@autoriser_r", "");
                if (checkBox1.Checked) cmd.Parameters.AddWithValue("@autoriser_tous_r", "Oui");
                else cmd.Parameters.AddWithValue("@autoriser_tous_r", "Non");
                cmd.Parameters.Add("@photo", SqlDbType.VarBinary);
                if (o.FileName != "")
                {
                    FileStream fs = new FileStream(o.FileName, FileMode.Open, FileAccess.Read);
                    byte[] t = new byte[fs.Length];
                    fs.Read(t, 0, (int)fs.Length);
                    cmd.Parameters["@photo"].Value = t;
                }
                else
                    cmd.Parameters["@photo"].Value = DBNull.Value;
                Form1.cx.Open();
                cmd.ExecuteNonQuery();
                Form1.cx.Close();
            }
            catch(Exception ex)
            {
                Form1.cx.Close();
                MessageBox.Show(ex.Message);
            }

        }

        private void Ajouter_Click(object sender, EventArgs e)
        {
            opertion = "modifier";
            SqlCommand cmd = new SqlCommand("update gestionnaire set nom=@nom,prenom=@prenom,sexe=@sexe,telephone=@tel,mdp=@mdp,photo=@photo,autorisé=@autoriser_tous_r,numreçu_a_modifier=@autoriser_r where pseudo=@pseudo ",Form1.cx);
            cmd.Parameters.AddWithValue("@nom", textBox1.Text);
            cmd.Parameters.AddWithValue("@prenom", textBox2.Text);
            cmd.Parameters.AddWithValue("@sexe", comboBox1.Text);
            cmd.Parameters.AddWithValue("@tel", textBox3.Text);
            cmd.Parameters.AddWithValue("@pseudo", textBox6.Text);
            cmd.Parameters.AddWithValue("@mdp", textBox7.Text);
            if (checkBox2.Checked) cmd.Parameters.AddWithValue("@autoriser_r", textBox5.Text);
            else cmd.Parameters.AddWithValue("@autoriser_r", "");
            if (checkBox1.Checked) cmd.Parameters.AddWithValue("@autoriser_tous_r", "Oui");
            else cmd.Parameters.AddWithValue("@autoriser_tous_r", "Non");
            cmd.Parameters.Add("@photo", SqlDbType.VarBinary);
            if (o.FileName != "")
            {
                FileStream fs = new FileStream(o.FileName, FileMode.Open, FileAccess.Read);
                byte[] t = new byte[fs.Length];
                fs.Read(t, 0, (int)fs.Length);
                cmd.Parameters["@photo"].Value = t;
            }
            else
            {
                if (dt.Rows[0][6] == DBNull.Value) { cmd.Parameters["@photo"].Value = DBNull.Value; }
                else
                {
                    byte[] t = (byte[])dt.Rows[0][6];
                    cmd.Parameters["@photo"].Value = t;
                }
            }

            Form1.cx.Open();
            cmd.ExecuteNonQuery();
            Form1.cx.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            opertion = "supprimer";
            SqlCommand cmd = new SqlCommand("delete from gestionnaire where pseudo='"+textBox6.Text+"'",Form1.cx);
            Form1.cx.Open();
            cmd.ExecuteNonQuery();
            Form1.cx.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (o.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(o.FileName);
        }
        void afficher(int pos)
        {
            if (dt.Rows.Count > 0)
            {
                if (DBNull.Value.ToString() == dt.Rows[0][6].ToString())
                {
                    if (dt.Rows[0][2].ToString() == "Homme")
                        pictureBox1.Load(Application.StartupPath + @"\no-photo.jpg");
                    else
                        pictureBox1.Load(Application.StartupPath + @"\femme.jpg");
                }
                else
                {
                    byte[] temp = (byte[])dt.Rows[0][6];
                    MemoryStream stream = new MemoryStream(temp);
                    stream.Write(temp, 0, temp.Length);
                    pictureBox1.Image = Image.FromStream(stream);
                }
                textBox1.Text = dt.Rows[0][0].ToString();
                textBox2.Text = dt.Rows[0][1].ToString();
                comboBox1.Text = dt.Rows[0][2].ToString();
                textBox3.Text = dt.Rows[0][3].ToString();
                textBox6.Text = dt.Rows[0][4].ToString();
                textBox7.Text = dt.Rows[0][5].ToString();
                maskedTextBox1.Text = dt.Rows[0][7].ToString();
                if (dt.Rows[0][9].ToString() != "") { checkBox2.Checked = true; textBox5.Text = dt.Rows[0][9].ToString(); }
                if (dt.Rows[0][8].ToString() == "Oui") checkBox1.Checked = true;
            }
        }
        private void uc_gestionnaires_Load(object sender, EventArgs e)
        {

            comboBox1.Items.Add("Homme");
            comboBox1.Items.Add("Femme");

            SqlCommand cmd = new SqlCommand("select nom as Nom ,prenom as Prénom,sexe as Sexe,telephone as Téléphone,pseudo as Pseudo,mdp as 'Mot de passe',photo,date_debut_utilisation as 'Date début d''utlisation',autorisé as 'Autoriser la modification à tous les reçus ?',numreçu_a_modifier as 'Numéro de reçu à modifier' from gestionnaire ",Form1.cx);
            Form1.cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            dr.Close();
            Form1.cx.Close();
            afficher(0);
            b= true;
        }

      

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            opertion = "nouveau";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            textBox7.Clear();
            textBox6.Clear();
            maskedTextBox1.Text = DateTime.Now.ToShortDateString();
            pictureBox1.Load(Application.StartupPath + @"\no-photo.jpg");
            comboBox1.Text = "Homme";
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {if (b == true)
            {
                if (opertion == "nouveau")
                {
                    if (o.FileName == "")
                    {
                        if (comboBox1.Text == "Femme") pictureBox1.Load(Application.StartupPath + @"\femme.jpg");
                        else pictureBox1.Load(Application.StartupPath + @"\no-photo.jpg");
                    }
                }
                else {
                    if (o.FileName != "")
                    {
                        if (comboBox1.Text == "Femme") pictureBox1.Load(Application.StartupPath + @"\femme.jpg");
                        else pictureBox1.Load(Application.StartupPath + @"\no-photo.jpg");
                    }
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            opertion = "supprimer";
            SqlCommand cmd = new SqlCommand("delete from gestionnaire where pseudo='" + textBox6.Text + "'", Form1.cx);
            Form1.cx.Open();
            cmd.ExecuteNonQuery();
            Form1.cx.Close();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            opertion = "modifier";
            SqlCommand cmd = new SqlCommand("update gestionnaire set nom=@nom,prenom=@prenom,sexe=@sexe,telephone=@tel,mdp=@mdp,photo=@photo,autorisé=@autoriser_tous_r,numreçu_a_modifier=@autoriser_r where pseudo=@pseudo ", Form1.cx);
            cmd.Parameters.AddWithValue("@nom", textBox1.Text);
            cmd.Parameters.AddWithValue("@prenom", textBox2.Text);
            cmd.Parameters.AddWithValue("@sexe", comboBox1.Text);
            cmd.Parameters.AddWithValue("@tel", textBox3.Text);
            cmd.Parameters.AddWithValue("@pseudo", textBox6.Text);
            cmd.Parameters.AddWithValue("@mdp", textBox7.Text);
            if (checkBox2.Checked) cmd.Parameters.AddWithValue("@autoriser_r", textBox5.Text);
            else cmd.Parameters.AddWithValue("@autoriser_r", "");
            if (checkBox1.Checked) cmd.Parameters.AddWithValue("@autoriser_tous_r", "Oui");
            else cmd.Parameters.AddWithValue("@autoriser_tous_r", "Non");
            cmd.Parameters.Add("@photo", SqlDbType.VarBinary);
            if (o.FileName != "")
            {
                FileStream fs = new FileStream(o.FileName, FileMode.Open, FileAccess.Read);
                byte[] t = new byte[fs.Length];
                fs.Read(t, 0, (int)fs.Length);
                cmd.Parameters["@photo"].Value = t;
            }
            else
            {
                if (dt.Rows[0][6] == DBNull.Value) { cmd.Parameters["@photo"].Value = DBNull.Value; }
                else
                {
                    byte[] t = (byte[])dt.Rows[0][6];
                    cmd.Parameters["@photo"].Value = t;
                }
            }

            Form1.cx.Open();
            cmd.ExecuteNonQuery();
            Form1.cx.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

            try
            {
                opertion = "ajouter";
                SqlCommand cmd2 = new SqlCommand("select count(*) from gestionnaire where pseudo='" + textBox6.Text + "'", Form1.cx);
                Form1.cx.Open();
                int i = (int)cmd2.ExecuteScalar();
                Form1.cx.Close();
                if (i > 0) throw new Exception("Vous ne peuvez pas créer des comptes de gestionnaires avec le même Pseudo.");
                SqlCommand cmd = new SqlCommand("insert into gestionnaire values(@nom,@prenom,@sexe,@tel,@pseudo,@mdp,@photo,getdate(),null,1,@autoriser_tous_r,@autoriser_r)", Form1.cx);
                cmd.Parameters.AddWithValue("@nom", textBox1.Text);
                cmd.Parameters.AddWithValue("@prenom", textBox2.Text);
                cmd.Parameters.AddWithValue("@sexe", comboBox1.Text);
                cmd.Parameters.AddWithValue("@tel", textBox3.Text);
                cmd.Parameters.AddWithValue("@pseudo", textBox6.Text);
                cmd.Parameters.AddWithValue("@mdp", textBox7.Text);
                if (checkBox2.Checked) cmd.Parameters.AddWithValue("@autoriser_r", textBox5.Text);
                else cmd.Parameters.AddWithValue("@autoriser_r", "");
                if (checkBox1.Checked) cmd.Parameters.AddWithValue("@autoriser_tous_r", "Oui");
                else cmd.Parameters.AddWithValue("@autoriser_tous_r", "Non");
                cmd.Parameters.Add("@photo", SqlDbType.VarBinary);
                if (o.FileName != "")
                {
                    FileStream fs = new FileStream(o.FileName, FileMode.Open, FileAccess.Read);
                    byte[] t = new byte[fs.Length];
                    fs.Read(t, 0, (int)fs.Length);
                    cmd.Parameters["@photo"].Value = t;
                }
                else
                    cmd.Parameters["@photo"].Value = DBNull.Value;
                Form1.cx.Open();
                cmd.ExecuteNonQuery();
                Form1.cx.Close();
            }
            catch (Exception ex)
            {
                Form1.cx.Close();
                MessageBox.Show(ex.Message);
            }

        }

        private void tb_connecter_Click(object sender, EventArgs e)
        {
            opertion = "nouveau";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            textBox7.Clear();
            textBox6.Clear();
            maskedTextBox1.Text = DateTime.Now.ToShortDateString();
            pictureBox1.Load(Application.StartupPath + @"\no-photo.jpg");
            comboBox1.Text = "Homme";
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
           
            afficher(0);

        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            afficher(dt.Rows.Count - 1);
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {

            if (l < dt.Rows.Count - 1)
            {
                l++;
            }
            afficher(l);
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            if (l > 0)
            {
                l--;
            }
            afficher(l);
        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
            if (o.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(o.FileName);
        }
    }
}
