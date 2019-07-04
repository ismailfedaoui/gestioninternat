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
    public partial class uc_menu_abs : UserControl
    {
        public uc_menu_abs()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            uc_controler_abs uc_controler_abs = new uc_controler_abs();
            panel1.Controls.Add(uc_controler_abs);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            uc_afficher_abs uc_afficher_abs = new uc_afficher_abs();
            panel1.Controls.Add(uc_afficher_abs);
        }
    }
}
