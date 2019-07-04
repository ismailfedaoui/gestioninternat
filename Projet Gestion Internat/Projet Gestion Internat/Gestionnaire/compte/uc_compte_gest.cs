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
    public partial class uc_compte_gest : UserControl
    {
        bool b;
        DataTable dt = new DataTable();
        OpenFileDialog o = new OpenFileDialog();
        public uc_compte_gest()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (o.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(o.FileName);
        }

        private void uc_compte_gest_Load(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("Select date_gestion,type_gestion,#cfe from stagiaire_gestionnaire where #id_gest="+1, Form1.cx);
            Form1.cx.Open();
            SqlDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dr2.Close();
            Form1.cx.Close();
            dataGridView1.DataSource = dt2;
            




            SqlCommand cmd = new SqlCommand("select nom, prenom , sexe,telephone,pseudo,mdp,photo,date_debut_utilisation,date_derniere_log from gestionnaire where id_gest="+1,Form1.cx);
            Form1.cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            
            dt.Load(dr);
            Form1.cx.Close();
            textBox1.Text = dt.Rows[0][0].ToString();
            textBox2.Text = dt.Rows[0][1].ToString();
           comboBox1.Text = dt.Rows[0][2].ToString();
            textBox3.Text = dt.Rows[0][3].ToString();
             textBox7.Text= dt.Rows[0][4].ToString();
            textBox6.Text = dt.Rows[0][5].ToString();
            textBox4.Text = dt.Rows[0][7].ToString();
            textBox5.Text = dt.Rows[0][8].ToString();

            if (DBNull.Value.ToString()== dt.Rows[0][6].ToString())
            {
                pictureBox1.Load(Application.StartupPath + @"\no-photo.jpg");
            }
            else
            {
                byte[] temp = (byte[])dt.Rows[0][6];
                MemoryStream stream = new MemoryStream(temp);
                stream.Write(temp, 0, temp.Length);
                pictureBox1.Image = Image.FromStream(stream);
            }
            b = true;

        }

        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update gestionnaire set nom=@nom, prenom=@prenom , sexe=@sexe,telephone=@tel,pseudo=@pseudo,mdp=@mdp,photo=@photo where id_gest=" + 1, Form1.cx);

            cmd.Parameters.AddWithValue("@nom", textBox1.Text);
            cmd.Parameters.AddWithValue("@prenom", textBox2.Text);
            cmd.Parameters.AddWithValue("@sexe", comboBox1.Text);
            cmd.Parameters.AddWithValue("@tel", textBox3.Text);
            cmd.Parameters.AddWithValue("@pseudo", textBox7.Text);
            cmd.Parameters.AddWithValue("@mdp", textBox6.Text);
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (o.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(o.FileName);
        
    }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update gestionnaire set nom=@nom, prenom=@prenom , sexe=@sexe,telephone=@tel,pseudo=@pseudo,mdp=@mdp,photo=@photo where id_gest=" + 1, Form1.cx);

            cmd.Parameters.AddWithValue("@nom", textBox1.Text);
            cmd.Parameters.AddWithValue("@prenom", textBox2.Text);
            cmd.Parameters.AddWithValue("@sexe", comboBox1.Text);
            cmd.Parameters.AddWithValue("@tel", textBox3.Text);
            cmd.Parameters.AddWithValue("@pseudo", textBox7.Text);
            cmd.Parameters.AddWithValue("@mdp", textBox6.Text);
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

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (o.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(o.FileName);
        }
    }
}
