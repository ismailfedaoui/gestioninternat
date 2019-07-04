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
using System.Data.SqlClient;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;

namespace Projet_Gestion_Internat
{
    public partial class Aceuil_dir : Form
    {
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        PromptBuilder pbuilder = new PromptBuilder();
        SpeechSynthesizer sp = new SpeechSynthesizer();
        DataTable dt2 = new DataTable();
        private void RecEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
        }
        public Aceuil_dir()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel7.Visible = true;
            panel8.Visible = false;
            panel9.Visible = false;
            panel11.Controls.Clear();
           uc_filieres uc_fl = new uc_filieres();
            panel11.Controls.Add(uc_fl);
        }

        private void button8_Click(object sender, EventArgs e)
        {

            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = true;
            DialogResult r = MessageBox.Show("vous êtes sûre de vouloir déconnecter ?", "Déconexion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("update directeur set date_derniere_log=getdate() where id_directeur=" + 1, Form1.cx);
                Form1.cx.Open();
                cmd.ExecuteNonQuery();
                Form1.cx.Close();
                Form1 f = new Form1();
                f.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel11.Controls.Clear();
            uc_acceuil uc_acceuil = new uc_acceuil();
            panel11.Controls.Add(uc_acceuil);
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel11.Controls.Clear();
            uc_gestionnaires uc_gestionnaires = new uc_gestionnaires();
            panel11.Controls.Add(uc_gestionnaires);
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel11.Controls.Clear();
            uc_rapports uc_rapports = new uc_rapports();
            panel11.Controls.Add(uc_rapports);
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel11.Controls.Clear();
            uc_compte_dir uc_compte_dir = new uc_compte_dir();
            panel11.Controls.Add(uc_compte_dir);
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel7.Visible = false;
            panel8.Visible = true;
            panel9.Visible = false;
        }

        private void Aceuil_dir_Load(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("select nom,prenom from directeur", Form1.cx);
            Form1.cx.Open();
            SqlDataReader dr2 = cmd2.ExecuteReader();
            
            dt2.Load(dr2);
            dr2.Close();
            Form1.cx.Close();
            label1.Text =  ("M. "+dt2.Rows[0][0].ToString() + " " + dt2.Rows[0][1].ToString()).ToUpper();
            SqlCommand cmd = new SqlCommand("select photo from directeur", Form1.cx);
            Form1.cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            Form1.cx.Close();
            if (DBNull.Value.ToString() == dt.Rows[0][0].ToString())
            {
                circularPictureBox1.Load(Application.StartupPath + @"\ma-photo.jpg");
            }
            else
            {
                byte[] temp = (byte[])dt.Rows[0][0];
                MemoryStream stream = new MemoryStream(temp);
                stream.Write(temp, 0, temp.Length);
               circularPictureBox1.Image = Image.FromStream(stream);
            }

            panel11.Controls.Clear();
            uc_acceuil uc_acceuil = new uc_acceuil();
            panel11.Controls.Add(uc_acceuil);
            this.MaximizeBox = false;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
        }

        private void Aceuil_dir_Shown(object sender, EventArgs e)
        {
           
            //speech
            Choices command = new Choices();
            command.Add(new string[] { "reconnaissance du visage", "empreinte" });
            GrammarBuilder gbuilder = new GrammarBuilder();
            gbuilder.Append(command);
            Grammar grammar = new Grammar(gbuilder);
            recEngine.LoadGrammar(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += RecEngine_SpeechRecognized;
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            pbuilder.ClearContent();
            pbuilder.AppendText("Bonjour Monsieur " + dt2.Rows[0][0].ToString() + " " + dt2.Rows[0][1].ToString());
            sp.Speak(pbuilder);
            //speech
            recEngine.RecognizeAsyncStop();
        }
    }
}
