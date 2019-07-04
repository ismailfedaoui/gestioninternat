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
using System.IO;
namespace Projet_Gestion_Internat
{

    public partial class uc_modifier : UserControl
    {
        DataTable dt2 = new DataTable();
        public static string tous = "";
        DataTable dt = new DataTable();
        OpenFileDialog o = new OpenFileDialog();
        public uc_modifier()
        {
            InitializeComponent();
        }
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void uc_modifier_Load(object sender, EventArgs e)
        {
            try
            {
                

                SqlCommand cmd2 = new SqlCommand("select count(*) from stagiaire where cfe=" + uc_scan.v_cfe.ToString() + " and #id_buanderie is not null", Form1.cx);
                SqlCommand cmd6 = new SqlCommand("select count(*) from reçu where #cfe=" + uc_scan.v_cfe.ToString() + " pension='Complete'", Form1.cx);
                Form1.cx.Open();
                int u = (int)cmd2.ExecuteScalar();
                Form1.cx.Close();

                SqlCommand cmd;
                if (u > 0)
                    cmd = new SqlCommand("select nom ,prenom ,sexe ,telephone ,nationalité, type_stagiaire,nom_filiere,niveau,groupe,annee,datenaissance,Rue,ville,cp,nom_respo,prenom_respo,sexe_respo,tel_respo,lien,buanderie.#id_detoir,photo,buanderie.num_lit,buanderie.num_armoire,QR_code from stagiaire join filiere on stagiaire.#id_filiere=filiere.id_filiere full outer join buanderie on stagiaire.#id_buanderie=buanderie.id_buanderie where cfe=" + uc_scan.v_cfe.ToString(), Form1.cx);

                else
                    cmd = new SqlCommand("select nom ,prenom  ,sexe ,telephone ,nationalité, type_stagiaire,nom_filiere,niveau,groupe,annee,datenaissance,Rue,ville,cp,nom_respo,prenom_respo,sexe_respo,tel_respo,lien,chambre.#id_detoir,photo,num_chambre,chambre.num_lit,chambre.num_armoire,QR_code from stagiaire join filiere on stagiaire.#id_filiere=filiere.id_filiere full outer join chambre  on stagiaire.#id_chambre=chambre.id_chambre where cfe=" + uc_scan.v_cfe.ToString(), Form1.cx);

                SqlCommand cmd3 = new SqlCommand("select pension from reçu where #cfe=" + uc_scan.v_cfe + " and date_paiement=(select max(date_paiement) from reçu where #cfe=" + uc_scan.v_cfe + ")", Form1.cx);
                Form1.cx.Open();
                SqlDataReader dr2 = cmd3.ExecuteReader();
                dt2.Load(dr2);
                dr2.Close();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                dr.Close();
                Form1.cx.Close();

                if (dt2.Rows[0][0].ToString() == "Demi pension") groupBox3.Enabled = false;

                textBox1.Text = uc_scan.v_cfe.ToString();
                textBox2.Text = dt.Rows[0][0].ToString();
                textBox3.Text = dt.Rows[0][1].ToString();
                comboBox1.Text = dt.Rows[0][2].ToString();
                textBox4.Text = dt.Rows[0][3].ToString();
                textBox5.Text = dt.Rows[0][4].ToString();
                comboBox2.Text = dt.Rows[0][5].ToString();
                comboBox4.Text = dt.Rows[0][6].ToString();
                comboBox6.Text = dt.Rows[0][7].ToString();
                comboBox5.Text = dt.Rows[0][8].ToString();
                comboBox11.Text = dt.Rows[0][9].ToString();
                maskedTextBox1.Text = dt.Rows[0][10].ToString();
                richTextBox1.Text = dt.Rows[0][11].ToString();
                textBox9.Text = dt.Rows[0][12].ToString();
                textBox10.Text = dt.Rows[0][13].ToString();
                textBox8.Text = dt.Rows[0][14].ToString();
                textBox11.Text = dt.Rows[0][15].ToString();
                comboBox3.Text = dt.Rows[0][16].ToString();
                textBox12.Text = dt.Rows[0][17].ToString();
                textBox13.Text = dt.Rows[0][18].ToString();
                comboBox7.Text = dt.Rows[0][19].ToString();
                if (DBNull.Value.ToString() == dt.Rows[0][20].ToString())
                {
                    if (dt.Rows[0][2].ToString() == "Garçon")
                        pictureBox1.Load(Application.StartupPath + @"\facebookprofilepic.jpg");
                    else
                        pictureBox1.Load(Application.StartupPath + @"\femme.jpg");
                }
                else
                {
                    byte[] temp = (byte[])dt.Rows[0][20];
                    MemoryStream stream = new MemoryStream(temp);
                    stream.Write(temp, 0, temp.Length);
                    pictureBox1.Image = Image.FromStream(stream);
                }
                if (u > 0)
                {
                    checkBox1.Checked = true;
                    comboBox8.Enabled = false;
                    comboBox9.Text = dt.Rows[0][21].ToString();
                    comboBox10.Text = dt.Rows[0][22].ToString();
                }
                else
                {
                    comboBox8.Text = dt.Rows[0][21].ToString();
                    comboBox9.Text = dt.Rows[0][22].ToString();
                    comboBox10.Text = dt.Rows[0][23].ToString();
                }
                if (u > 0)
                {
                    checkBox1.Enabled = true;
                    comboBox8.Enabled = false;
                    comboBox9.Items.Add('1');
                    comboBox9.Items.Add('2');
                    comboBox10.Items.Add('1');
                    comboBox10.Items.Add('2');

                }
                else
                {
                    checkBox1.Enabled = false;
                    comboBox8.Enabled = true;
                    comboBox8.Items.Add('1');
                    comboBox8.Items.Add('2');
                    comboBox8.Items.Add('3');
                    comboBox8.Items.Add('4');
                    comboBox8.Items.Add('5');
                    comboBox8.Items.Add('6');
                    comboBox8.Items.Add('7');
                    comboBox8.Items.Add('8');


                    comboBox9.Items.Add('1');
                    comboBox9.Items.Add('2');
                    comboBox9.Items.Add('3');
                    comboBox9.Items.Add('4');
                    comboBox10.Items.Add('1');
                    comboBox10.Items.Add('2');
                    comboBox10.Items.Add('3');
                    comboBox10.Items.Add('4');
                }

                comboBox7.Items.Add('A');
                comboBox7.Items.Add('B');
                comboBox7.Items.Add('C');
                comboBox7.Items.Add('D');
                comboBox1.Items.Add("Garçon");
                comboBox1.Items.Add("Fille");
                comboBox2.Items.Add("Normal");
                comboBox2.Items.Add("Maitre");
                comboBox2.Items.Add("Exonéré");

                SqlCommand cmd21 = new SqlCommand("select distinct nom_filiere from filiere ", Form1.cx);

                Form1.cx.Open();

                SqlDataReader dr21 = cmd21.ExecuteReader();
                DataTable dt21 = new DataTable();
                dt21.Load(dr21);
                dr21.Close();
                Form1.cx.Close();
                comboBox4.DataSource = dt21;
                comboBox4.DisplayMember = "nom_filiere";

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (o.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(o.FileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string anne_scolaire;
            if (DateTime.Now.Month == 9 | DateTime.Now.Month == 10 | DateTime.Now.Month == 11 | DateTime.Now.Month == 12)
                anne_scolaire = "1/9/" + DateTime.Now.Year.ToString();
            else
                anne_scolaire = "1/9/" + (DateTime.Now.Year - 1).ToString();

            try {
                if (comboBox10.Text != comboBox9.Text) throw new Exception("le numéro d'armoire et le numéro de lit ne coincident pas.");
                SqlCommand cmd123;
                if (checkBox1.Checked)
                {
                    cmd123 = new SqlCommand("select count(*) from buanderie join stagiaire on stagiaire.#id_buanderie = buanderie.id_buanderie join reçu on reçu.#cfe=stagiaire.cfe where date_paiement between '" + anne_scolaire + "' and '" + DateTime.Now.ToShortDateString() + "' and #id_detoir=@detoir and num_lit=@lit and num_armoire=@armoire and stagiaire.cfe !=" + textBox1.Text, Form1.cx);
                    cmd123.Parameters.AddWithValue("@detoir", comboBox7.Text);
                }
                else
                {
                    cmd123 = new SqlCommand("select count(*) from chambre join stagiaire on stagiaire.#id_chambre = chambre.id_chambre join reçu on reçu.#cfe=stagiaire.cfe where date_paiement between '" + anne_scolaire + "' and '" + DateTime.Now.ToShortDateString() + "' and num_chambre=@chambre and #id_detoir=@detoir and num_lit=@lit and num_armoire=@armoire and stagiaire.cfe !=" + textBox1.Text, Form1.cx);
                    cmd123.Parameters.AddWithValue("@detoir", comboBox7.Text);
                    cmd123.Parameters.AddWithValue("@lit", comboBox9.Text);
                    cmd123.Parameters.AddWithValue("@armoire", comboBox10.Text);
                    cmd123.Parameters.AddWithValue("@chambre", comboBox8.Text);
                }

                Form1.cx.Open();
                int u = (int)cmd123.ExecuteScalar();
                Form1.cx.Close();



                SqlCommand cmd = new SqlCommand("update stagiaire set cfe=@cfe,nom=@nom,prenom=@prenom,datenaissance=@dns,sexe=@sexe,telephone=@telephone,rue=@rue,ville=@ville,cp=@cp,nationalité=@nationalite,type_stagiaire=@type,photo=@photo,nom_respo=@nom_r,prenom_respo=@prenom_r,tel_respo=@tel_r,lien=@lien,sexe_respo=@sexe_r,#id_filiere=(select id_filiere from filiere where groupe=@grp) where cfe=" + uc_scan.v_cfe.ToString(), Form1.cx);
                SqlCommand cmd2 = new SqlCommand("update buanderie set #id_detoir=@detoir,num_lit=@num_lit,num_armoire=@num_armoire where id_buanderie in (select #id_buanderie from stagiaire where cfe=@cfe) ", Form1.cx);
                SqlCommand cmd3 = new SqlCommand("update chambre set #id_detoir=@detoir,num_chambre=@num_chambre,num_lit=@num_lit,num_armoire=@num_armoire where id_chambre in (select #id_chambre from stagiaire where cfe=@cfe) ", Form1.cx);

                cmd.Parameters.AddWithValue("@cfe", textBox1.Text);
                cmd.Parameters.AddWithValue("@nom", textBox2.Text);
                cmd.Parameters.AddWithValue("@prenom", textBox3.Text);
                cmd.Parameters.AddWithValue("@dns", maskedTextBox1.Text);
                cmd.Parameters.AddWithValue("@sexe", comboBox1.Text);
                cmd.Parameters.AddWithValue("@telephone", textBox4.Text);
                cmd.Parameters.AddWithValue("@rue", richTextBox1.Text);
                cmd.Parameters.AddWithValue("@ville", textBox9.Text);
                cmd.Parameters.AddWithValue("@cp", textBox10.Text);
                cmd.Parameters.AddWithValue("@nationalite", textBox5.Text);
                cmd.Parameters.AddWithValue("@type", comboBox2.Text);
                cmd.Parameters.AddWithValue("@nom_r", textBox8.Text);
                cmd.Parameters.AddWithValue("@prenom_r", textBox11.Text);
                cmd.Parameters.AddWithValue("@tel_r", textBox12.Text);
                cmd.Parameters.AddWithValue("@lien", textBox13.Text);
                cmd.Parameters.AddWithValue("@sexe_r", comboBox3.Text);
                cmd.Parameters.AddWithValue("@grp", comboBox5.Text);
                cmd.Parameters.Add("@photo", SqlDbType.VarBinary);
                if (o.FileName != "")
                {
                    FileStream fs = new FileStream(o.FileName, FileMode.Open, FileAccess.Read);
                    byte[] t = new byte[fs.Length];
                    fs.Read(t, 0, (int)fs.Length);
                    cmd.Parameters["@photo"].Value = t;
                }
                else
                {
                    if (dt.Rows[0][20] == DBNull.Value) { cmd.Parameters["@photo"].Value = DBNull.Value; }
                    else
                    {
                        byte[] t = (byte[])dt.Rows[0][20];
                        cmd.Parameters["@photo"].Value = t;
                    }

                }

                cmd2.Parameters.AddWithValue("@cfe", uc_scan.v_cfe);
                cmd2.Parameters.AddWithValue("@detoir", comboBox7.Text);
                cmd2.Parameters.AddWithValue("@num_lit", comboBox9.Text);
                cmd2.Parameters.AddWithValue("@num_armoire", comboBox10.Text);

                cmd3.Parameters.AddWithValue("@cfe", uc_scan.v_cfe.ToString());
                cmd3.Parameters.AddWithValue("@detoir", comboBox7.Text);
                cmd3.Parameters.AddWithValue("@num_chambre", comboBox8.Text);
                cmd3.Parameters.AddWithValue("@num_lit", comboBox9.Text);
                cmd3.Parameters.AddWithValue("@num_armoire", comboBox10.Text);


                if (u > 0)
                {
                    throw new Exception("L'emplacement séléctionné est déjà affecté à un autre stagiaire.");
                }

                Form1.cx.Open();
                cmd.ExecuteNonQuery();
                if (dt2.Rows[0][0].ToString() == "Complete")
                {
                    cmd2.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                }
                Form1.cx.Close();
                uc_ajouter.lit = comboBox9.Text;
                uc_ajouter.detoir = comboBox7.Text;
                uc_ajouter.armoire = comboBox10.Text;
                uc_ajouter.chambre = comboBox8.Text;
                uc_ajouter.cfe = textBox1.Text;
                uc_ajouter.nom = textBox2.Text;
                uc_ajouter.prenom = textBox3.Text;
                uc_ajouter.groupe = comboBox5.Text;
                uc_ajouter.buandere = false;
                if (checkBox1.Checked) uc_ajouter.buandere = true;
                else uc_ajouter.buandere = false;
                if (checkBox1.Checked)
                {
                    byte[] temp = (byte[])dt.Rows[0][23];
                    MemoryStream stream = new MemoryStream(temp);
                    stream.Write(temp, 0, temp.Length);
                    uc_ajouter.bmp_qr = (Bitmap)Image.FromStream(stream);
                }
                else
                {
                    byte[] temp = (byte[])dt.Rows[0][24];
                    MemoryStream stream = new MemoryStream(temp);
                    stream.Write(temp, 0, temp.Length);
                    uc_ajouter.bmp_qr = (Bitmap)Image.FromStream(stream);
                }

                uc_ajouter.img_prohile = pictureBox1.Image;
                fr_carte_internat f = new fr_carte_internat();
                f.Show();
            }
            catch (Exception ex)
            {
                Form1.cx.Close();
                MessageBox.Show(ex.Message);
            }
            
            
            }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cm = new SqlCommand("select [numreçu_a_modifier] from gestionnaire where id_gest=" + Form1.id_gest, Form1.cx);
                Form1.cx.Open();
                SqlDataReader d = cm.ExecuteReader();
                DataTable dt0 = new DataTable();
                dt0.Load(d);
                d.Close();
                Form1.cx.Close();

                SqlCommand cm3 = new SqlCommand("select count(*) from reçu where num_reçu ='" + dt0.Rows[0][0].ToString() + "' and #cfe=" + uc_scan.v_cfe.ToString(), Form1.cx);
                Form1.cx.Open();
                int io = (int)cm3.ExecuteScalar();
                Form1.cx.Close();

                if (io == 0) throw new Exception("le numéro de reçu saisi par le directeur n'existe pas parmi les numéros de reçus de ce stagiaire");

                SqlCommand cmd = new SqlCommand("select [autorisé],[numreçu_a_modifier] from gestionnaire where id_gest=" + Form1.id_gest, Form1.cx);
                Form1.cx.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                Form1.cx.Close();
                if (dt.Rows[0][0].ToString() == "Oui")
                {
                    tous = "oui";
                    fr_modifier_p f = new fr_modifier_p();
                    f.Show();
                }
                else if (dt.Rows[0][1].ToString() != "")
                {
                   
                    fr_modifier_p f = new fr_modifier_p();
                    f.Show();
                }
                else
                {
                    throw new Exception("Vous ne êtes pas autorisé à modifier les stagiaires.");
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void tb_connecter_Click(object sender, EventArgs e)
        {

            try
            {
                SqlCommand cm = new SqlCommand("select [numreçu_a_modifier] from gestionnaire where id_gest=" + Form1.id_gest, Form1.cx);
                Form1.cx.Open();
                SqlDataReader d = cm.ExecuteReader();
                DataTable dt0 = new DataTable();
                dt0.Load(d);
                d.Close();
                Form1.cx.Close();

                SqlCommand cm3 = new SqlCommand("select count(*) from reçu where num_reçu ='" + dt0.Rows[0][0].ToString() + "' and #cfe=" + uc_scan.v_cfe.ToString(), Form1.cx);
                Form1.cx.Open();
                int io = (int)cm3.ExecuteScalar();
                Form1.cx.Close();

                if (io == 0) throw new Exception("le numéro de reçu saisi par le directeur n'existe pas parmi les numéros de reçus de ce stagiaire");

                SqlCommand cmd = new SqlCommand("select [autorisé],[numreçu_a_modifier] from gestionnaire where id_gest=" + Form1.id_gest, Form1.cx);
                Form1.cx.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                Form1.cx.Close();
                if (dt.Rows[0][0].ToString() == "Oui")
                {
                    tous = "oui";
                    fr_modifier_p f = new fr_modifier_p();
                    f.Show();
                }
                else if (dt.Rows[0][1].ToString() != "")
                {

                    fr_modifier_p f = new fr_modifier_p();
                    f.Show();
                }
                else
                {
                    throw new Exception("Vous ne êtes pas autorisé à modifier les stagiaires.");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            string anne_scolaire;
            if (DateTime.Now.Month == 9 | DateTime.Now.Month == 10 | DateTime.Now.Month == 11 | DateTime.Now.Month == 12)
                anne_scolaire = "1/9/" + DateTime.Now.Year.ToString();
            else
                anne_scolaire = "1/9/" + (DateTime.Now.Year - 1).ToString();

            try
            {
                if (comboBox10.Text != comboBox9.Text) throw new Exception("le numéro d'armoire et le numéro de lit ne coincident pas.");
                SqlCommand cmd123;
                if (checkBox1.Checked)
                {
                    cmd123 = new SqlCommand("select count(*) from buanderie join stagiaire on stagiaire.#id_buanderie = buanderie.id_buanderie join reçu on reçu.#cfe=stagiaire.cfe where date_paiement between '" + anne_scolaire + "' and '" + DateTime.Now.ToShortDateString() + "' and #id_detoir=@detoir and num_lit=@lit and num_armoire=@armoire and cfe !=" + textBox1.Text, Form1.cx);
                    cmd123.Parameters.AddWithValue("@detoir", comboBox7.Text);
                }
                else
                {
                    cmd123 = new SqlCommand("select count(*) from chambre join stagiaire on stagiaire.#id_chambre = chambre.id_chambre join reçu on reçu.#cfe=stagiaire.cfe where date_paiement between '" + anne_scolaire + "' and '" + DateTime.Now.ToShortDateString() + "' and num_chambre=@chambre and #id_detoir=@detoir and num_lit=@lit and num_armoire=@armoire and cfe !=" + textBox1.Text, Form1.cx);
                    cmd123.Parameters.AddWithValue("@detoir", comboBox7.Text);
                    cmd123.Parameters.AddWithValue("@lit", comboBox9.Text);
                    cmd123.Parameters.AddWithValue("@armoire", comboBox10.Text);
                    cmd123.Parameters.AddWithValue("@chambre", comboBox8.Text);
                }

                Form1.cx.Open();
                int u = (int)cmd123.ExecuteScalar();
                Form1.cx.Close();



                SqlCommand cmd = new SqlCommand("update stagiaire set cfe=@cfe,nom=@nom,prenom=@prenom,datenaissance=@dns,sexe=@sexe,telephone=@telephone,rue=@rue,ville=@ville,cp=@cp,nationalité=@nationalite,type_stagiaire=@type,photo=@photo,nom_respo=@nom_r,prenom_respo=@prenom_r,tel_respo=@tel_r,lien=@lien,sexe_respo=@sexe_r,#id_filiere=(select id_filiere from filiere where groupe=@grp) where cfe=" + uc_scan.v_cfe.ToString(), Form1.cx);
                SqlCommand cmd2 = new SqlCommand("update buanderie set #id_detoir=@detoir,num_lit=@num_lit,num_armoire=@num_armoire where id_buanderie in (select #id_buanderie from stagiaire where cfe=@cfe) ", Form1.cx);
                SqlCommand cmd3 = new SqlCommand("update chambre set #id_detoir=@detoir,num_chambre=@num_chambre,num_lit=@num_lit,num_armoire=@num_armoire where id_chambre in (select #id_chambre from stagiaire where cfe=@cfe) ", Form1.cx);

                cmd.Parameters.AddWithValue("@cfe", textBox1.Text);
                cmd.Parameters.AddWithValue("@nom", textBox2.Text);
                cmd.Parameters.AddWithValue("@prenom", textBox3.Text);
                cmd.Parameters.AddWithValue("@dns", maskedTextBox1.Text);
                cmd.Parameters.AddWithValue("@sexe", comboBox1.Text);
                cmd.Parameters.AddWithValue("@telephone", textBox4.Text);
                cmd.Parameters.AddWithValue("@rue", richTextBox1.Text);
                cmd.Parameters.AddWithValue("@ville", textBox9.Text);
                cmd.Parameters.AddWithValue("@cp", textBox10.Text);
                cmd.Parameters.AddWithValue("@nationalite", textBox5.Text);
                cmd.Parameters.AddWithValue("@type", comboBox2.Text);
                cmd.Parameters.AddWithValue("@nom_r", textBox8.Text);
                cmd.Parameters.AddWithValue("@prenom_r", textBox11.Text);
                cmd.Parameters.AddWithValue("@tel_r", textBox12.Text);
                cmd.Parameters.AddWithValue("@lien", textBox13.Text);
                cmd.Parameters.AddWithValue("@sexe_r", comboBox3.Text);
                cmd.Parameters.AddWithValue("@grp", comboBox5.Text);
                cmd.Parameters.Add("@photo", SqlDbType.VarBinary);
                if (o.FileName != "")
                {
                    FileStream fs = new FileStream(o.FileName, FileMode.Open, FileAccess.Read);
                    byte[] t = new byte[fs.Length];
                    fs.Read(t, 0, (int)fs.Length);
                    cmd.Parameters["@photo"].Value = t;
                }
                else
                {
                    if (dt.Rows[0][20] == DBNull.Value) { cmd.Parameters["@photo"].Value = DBNull.Value; }
                    else
                    {
                        byte[] t = (byte[])dt.Rows[0][20];
                        cmd.Parameters["@photo"].Value = t;
                    }

                }

                cmd2.Parameters.AddWithValue("@cfe", uc_scan.v_cfe);
                cmd2.Parameters.AddWithValue("@detoir", comboBox7.Text);
                cmd2.Parameters.AddWithValue("@num_lit", comboBox9.Text);
                cmd2.Parameters.AddWithValue("@num_armoire", comboBox10.Text);

                cmd3.Parameters.AddWithValue("@cfe", uc_scan.v_cfe.ToString());
                cmd3.Parameters.AddWithValue("@detoir", comboBox7.Text);
                cmd3.Parameters.AddWithValue("@num_chambre", comboBox8.Text);
                cmd3.Parameters.AddWithValue("@num_lit", comboBox9.Text);
                cmd3.Parameters.AddWithValue("@num_armoire", comboBox10.Text);


                if (u > 0)
                {
                    throw new Exception("L'emplacement séléctionné est déjà affecté à un autre stagiaire.");
                }

                Form1.cx.Open();
                cmd.ExecuteNonQuery();
                if (dt2.Rows[0][0].ToString() == "Complete")
                {
                    cmd2.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                }
                Form1.cx.Close();
                uc_ajouter.lit = comboBox9.Text;
                uc_ajouter.detoir = comboBox7.Text;
                uc_ajouter.armoire = comboBox10.Text;
                uc_ajouter.chambre = comboBox8.Text;
                uc_ajouter.cfe = textBox1.Text;
                uc_ajouter.nom = textBox2.Text;
                uc_ajouter.prenom = textBox3.Text;
                uc_ajouter.groupe = comboBox5.Text;
                uc_ajouter.buandere = false;
                if (checkBox1.Checked) uc_ajouter.buandere = true;
                else uc_ajouter.buandere = false;
                if (checkBox1.Checked)
                {
                    byte[] temp = (byte[])dt.Rows[0][23];
                    MemoryStream stream = new MemoryStream(temp);
                    stream.Write(temp, 0, temp.Length);
                    uc_ajouter.bmp_qr = (Bitmap)Image.FromStream(stream);
                }
                else
                {
                    byte[] temp = (byte[])dt.Rows[0][24];
                    MemoryStream stream = new MemoryStream(temp);
                    stream.Write(temp, 0, temp.Length);
                    uc_ajouter.bmp_qr = (Bitmap)Image.FromStream(stream);
                }

                uc_ajouter.img_prohile = pictureBox1.Image;
                fr_carte_internat f = new fr_carte_internat();
                f.Show();
            }
            catch (Exception ex)
            {
                Form1.cx.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select groupe from filiere where nom_filiere='" + comboBox4.Text + "'", Form1.cx);

            Form1.cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            Form1.cx.Close();

            comboBox5.DataSource = dt;
            comboBox5.DisplayMember = "groupe";
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
