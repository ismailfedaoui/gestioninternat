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
    public partial class imprimer_stg : Form
    {
        public imprimer_stg()
        {
            InitializeComponent();
        }

        private void imprimer_stg_Load(object sender, EventArgs e)
        {
            CrystalReportSTAGIAIRE r = new CrystalReportSTAGIAIRE();
            r.SetParameterValue("@type", uc_afficher_tous.type);
            r.SetParameterValue("@pension", uc_afficher_tous.pension);
            r.SetParameterValue("@sexe", uc_afficher_tous.sexe);
            r.SetParameterValue("@detoir", uc_afficher_tous.detoir);
            r.SetParameterValue("@chambre", uc_afficher_tous.chambre);
            r.SetParameterValue("@date1", uc_afficher_tous.date1);
            r.SetParameterValue("@date2", uc_afficher_tous.date2);
            r.SetParameterValue("@mois", uc_afficher_tous.mois);
            r.SetParameterValue("@group_fl", uc_afficher_tous.group_fl);
            r.SetParameterValue("@nom_fl", uc_afficher_tous.nom_fl);
            r.SetParameterValue("@buanderie", uc_afficher_tous.buanderie);

            crystalReportViewer1.ReportSource = r;
            crystalReportViewer1.Refresh();



        }
    }
}
