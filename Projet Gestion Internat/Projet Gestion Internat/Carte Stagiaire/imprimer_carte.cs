using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_Gestion_Internat
{
    public partial class imprimer_carte : Form
    {
        public imprimer_carte()
        {
            InitializeComponent();
        }
        
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void imprimer_carte_Load(object sender, EventArgs e)
        {
            CrystalReportCARTE r = new CrystalReportCARTE();
            if (uc_stagiaire.v_operation == "ajouter")
                r.SetParameterValue("@cfe", uc_ajouter.cfe);
            else
                r.SetParameterValue("@cfe", uc_scan.v_cfe);
            crystalReportViewer1.ReportSource = r;
            crystalReportViewer1.Refresh();
        }
    }
}
