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
    public partial class uc_rapports : UserControl
    {
        public uc_rapports()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            uc_afficher_tous uc_afficher_tous = new uc_afficher_tous();
            panel1.Controls.Add(uc_afficher_tous);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            uc_rapport_contr uc_rapport_contr = new uc_rapport_contr();
            panel1.Controls.Add(uc_rapport_contr);
        }
    }
}
