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
    public partial class fr_saisir_nv_mdp : Form
    {
        public fr_saisir_nv_mdp()
        {
            InitializeComponent();
        }

        private void fr_saisir_nv_mdp_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
    }

        private void tb_connecter_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != textBox2.Text) throw new Exception("le mots de passes saisies ne coincident pas. Veuillez les retaper.");
                SqlCommand cmd;
                if (Form1.pseudo == 1)
                    cmd = new SqlCommand("upadte directeur set mdp='" + textBox1.Text+"'", Form1.cx);
                else
                    cmd = new SqlCommand("upadte gestionnaire set mdp='" + textBox1.Text+"'", Form1.cx);
                Form1.cx.Open();
                cmd.ExecuteNonQuery();
                Form1.cx.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
    }
