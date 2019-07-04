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
    public partial class imprimer_contr : Form
    {
        public imprimer_contr()
        {
            InitializeComponent();
        }

        private void imprimer_contr_Load(object sender, EventArgs e)
        {
            CrystalReportCONTRI r = new CrystalReportCONTRI();
            r.SetParameterValue("@type", uc_rapport_contr.type);
            r.SetParameterValue("@pension", uc_rapport_contr.pension);
            r.SetParameterValue("@sexe", uc_rapport_contr.sexe);
            r.SetParameterValue("@detoir", uc_rapport_contr.detoir);
            r.SetParameterValue("@chambre", uc_rapport_contr.chambre);
            r.SetParameterValue("@date1", uc_rapport_contr.date1);
            r.SetParameterValue("@date2", uc_rapport_contr.date2);
            r.SetParameterValue("@mois", uc_rapport_contr.mois);
            r.SetParameterValue("@group_fl", uc_rapport_contr.group_fl);
            r.SetParameterValue("@nom_fl", uc_rapport_contr.nom_fl);
            r.SetParameterValue("@buanderie", uc_rapport_contr.buanderie);

            crystalReportViewer1.ReportSource = r;
            crystalReportViewer1.Refresh();
        }
    }
}
