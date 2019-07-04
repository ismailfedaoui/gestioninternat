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
using System.Drawing.Imaging;
using MessagingToolkit.QRCode.Codec.Data;
namespace Projet_Gestion_Internat
{
    public partial class uc_ajouter : UserControl
    {
        int i;
        bool b = true;
        public static string lit;
        public static string detoir;
        public static string armoire;
        public static string chambre;
        public static string cfe;
        public static string nom;
        public static string prenom;
        public static string groupe;
        public static bool buandere = false;
        OpenFileDialog o = new OpenFileDialog();
        public static Bitmap bmp_qr;
        public static Image img_prohile;
       
        public uc_ajouter()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            fr_carte_internat f = new fr_carte_internat();
            f.Show();

        }

        private void uc_ajouter_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select distinct nom_filiere from filiere ", Form1.cx);

            Form1.cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            Form1.cx.Close();
            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "nom_filiere";
            comboBox3.Text = "";

            textBox5.Text = "Marocain(e)";
            pictureBox1.Load(Application.StartupPath + @"\facebookprofilepic.jpg");
            comboBox7.Items.Add('A');
            comboBox7.Items.Add('B');
            comboBox7.Items.Add('C');
            comboBox7.Items.Add('D');
            comboBox5.Items.Add("Homme");
            comboBox5.Items.Add("Femme");
            comboBox1.Items.Add("Garçon");
            comboBox1.Items.Add("Fille");
            comboBox2.Items.Add("Normal");
            comboBox2.Items.Add("Maitre");
            comboBox2.Items.Add("Exonéré");
            comboBox12.Items.Add("Complete");
            comboBox12.Items.Add("Demi pension");

            string anne_scolaire;
            if (DateTime.Now.Month == 9 | DateTime.Now.Month == 10 | DateTime.Now.Month == 11 | DateTime.Now.Month == 12)
                anne_scolaire = "1/9/" + DateTime.Now.Year.ToString();
            else
                anne_scolaire = "1/9/" + (DateTime.Now.Year - 1).ToString();

            SqlCommand cmd2 = new SqlCommand("select count(*) from chambre join stagiaire on chambre.id_chambre=stagiaire.#id_chambre join reçu on reçu.#cfe=stagiaire.cfe where date_paiement between '" + anne_scolaire + "' and '" + DateTime.Now.ToShortDateString()+"'", Form1.cx);
            Form1.cx.Open();
            i= (int)cmd2.ExecuteScalar();
            Form1.cx.Close();
            if (i > 136)
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
            b = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (o.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(o.FileName);

        }

       
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) comboBox8.Enabled = false;
            else comboBox8.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (o.FileName == "")
            {
                if (comboBox1.Text == "Fille") pictureBox1.Load(Application.StartupPath + @"\femme.jpg");
                else pictureBox1.Load(Application.StartupPath + @"\facebookprofilepic.jpg");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (b == false)
            {
                SqlCommand cmd = new SqlCommand("select groupe from filiere where nom_filiere='" + comboBox3.Text + "'", Form1.cx);
                Form1.cx.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();
                Form1.cx.Close();
                comboBox4.DataSource = dt;
                comboBox4.DisplayMember = "groupe";
            }
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            if (b == false)
            {
                SqlCommand cmd = new SqlCommand("select groupe from filiere where nom_filiere='" + comboBox3.Text + "'", Form1.cx);

                Form1.cx.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();
                Form1.cx.Close();

                comboBox4.DataSource = dt;
                comboBox4.DisplayMember = "groupe";
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tb_connecter_Click(object sender, EventArgs e)
        {
           
            string anne_scolaire;
            if (DateTime.Now.Month == 9 | DateTime.Now.Month == 10 | DateTime.Now.Month == 11 | DateTime.Now.Month == 12)
                anne_scolaire = "1/9/" + DateTime.Now.Year.ToString();
            else
                anne_scolaire = "1/9/" + (DateTime.Now.Year - 1).ToString();

            Form1.cx.Open();
            SqlTransaction tr;
            tr = Form1.cx.BeginTransaction();
            try
            {

                SqlCommand cmd123;
                if (groupBox3.Enabled == true)
                {
                    if (comboBox10.Text != comboBox9.Text) throw new Exception("le numéro d'armoire et le numéro de lit ne coincident pas.");
                    SqlCommand cmd44 = new SqlCommand("select count(*) from buanderie join stagiaire on buanderie.id_buanderie=stagiaire.#id_buanderie join reçu on reçu.#cfe=stagiaire.cfe where date_paiement between '" + anne_scolaire + "' and '" + DateTime.Now.ToShortDateString() + "'", Form1.cx);
                    cmd44.Transaction = tr;
                    int op = (int)cmd44.ExecuteScalar();
                    if ((op + i) >= 144) throw new Exception("Tous les detoirs sont pleins");
                    else
                    {
                        SqlCommand cmd16 = new SqlCommand("select count(*) from buanderie join stagiaire on buanderie.id_buanderie = stagiaire.#id_buanderie join reçu on reçu.#cfe=stagiaire.cfe where date_paiement between '" + anne_scolaire + "' and '" + DateTime.Now.ToShortDateString() + "' and buanderie.[#id_detoir]='" + comboBox7.Text + "'", Form1.cx);
                        cmd16.Transaction = tr;
                        int u = (int)cmd16.ExecuteScalar();
                        SqlCommand cmd162 = new SqlCommand(" select count(*) from chambre join stagiaire on stagiaire.#id_chambre = chambre.id_chambre join reçu on reçu.#cfe=stagiaire.cfe where date_paiement between '" + anne_scolaire + "' and '" + DateTime.Now.ToShortDateString() + "' and [#id_detoir]='" + comboBox7.Text + "'", Form1.cx);
                        cmd162.Transaction = tr;
                        int u2 = (int)cmd162.ExecuteScalar();
                        if ((u + u2) >= 34) throw new Exception("Ce detoir est saturé.");
                        else
                        {
                            if (checkBox1.Checked == true)
                            {
                                if (u >= 2) throw new Exception("Ce buanderie est saturé.");
                                else
                                {
                                    cmd123 = new SqlCommand("select count(*) from buanderie join stagiaire on buanderie.id_buanderie = stagiaire.#id_buanderie join reçu on reçu.#cfe=stagiaire.cfe where date_paiement between '" + anne_scolaire + "' and '" + DateTime.Now.ToShortDateString() + "' and  #id_detoir=@detoir and num_lit=@lit and num_armoire=@armoire", Form1.cx);
                                    cmd123.Parameters.AddWithValue("@detoir", comboBox7.Text);
                                    cmd123.Parameters.AddWithValue("@lit", comboBox9.Text);
                                    cmd123.Parameters.AddWithValue("@armoire", comboBox10.Text);
                                }
                            }
                            else
                            {

                                SqlCommand cmd163 = new SqlCommand(" select count(*) from chambre join stagiaire on stagiaire.#id_chambre = chambre.id_chambre join reçu on reçu.#cfe=stagiaire.cfe where date_paiement between '" + anne_scolaire + "' and '" + DateTime.Now.ToShortDateString() + "' and [#id_detoir]='" + comboBox7.Text + "' and num_chambre ='" + comboBox8.Text + "'", Form1.cx);
                                cmd163.Transaction = tr;
                                int u1 = (int)cmd163.ExecuteScalar();
                                if (u1 >= 4) throw new Exception("Cette chambre est saturée.");
                                else
                                {
                                    cmd123 = new SqlCommand("select count(*) from chambre join stagiaire on stagiaire.#id_chambre = chambre.id_chambre join reçu on reçu.#cfe=stagiaire.cfe where date_paiement between '" + anne_scolaire + "' and '" + DateTime.Now.ToShortDateString() + "' and num_chambre=@chambre and #id_detoir=@detoir and num_lit=@lit and num_armoire=@armoire", Form1.cx);
                                    cmd123.Parameters.AddWithValue("@detoir", comboBox7.Text);
                                    cmd123.Parameters.AddWithValue("@lit", comboBox9.Text);
                                    cmd123.Parameters.AddWithValue("@armoire", comboBox10.Text);
                                    cmd123.Parameters.AddWithValue("@chambre", comboBox8.Text);
                                }
                            }

                            cmd123.Transaction = tr;
                            int s = (int)cmd123.ExecuteScalar();
                            if (s > 0) throw new Exception("L'emplacement séléctionné est déjà affecté à un autre stagiaire.");

                        }
                       
                    }
                }

               
       




                SqlCommand cmd9 = new SqlCommand("select count(*) from stagiaire where cfe=" + textBox1.Text, Form1.cx);
                cmd9.Transaction = tr;
                int ik = (int)cmd9.ExecuteScalar();
                if (ik > 0) throw new Exception("Ce stagiaire existe déja.");


                int nombre_mois = 0;
                List<int> l_mois = new List<int>();
                if (checkBox2.Checked) { nombre_mois++; l_mois.Add(6); }

                if (checkBox3.Checked) { nombre_mois++; l_mois.Add(11); }
                if (checkBox4.Checked) { nombre_mois++; l_mois.Add(10); }
                if (checkBox5.Checked) { nombre_mois++; l_mois.Add(12); }
                if (checkBox6.Checked) { nombre_mois++; l_mois.Add(1); }
                if (checkBox7.Checked) { nombre_mois++; l_mois.Add(3); }
                if (checkBox8.Checked) { nombre_mois++; l_mois.Add(4); }
                if (checkBox9.Checked) { nombre_mois++; l_mois.Add(5); }
                if (checkBox10.Checked) { nombre_mois++; l_mois.Add(9); }
                if (checkBox11.Checked) { nombre_mois++; l_mois.Add(2); }

                if (((int.Parse(textBox13.Text) - 100) / nombre_mois) != 200 & comboBox12.Text == "Complete")
                {
                    throw new Exception("Vous devez saisir un montant correspondant pour le nombre des mois séléctionées (200Dhs/Mois + 100DHs).");
                }
                else if (((int.Parse(textBox13.Text) - 100) / nombre_mois) != 100 & comboBox12.Text == "Demi pension")
                {
                    throw new Exception("Vous devez saisir un montant correspondant pour le nombre des mois séléctionées (100Dhs/Mois + 100DHs).");
                }
                else
                {
                    if (groupBox3.Enabled)
                    {
                        lit = comboBox9.Text;
                        detoir = comboBox7.Text;
                        armoire = comboBox10.Text;
                        chambre = comboBox8.Text;

                                
                    }
                    else
                    {
                        lit = "";
                        detoir = "";
                        armoire = "";
                        chambre = "";
                    }
                   
                    cfe = textBox1.Text;
                    nom = textBox2.Text;
                    prenom = textBox3.Text;
                    groupe = comboBox4.Text;
                    if (checkBox1.Checked) buandere = false;
                    SqlCommand cmd = new SqlCommand("insert into v_ajouter_stg values(@cfe,@nom,@prenom,@datenaissance,@sexe,@telephone,@rue,@ville,@cp,@nationalité,@type_stagiaire,@photo,@qr_code,@nom_respo,@prenom_respo,@tel_respo,@lien,@sexe_respo,(select id_filiere from filiere where groupe=@grp),@carte,@num_chambre,@c_num_lit,@c_num_armoire,@id_detoir,@id_buanderie,@b_num_lit,@b_num_armoire,@id_gest,@pension)", Form1.cx);
                    cmd.Parameters.AddWithValue("@cfe", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@nom", textBox2.Text);
                    cmd.Parameters.AddWithValue("@prenom", textBox3.Text);
                    cmd.Parameters.AddWithValue("@datenaissance", dateTimePicker1.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@sexe", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@telephone", textBox4.Text);
                    cmd.Parameters.AddWithValue("@rue", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@ville", textBox6.Text);
                    cmd.Parameters.AddWithValue("@cp", int.Parse(textBox7.Text));
                    cmd.Parameters.AddWithValue("@nationalité", textBox5.Text);
                    cmd.Parameters.AddWithValue("@type_stagiaire", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@nom_respo", textBox8.Text);
                    cmd.Parameters.AddWithValue("@prenom_respo", textBox9.Text);
                    cmd.Parameters.AddWithValue("@tel_respo", textBox10.Text);
                    cmd.Parameters.AddWithValue("@lien", textBox11.Text);
                    cmd.Parameters.AddWithValue("@sexe_respo", comboBox5.Text);
                    cmd.Parameters.AddWithValue("@grp", comboBox4.Text);
                    if (groupBox3.Enabled == true)
                    {
                        cmd.Parameters.AddWithValue("@c_num_lit", int.Parse(comboBox9.Text));
                        cmd.Parameters.AddWithValue("@c_num_armoire", int.Parse(comboBox10.Text));
                        cmd.Parameters.AddWithValue("@id_detoir", comboBox7.Text);
                        if (checkBox1.Checked)
                        {
                            cmd.Parameters.AddWithValue("@num_chambre", 0);
                            cmd.Parameters.AddWithValue("@id_buanderie", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@num_chambre", int.Parse(comboBox8.Text));
                            cmd.Parameters.AddWithValue("@id_buanderie", 0);
                        }
                        cmd.Parameters.AddWithValue("@b_num_lit", int.Parse(comboBox9.Text));
                        cmd.Parameters.AddWithValue("@b_num_armoire", int.Parse(comboBox10.Text));
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@c_num_lit", 0);
                        cmd.Parameters.AddWithValue("@c_num_armoire", 0);
                        cmd.Parameters.AddWithValue("@id_detoir", 0);
                        cmd.Parameters.AddWithValue("@num_chambre", 0);
                        cmd.Parameters.AddWithValue("@id_buanderie", 0);
                        cmd.Parameters.AddWithValue("@b_num_lit", 0);
                        cmd.Parameters.AddWithValue("@b_num_armoire", 0);
                    }
                    
                    cmd.Parameters.AddWithValue("@id_gest", Form1.id_gest);
                    cmd.Parameters.Add("@photo", SqlDbType.VarBinary);
                    cmd.Parameters.AddWithValue("@pension", comboBox12.Text);
                    if (o.FileName != "")
                    {
                        FileStream fs = new FileStream(o.FileName, FileMode.Open, FileAccess.Read);
                        byte[] t = new byte[fs.Length];
                        fs.Read(t, 0, (int)fs.Length);
                        cmd.Parameters["@photo"].Value = t;
                    }
                    else
                        cmd.Parameters["@photo"].Value = DBNull.Value;
                    img_prohile = pictureBox1.Image;

                    MessagingToolkit.QRCode.Codec.QRCodeEncoder encoder = new MessagingToolkit.QRCode.Codec.QRCodeEncoder();
                    encoder.QRCodeScale = 8;
                    bmp_qr = encoder.Encode(textBox1.Text);

                    //bmp_qr.Save(Application.StartupPath+@"\qrcodes\", ImageFormat.Jpeg);
                    SaveFileDialog dialog = new SaveFileDialog();
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                      
                        bmp_qr.Save(dialog.FileName, ImageFormat.Jpeg);
                    }

                    MemoryStream STREAM = new MemoryStream();
                    bmp_qr.Save(STREAM, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] pic = STREAM.ToArray();
                    cmd.Parameters.AddWithValue("@qr_code", pic);

                    cmd.Parameters.Add("@carte", SqlDbType.VarBinary);
                    cmd.Parameters["@carte"].Value = DBNull.Value;
                    img_prohile = pictureBox1.Image;


                    SqlCommand cmd2 = new SqlCommand("insert into reçu values(@num_r,@date_paiement,@montant,@pension,@cfe,@nombre_mois)", Form1.cx);
                    cmd2.Parameters.AddWithValue("@num_r", textBox12.Text);
                    cmd2.Parameters.AddWithValue("@date_paiement", dateTimePicker2.Value.ToShortDateString());
                    cmd2.Parameters.AddWithValue("@montant", int.Parse(textBox13.Text));
                    cmd2.Parameters.AddWithValue("@pension", comboBox12.Text);
                    cmd2.Parameters.AddWithValue("@cfe", int.Parse(textBox1.Text));
                    cmd2.Parameters.AddWithValue("@nombre_mois", nombre_mois);





                    cmd.Transaction = tr;
                    cmd2.Transaction = tr;
                    cmd.ExecuteNonQuery();

                    cmd2.ExecuteNonQuery();

                    foreach (int i in l_mois)
                    {
                        SqlCommand cmd3 = new SqlCommand("insert into contribution_reçu values(" + i + ",'" + textBox12.Text + "')", Form1.cx);
                        cmd3.Transaction = tr;
                        cmd3.ExecuteNonQuery();

                    }

                    tr.Commit();
                    Form1.cx.Close();
                    fr_carte_internat f = new fr_carte_internat();
                    f.Show();

                }

            }
            catch (Exception ex)
            {
                tr.Rollback();
                Form1.cx.Close();
                MessageBox.Show(ex.Message, "Vérifier Les informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox12.Text == "Demi pension") { groupBox3.Enabled = false; }
            else
            {
                groupBox3.Enabled = true;

                SqlCommand cmd = new SqlCommand("select count(*) from chambre", Form1.cx);
                SqlCommand cmd2 = new SqlCommand("select count(*) from buanderie", Form1.cx);
                Form1.cx.Open();
                int k = (int)cmd.ExecuteScalar();
                int k2 = (int)cmd2.ExecuteScalar();
                Form1.cx.Close();
                if (k == 0)
                {

                    comboBox7.Text = "A";
                    comboBox8.Text = "1";
                    comboBox10.Text = "1";
                    comboBox9.Text = "1";
                    checkBox1.Checked = false;

                }
                else
                {
                    SqlCommand cmd3 = new SqlCommand("Select #id_detoir,num_chambre,num_lit from chambre where id_chambre=(select max(cast(id_chambre as int)) from chambre) order by id_chambre asc ", Form1.cx);
                    Form1.cx.Open();
                    SqlDataReader dr = cmd3.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    Form1.cx.Close();
                    if (dt.Rows[0][0].ToString() == "A")
                    {
                        if (int.Parse(dt.Rows[0][1].ToString()) <= 8)
                        {
                            if (int.Parse(dt.Rows[0][2].ToString()) < 4)
                            {
                                comboBox7.Text = "A";
                                comboBox8.Text = dt.Rows[0][1].ToString();
                                comboBox9.Text = (int.Parse(dt.Rows[0][2].ToString()) + 1).ToString();
                                comboBox10.Text = (int.Parse(dt.Rows[0][2].ToString()) + 1).ToString();
                            }
                            else
                            {
                                if (int.Parse(dt.Rows[0][1].ToString()) < 8)
                                {
                                    comboBox7.Text = "A";
                                    comboBox8.Text = (int.Parse(dt.Rows[0][1].ToString()) + 1).ToString();
                                    comboBox9.Text = "1";
                                    comboBox10.Text = "1";
                                }
                                else
                                {
                                    comboBox7.Text = "B";
                                    comboBox8.Text = "1";
                                    comboBox9.Text = "1";
                                    comboBox10.Text = "1";
                                }

                            }

                        }

                    }
                    if (dt.Rows[0][0].ToString() == "B")
                    {
                        if (int.Parse(dt.Rows[0][1].ToString()) <= 8)
                        {
                            if (int.Parse(dt.Rows[0][2].ToString()) < 4)
                            {
                                comboBox7.Text = "B";
                                comboBox8.Text = dt.Rows[0][1].ToString();
                                comboBox9.Text = (int.Parse(dt.Rows[0][2].ToString()) + 1).ToString();
                                comboBox10.Text = (int.Parse(dt.Rows[0][2].ToString()) + 1).ToString();
                            }
                            else
                            {
                                if (int.Parse(dt.Rows[0][1].ToString()) < 8)
                                {
                                    comboBox7.Text = "B";
                                    comboBox8.Text = (int.Parse(dt.Rows[0][1].ToString()) + 1).ToString();
                                    comboBox9.Text = "1";
                                    comboBox10.Text = "1";
                                }
                                else
                                {
                                    comboBox7.Text = "C";
                                    comboBox8.Text = "1";
                                    comboBox9.Text = "1";
                                    comboBox10.Text = "1";
                                }
                            }
                        }

                    }
                    if (dt.Rows[0][0].ToString() == "C")
                    {
                        if (int.Parse(dt.Rows[0][1].ToString()) <= 8)
                        {
                            if (int.Parse(dt.Rows[0][2].ToString()) < 4)
                            {
                                comboBox7.Text = "C";
                                comboBox8.Text = dt.Rows[0][1].ToString();
                                comboBox9.Text = (int.Parse(dt.Rows[0][2].ToString()) + 1).ToString();
                                comboBox10.Text = (int.Parse(dt.Rows[0][2].ToString()) + 1).ToString();
                            }
                            else
                            {
                                if (int.Parse(dt.Rows[0][1].ToString()) < 8)
                                {
                                    comboBox7.Text = "C";
                                    comboBox8.Text = (int.Parse(dt.Rows[0][1].ToString()) + 1).ToString();
                                    comboBox9.Text = "1";
                                    comboBox10.Text = "1";
                                }
                                else
                                {
                                    comboBox7.Text = "D";
                                    comboBox8.Text = "1";
                                    comboBox9.Text = "1";
                                    comboBox10.Text = "1";
                                }
                            }
                        }

                    }
                    if (dt.Rows[0][0].ToString() == "D")
                    {
                        if (int.Parse(dt.Rows[0][1].ToString()) <= 8)
                        {
                            if (int.Parse(dt.Rows[0][2].ToString()) < 4)
                            {
                                comboBox7.Text = "D";
                                comboBox8.Text = dt.Rows[0][1].ToString();
                                comboBox9.Text = (int.Parse(dt.Rows[0][2].ToString()) + 1).ToString();
                                comboBox10.Text = (int.Parse(dt.Rows[0][2].ToString()) + 1).ToString();
                            }
                            else
                            {
                                
                                    comboBox7.Text = "D";
                                    comboBox8.Text = (int.Parse(dt.Rows[0][1].ToString()) + 1).ToString();
                                    comboBox9.Text = "1";
                                    comboBox10.Text = "1";
                                
                            }
                        }

                    }
                }
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox10.Text = comboBox9.Text;
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox9.Text = comboBox10.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string anne_scolaire;
            if (DateTime.Now.Month == 9 | DateTime.Now.Month == 10 | DateTime.Now.Month == 11 | DateTime.Now.Month == 12)
                anne_scolaire = "1/9/" + DateTime.Now.Year.ToString();
            else
                anne_scolaire = "1/9/" + (DateTime.Now.Year - 1).ToString();

            SqlCommand cmd2 = new SqlCommand("select count(*) from chambre join stagiaire on chambre.id_chambre=stagiaire.#id_chambre join reçu on reçu.#cfe=stagiaire.cfe where date_paiement between '" + anne_scolaire + "' and '" + DateTime.Now.ToShortDateString() + "'", Form1.cx);
            Form1.cx.Open();
            i = (int)cmd2.ExecuteScalar();
            Form1.cx.Close();
            MessageBox.Show(i.ToString());
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

            if (o.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(o.FileName);

        }
    }
}