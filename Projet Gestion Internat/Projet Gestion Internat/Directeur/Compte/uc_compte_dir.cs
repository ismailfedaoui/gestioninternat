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
    public partial class uc_compte_dir : UserControl
    {
        DataTable dt = new DataTable();

        OpenFileDialog o = new OpenFileDialog();
        public uc_compte_dir()
        {
            InitializeComponent();
        }

        private void uc_compte_dir_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select nom, prenom , pseudo,mdp,photo,date_derniere_log ,telephone from directeur", Form1.cx);
            Form1.cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            
            dt.Load(dr);
            Form1.cx.Close();
            textBox1.Text = dt.Rows[0][0].ToString();
            textBox2.Text = dt.Rows[0][1].ToString();
            textBox7.Text = dt.Rows[0][2].ToString();
            textBox6.Text = dt.Rows[0][3].ToString();
            textBox3.Text = dt.Rows[0][6].ToString();
            maskedTextBox2.Text = dt.Rows[0][5].ToString();
            if (DBNull.Value.ToString() == dt.Rows[0][4].ToString())
            {
                pictureBox1.Load(Application.StartupPath + @"\no-photo.jpg");
            }
            else
            {
                byte[] temp = (byte[])dt.Rows[0][4];
                MemoryStream stream = new MemoryStream(temp);
                stream.Write(temp, 0, temp.Length);
                pictureBox1.Image = Image.FromStream(stream);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (o.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(o.FileName);
        }

        private void tb_connecter_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("update directeur set nom=@nom, prenom=@prenom , pseudo=@pseudo,mdp=@mdp,photo=@photo ,telephone=@telephone", Form1.cx);

                cmd.Parameters.AddWithValue("@nom", textBox1.Text);
                cmd.Parameters.AddWithValue("@prenom", textBox2.Text);
                cmd.Parameters.AddWithValue("@pseudo", textBox7.Text);
                cmd.Parameters.AddWithValue("@mdp", textBox6.Text);
                cmd.Parameters.AddWithValue("@telephone", textBox3.Text);
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
                    if (dt.Rows[0][4] == DBNull.Value) { cmd.Parameters["@photo"].Value = DBNull.Value; }
                    else
                    {
                        byte[] t = (byte[])dt.Rows[0][4];
                        cmd.Parameters["@photo"].Value = t;
                    }
                }

                Form1.cx.Open();
                cmd.ExecuteNonQuery();
                Form1.cx.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (o.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(o.FileName);
        }
    }
}
