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
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;


namespace Projet_Gestion_Internat
{
    public partial class Acceuil : Form
    {
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        PromptBuilder pbuilder = new PromptBuilder();
        SpeechSynthesizer sp = new SpeechSynthesizer();
        DataTable dto = new DataTable();
        DataTable dt = new DataTable();
        public Acceuil()
        {
            InitializeComponent();
        }
        private void RecEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
          


        
                  



        }
        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = true;
            panel9.Visible = false;
            panel11.Controls.Clear();
            uc_compte_gest uc_compte_g = new uc_compte_gest();
            panel11.Controls.Add(uc_compte_g);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = true;
            DialogResult r = MessageBox.Show("vous êtes sûre de vouloir déconnecter ?", "Déconexion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("update gestionnaire set date_derniere_log=getdate() where id_gest=" + 1, Form1.cx);
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
            panel2.Visible = true ;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
        }

        private void Acceuil_Load(object sender, EventArgs e)
        {
            SqlCommand cmdo = new SqlCommand("select nom,prenom from gestionnaire where id_gest=" + Form1.id_gest, Form1.cx);
            Form1.cx.Open();
            SqlDataReader dro = cmdo.ExecuteReader();
            dto.Load(dro);
            dro.Close();
            Form1.cx.Close();
            label1.Text =( "M. " + dto.Rows[0][0].ToString() + " " + dto.Rows[0][1].ToString()).ToUpper();
            SqlCommand cmd = new SqlCommand("select photo,sexe from gestionnaire where id_gest="+Form1.id_gest,Form1.cx);
            Form1.cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
           
            dt.Load(dr);
            dr.Close();
            Form1.cx.Close();
            if (DBNull.Value.ToString() == dt.Rows[0][0].ToString())
            { if(dt.Rows[0][1].ToString()=="Homme")
                circularPictureBox1.Load(Application.StartupPath + @"\no-photo.jpg");
                else circularPictureBox1.Load(Application.StartupPath + @"\femme.jpg");
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
            panel2.Visible = true ;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel11.Controls.Clear();
            uc_stagiaire uc_stagiaire = new uc_stagiaire();
            panel11.Controls.Add(uc_stagiaire);
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel11.Controls.Clear();
            uc_menu_abs uc_menu_abs = new uc_menu_abs();
            panel11.Controls.Add(uc_menu_abs);
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel11.Controls.Clear();
            uc_autorisations uc_auth = new uc_autorisations();
            panel11.Controls.Add(uc_auth);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = true;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel11.Controls.Clear();
            uc_sanctions uc_sanc = new uc_sanctions();
            panel11.Controls.Add(uc_sanc);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = true;
            panel8.Visible = false;
            panel9.Visible = false;
            panel11.Controls.Clear();
            uc_filieres uc_fl = new uc_filieres();
            panel11.Controls.Add(uc_fl);
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Acceuil_Shown(object sender, EventArgs e)
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
            pbuilder.AppendText("Bonjour Monsieur " + dto.Rows[0][0].ToString() + " " + dto.Rows[0][1].ToString());
            sp.Speak(pbuilder);
            //speech
            recEngine.RecognizeAsyncStop();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
