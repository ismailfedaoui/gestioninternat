using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Projet_Gestion_Internat
{
    public partial class uc_filieres : UserControl
    {
        string button = "";

        public uc_filieres()
        {
            InitializeComponent();
        }

        private void uc_filieres_Load(object sender, EventArgs e)
        {
            if(Form1.id_gest!=-1){ 
            linkLabel1.Visible = false;
            linkLabel1.Enabled = false; }

            comboBox4.Items.Add("Premiere année");
            comboBox4.Items.Add("Deuxième année");

            comboBox2.Items.Add("Technicien spécialisé");
            comboBox2.Items.Add("Technicien");
            comboBox2.Items.Add("Qualification");
            comboBox2.Items.Add("Spécialisation");
            comboBox2.Items.Add("Formations Qualifiantes");



            SqlCommand cmd = new SqlCommand("select distinct nom_filiere from filiere ", Form1.cx);
          
            Form1.cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();

            SqlDataReader dr2 = cmd.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            dr2.Close();
            
            Form1.cx.Close();

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "nom_filiere";
            comboBox6.DataSource = dt2;
            comboBox6.DisplayMember = "nom_filiere";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button = "ajouter";
            SqlCommand cmd = new SqlCommand("sp_nouvel_emploi", Form1.cx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nom_fl",comboBox1.Text);
            cmd.Parameters.AddWithValue("@niveau", comboBox2.Text);
            cmd.Parameters.AddWithValue("@anne", comboBox4.Text);
            cmd.Parameters.AddWithValue("@groupe", textBox1.Text);
            Form1.cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            Form1.cx.Close();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "";
            dataGridView1.Columns[1].HeaderText = "9 - 10"; //am09
            dataGridView1.Columns[2].HeaderText = "10 - 11";
            dataGridView1.Columns[3].HeaderText = "11 - 12";
            dataGridView1.Columns[4].HeaderText = "12 - 13";
            dataGridView1.Columns[5].HeaderText = "13 - 14";
            dataGridView1.Columns[6].HeaderText = "14 - 15";
            dataGridView1.Columns[7].HeaderText = "15 - 16";
            dataGridView1.Columns[8].HeaderText = "16 - 17";
            dataGridView1.Columns[9].HeaderText = "17 - 18";
            dataGridView1.Columns[10].HeaderText = "18 - 19";//PM18

            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
  
                r.Cells[1].Value = "";
                r.Cells[2].Value = "";
                r.Cells[3].Value = "";
                r.Cells[4].Value = "";
                r.Cells[5].Value = "";
                r.Cells[6].Value = "";
                r.Cells[7].Value = "";
                r.Cells[8].Value = "";
                r.Cells[9].Value = "";
                r.Cells[10].Value = "";
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {

                if (r.Cells[1].Value.ToString() == "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set am09= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", "Detoir");
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[2].Value.ToString() == "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set am10= @seance where jour=@jour and #id_filiere = (select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", "Detoir");
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[3].Value.ToString() == "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set am11= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", "Detoir");
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[4].Value.ToString() == "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set pm12= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", "Repas");
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString());

                    Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[5].Value.ToString() == "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set m13= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", "Detoir");
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[6].Value.ToString() == "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set pm14= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", "Detoir");
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[7].Value.ToString() == "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set pm15= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", "Detoir");
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[8].Value.ToString() == "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set pm16= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", "Detoir");
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[9].Value.ToString() == "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set pm17= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", "Detoir");
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[10].Value.ToString() == "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set pm18= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", "Detoir");
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }

            }
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {

                if (r.Cells[1].Value.ToString() != "")
                {
                    
                    SqlCommand cmd = new SqlCommand("update emploi set am09= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp",textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", r.Cells[1].Value.ToString());
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[2].Value.ToString() != "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set am10= @seance where jour=@jour and #id_filiere = (select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", r.Cells[2].Value.ToString());
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[3].Value.ToString() != "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set am11= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", r.Cells[3].Value.ToString());
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[4].Value.ToString() != "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set pm12= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", r.Cells[4].Value.ToString());
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString());

                    Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[5].Value.ToString() != "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set m13= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", r.Cells[5].Value.ToString());
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[6].Value.ToString() != "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set pm14= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", r.Cells[6].Value.ToString());
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[7].Value.ToString() != "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set pm15= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", r.Cells[7].Value.ToString());
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[8].Value.ToString() != "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set pm16= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", r.Cells[8].Value.ToString());
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[9].Value.ToString() != "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set pm17= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", r.Cells[9].Value.ToString());
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[10].Value.ToString() != "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set pm18= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", r.Cells[10].Value.ToString());
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }

            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("select groupe from filiere where nom_filiere='"+comboBox6.Text+"'", Form1.cx);

            Form1.cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            Form1.cx.Close();

            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "groupe";
            
        }

        private void comboBox6_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("delete  from filiere where id_filiere not in (select #id_filiere from emploi)", Form1.cx);

            SqlCommand cmd = new SqlCommand("select distinct nom_filiere from filiere ", Form1.cx);

            Form1.cx.Open();
            cmd2.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            Form1.cx.Close();
              comboBox6.DataSource = dt;
            comboBox6.DisplayMember = "nom filiere";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            supprimer_filiere f = new supprimer_filiere();
            f.Show();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tb_connecter_Click(object sender, EventArgs e)
        {

        }

        private void tb_connecter_Click_1(object sender, EventArgs e)
        {
            button = "rechercher";
            SqlCommand cmd = new SqlCommand("select jour,am09,am10,am11,pm12,m13,pm14,pm15,pm16,pm17,pm18 from emploi where #id_filiere =(select id_filiere from filiere where nom_filiere=@nom_fl and groupe=@gr)", Form1.cx);
            cmd.Parameters.AddWithValue("@nom_fl", comboBox6.Text);
            cmd.Parameters.AddWithValue("@gr", comboBox3.Text);
            Form1.cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            Form1.cx.Close();
            dataGridView1.DataSource = dt;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {

                if (r.Cells[1].Value.ToString() == "Detoir" | r.Cells[1].Value.ToString() == "Repas")
                {
                    r.Cells[1].Value = "";
                }
                if (r.Cells[2].Value.ToString() == "Detoir" | r.Cells[2].Value.ToString() == "Repas")
                {
                    r.Cells[2].Value = "";
                }
                if (r.Cells[3].Value.ToString() == "Detoir" | r.Cells[3].Value.ToString() == "Repas")
                {
                    r.Cells[3].Value = "";
                }
                if (r.Cells[4].Value.ToString() == "Detoir" | r.Cells[4].Value.ToString() == "Repas")
                {
                    r.Cells[4].Value = "";
                }
                if (r.Cells[5].Value.ToString() == "Detoir" | r.Cells[5].Value.ToString() == "Repas")
                {
                    r.Cells[5].Value = "";
                }
                if (r.Cells[6].Value.ToString() == "Detoir" | r.Cells[6].Value.ToString() == "Repas")
                {
                    r.Cells[6].Value = "";
                }
                if (r.Cells[7].Value.ToString() == "Detoir" | r.Cells[7].Value.ToString() == "Repas")
                {
                    r.Cells[7].Value = "";
                }
                if (r.Cells[8].Value.ToString() == "Detoir" | r.Cells[8].Value.ToString() == "Repas")
                {
                    r.Cells[8].Value = "";
                }
                if (r.Cells[9].Value.ToString() == "Detoir" | r.Cells[9].Value.ToString() == "Repas")
                {
                    r.Cells[9].Value = "";
                }
                if (r.Cells[10].Value.ToString() == "Detoir" | r.Cells[10].Value.ToString() == "Repas")
                {
                    r.Cells[10].Value = "";
                }
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {

                if (r.Cells[1].Value.ToString() == "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set am09= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", "Detoir");
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[2].Value.ToString() == "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set am10= @seance where jour=@jour and #id_filiere = (select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", "Detoir");
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[3].Value.ToString() == "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set am11= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", "Detoir");
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[4].Value.ToString() == "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set pm12= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", "Repas");
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString());

                    Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[5].Value.ToString() == "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set m13= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", "Detoir");
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[6].Value.ToString() == "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set pm14= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", "Detoir");
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[7].Value.ToString() == "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set pm15= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", "Detoir");
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[8].Value.ToString() == "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set pm16= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", "Detoir");
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[9].Value.ToString() == "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set pm17= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", "Detoir");
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[10].Value.ToString() == "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set pm18= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", "Detoir");
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }

            }
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {

                if (r.Cells[1].Value.ToString() != "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set am09= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", r.Cells[1].Value.ToString());
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[2].Value.ToString() != "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set am10= @seance where jour=@jour and #id_filiere = (select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", r.Cells[2].Value.ToString());
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[3].Value.ToString() != "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set am11= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", r.Cells[3].Value.ToString());
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[4].Value.ToString() != "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set pm12= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", r.Cells[4].Value.ToString());
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString());

                    Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[5].Value.ToString() != "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set m13= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", r.Cells[5].Value.ToString());
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[6].Value.ToString() != "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set pm14= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", r.Cells[6].Value.ToString());
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[7].Value.ToString() != "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set pm15= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", r.Cells[7].Value.ToString());
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[8].Value.ToString() != "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set pm16= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", r.Cells[8].Value.ToString());
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[9].Value.ToString() != "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set pm17= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", r.Cells[9].Value.ToString());
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }
                if (r.Cells[10].Value.ToString() != "")
                {

                    SqlCommand cmd = new SqlCommand("update emploi set pm18= @seance where jour=@jour and #id_filiere=(select id_filiere from filiere where groupe=@grp)", Form1.cx);
                    if (button == "ajouter") cmd.Parameters.AddWithValue("@grp", textBox1.Text);
                    else cmd.Parameters.AddWithValue("@grp", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@seance", r.Cells[10].Value.ToString());
                    cmd.Parameters.AddWithValue("@jour", r.Cells[0].Value.ToString()); Form1.cx.Open();
                    cmd.ExecuteNonQuery();
                    Form1.cx.Close();
                }

            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            button = "ajouter";
            SqlCommand cmd = new SqlCommand("sp_nouvel_emploi", Form1.cx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nom_fl", comboBox1.Text);
            cmd.Parameters.AddWithValue("@niveau", comboBox2.Text);
            cmd.Parameters.AddWithValue("@anne", comboBox4.Text);
            cmd.Parameters.AddWithValue("@groupe", textBox1.Text);
            Form1.cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            Form1.cx.Close();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "";
            dataGridView1.Columns[1].HeaderText = "9 - 10"; //am09
            dataGridView1.Columns[2].HeaderText = "10 - 11";
            dataGridView1.Columns[3].HeaderText = "11 - 12";
            dataGridView1.Columns[4].HeaderText = "12 - 13";
            dataGridView1.Columns[5].HeaderText = "13 - 14";
            dataGridView1.Columns[6].HeaderText = "14 - 15";
            dataGridView1.Columns[7].HeaderText = "15 - 16";
            dataGridView1.Columns[8].HeaderText = "16 - 17";
            dataGridView1.Columns[9].HeaderText = "17 - 18";
            dataGridView1.Columns[10].HeaderText = "18 - 19";//PM18

            foreach (DataGridViewRow r in dataGridView1.Rows)
            {

                r.Cells[1].Value = "";
                r.Cells[2].Value = "";
                r.Cells[3].Value = "";
                r.Cells[4].Value = "";
                r.Cells[5].Value = "";
                r.Cells[6].Value = "";
                r.Cells[7].Value = "";
                r.Cells[8].Value = "";
                r.Cells[9].Value = "";
                r.Cells[10].Value = "";
            }


        }
    }
}
