using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_Gestion_Internat
{
    public partial class uc_stagiaire : UserControl
    {
       public static string v_operation ;
        public uc_stagiaire()
        {
            InitializeComponent();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            v_operation = "ajouter";
            panel1.Controls.Clear();
            uc_ajouter uc_ajouter = new uc_ajouter();
            panel1.Controls.Add(uc_ajouter);
            
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            uc_affecter_paiement uc_affecter_paiement = new uc_affecter_paiement();
            panel1.Controls.Add(uc_affecter_paiement);
            v_operation = "affecter paiement";
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            uc_chef_chambre uc_chef_chambre = new uc_chef_chambre();
            panel1.Controls.Add(uc_chef_chambre);
        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            uc_afficher_tous uc_afficher_tous = new uc_afficher_tous();
            panel1.Controls.Add(uc_afficher_tous);
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
           
            v_operation = "modifier";
            panel1.Controls.Clear();
          
            uc_scan uc_scan = new uc_scan();
            panel1.Controls.Add(uc_scan);


        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            uc_scan uc_scan = new uc_scan();
            panel1.Controls.Add(uc_scan);
           
            v_operation = "supprimer";
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            uc_scan uc_scan = new uc_scan();
            panel1.Controls.Add(uc_scan);
            v_operation = "scanner";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
