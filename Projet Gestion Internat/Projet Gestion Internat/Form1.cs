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

namespace Projet_Gestion_Internat
{
    public partial class Form1 : Form
    {
        public static int pseudo;
      
        public static int id_gest=-1;
        public static SqlConnection cx = new SqlConnection(@"server=ANDROID\SQLEXPRESS;database=gestion_internat;integrated security=true");
        //speech
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        PromptBuilder pbuilder = new PromptBuilder();
        SpeechSynthesizer sp = new SpeechSynthesizer();
        private void RecEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "directeur":

                   
                    
                    pbuilder.ClearContent();
                    checkbox_dir.Checked = true;
                    checkbox_gest.Checked = false;

                    break;
                case "gestionnaire":

                    
                    checkbox_dir.Checked = false;
                    checkbox_gest.Checked = true;
                    pbuilder.ClearContent();
                    break;



            }
        }
        //speech
        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuTextbox2_OnTextChange(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            checkbox_gest.Checked = false;
            checkbox_dir.Checked = false;
            bunifuImageButton2.Visible = false;
            bunifuImageButton1.Visible =true;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            tb_password.isPassword = false;
            bunifuImageButton2.Visible = true;
            bunifuImageButton1.Visible = false;
            
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            tb_password.isPassword = true;
            bunifuImageButton1.Visible = true;
            bunifuImageButton2.Visible = false;
        }

        private void tb_connecter_Click(object sender, EventArgs e)
        {
            if (checkbox_gest.Checked)
            {
                SqlCommand cmd = new SqlCommand("connexion_gest",cx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user",tb_user.Text);
                cmd.Parameters.AddWithValue("@mdp", tb_password.Text);
                SqlParameter p = new SqlParameter();
                p.SqlDbType = SqlDbType.Int;
                p.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(p);
                cx.Open();
                cmd.ExecuteNonQuery();
                cx.Close();
                if (p.Value.ToString() == "1")
                {
                    SqlCommand cmd2 = new SqlCommand("select id_gest from gestionnaire where pseudo=@user and mdp=@mdp ",cx);
                    cmd2.Parameters.AddWithValue("@user", tb_user.Text);
                    cmd2.Parameters.AddWithValue("@mdp", tb_password.Text);
                    cx.Open();
                    id_gest = (int)cmd2.ExecuteScalar();
                    cx.Close();
                    Acceuil f = new Acceuil();
                    f.Show();
                    this.Hide();
                }
                else if(p.Value.ToString() == "2")
                {
                    MessageBox.Show("le mot de passe est incorrect");
                }
                else if(p.Value.ToString() == "0")
                {
                    MessageBox.Show("les informations sont incorrects");
                }
               
            }
            else if (checkbox_dir.Checked)
            {
                SqlCommand cmd = new SqlCommand("connexion_dir", cx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user", tb_user.Text);
                cmd.Parameters.AddWithValue("@mdp", tb_password.Text);
                SqlParameter p = new SqlParameter();
                p.SqlDbType = SqlDbType.Int;
                p.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(p);
                cx.Open();
                cmd.ExecuteNonQuery();
                cx.Close();
                if (p.Value.ToString() == "1")
                {
                    Aceuil_dir f = new Aceuil_dir();
                    f.Show();
                    this.Hide();
                }
                else if (p.Value.ToString() == "2")
                {
                    MessageBox.Show("le mot de passe est incorrect");
                }
                else if (p.Value.ToString() == "0")
                {
                    MessageBox.Show("les informations sont incorrects");
                }

                
            }
            else MessageBox.Show("Vous devez séléctioner votre type d'utilsateur", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
          
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            if (!checkbox_gest.Checked && !checkbox_dir.Checked) MessageBox.Show("Vous devez séléctioner votre type d'utilsateur", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (checkbox_dir.Checked)
                {
                    pseudo = 1;
                    fr_mot_de_passe_oublié f = new fr_mot_de_passe_oublié();
                    f.Show();
                }
                else
                {
                    pseudo = 2;
                    form_pesuo_gest f = new form_pesuo_gest();
                    f.Show();

                }
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {
            checkbox_dir.Checked = true;
            checkbox_gest.Checked = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            checkbox_gest.Checked = true;
            checkbox_dir.Checked = false;
        }

        private void checkbox_gest_OnChange(object sender, EventArgs e)
        {
            checkbox_dir.Checked = false;
        }

        private void checkbox_dir_OnChange(object sender, EventArgs e)
        {
            checkbox_gest.Checked = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void linkLabel1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Choices command = new Choices();
            command.Add(new string[] { "directeur", "gestionnaire" });
            GrammarBuilder gbuilder = new GrammarBuilder();
            gbuilder.Append(command);
            Grammar grammar = new Grammar(gbuilder);
            recEngine.LoadGrammar(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += RecEngine_SpeechRecognized;
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
        }
    }
}
