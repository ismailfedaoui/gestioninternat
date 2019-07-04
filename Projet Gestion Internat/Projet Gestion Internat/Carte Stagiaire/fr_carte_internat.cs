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
using System.IO;
using System.Drawing.Imaging;

namespace Projet_Gestion_Internat
{
    public partial class fr_carte_internat : Form
    {
        public static int cfe;
        public fr_carte_internat()
        {
            InitializeComponent();
        }

        private void fr_carte_internat_Load(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
            pictureBox2.Visible = false;
            pictureBox4.Visible = false;
            if (uc_ajouter.buandere == true) pictureBox1.Load(Application.StartupPath + @"\design-carte-buanderie.jpg");
            else
                pictureBox1.Load(Application.StartupPath + @"\design-carte-stg.jpg");



        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            try
            {

            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(pictureBox1.Image, 0, 0);

                Bitmap bmp = new Bitmap(209, 209);
                Graphics graphic = Graphics.FromImage(bmp);
                graphic.DrawImage(uc_ajouter.bmp_qr, 0, 0, 209, 209);
                graphic.Dispose();
                g.DrawImage(bmp, new PointF(158, 220));

                
                Bitmap bmp2 = new Bitmap(262, 304);
                Graphics graphic2 = Graphics.FromImage(bmp2);
                graphic2.DrawImage(uc_ajouter.img_prohile, 0, 0, 262, 304);
                graphic2.Dispose();
                g.DrawImage(bmp2, new PointF(712, 248));


                var fontfamily = new FontFamily("tahoma");
                var font = new Font(fontfamily, 21, FontStyle.Regular, GraphicsUnit.Pixel);
                var solidBrush2 = new SolidBrush(Color.Black);
               
                if (uc_ajouter.buandere == true)
                {

                    g.DrawString(uc_ajouter.cfe, font, solidBrush2, new PointF(218, 487));
                    //DETOIR
                    g.DrawString(uc_ajouter.detoir, font, solidBrush2, new PointF(218, 518));
                    //LIT
                    g.DrawString(uc_ajouter.lit, font, solidBrush2, new PointF(218, 555));
                    //ARMOIRE
                    g.DrawString(uc_ajouter.armoire, font, solidBrush2, new PointF(218, 588));
                }
                else
                {
                    g.DrawString(uc_ajouter.cfe, font, solidBrush2, new PointF(214, 494));
                    //DETOIR
                    g.DrawString(uc_ajouter.detoir, font, solidBrush2, new PointF(214, 540));
                    //CHAMBRE
                    g.DrawString(uc_ajouter.chambre, font, solidBrush2, new PointF(214, 588));
                    //LIT
                    g.DrawString(uc_ajouter.lit, font, solidBrush2, new PointF(435, 540));
                    //ARMOIRE
                    g.DrawString(uc_ajouter.armoire, font, solidBrush2, new PointF(435, 588));
                }
                   
                     font = new Font(fontfamily, 30, FontStyle.Bold, GraphicsUnit.Pixel);
                    var solidBrush = new SolidBrush(Color.White);
                    g.DrawString(uc_ajouter.nom.ToUpper() + " " + uc_ajouter.prenom.ToUpper(), font, solidBrush, new PointF(707, 107));
                    string anne_scolaire;
                    if (DateTime.Now.Month == 9 | DateTime.Now.Month == 10 | DateTime.Now.Month == 11 | DateTime.Now.Month == 12)
                        anne_scolaire = DateTime.Now.Year.ToString() + "/" + (DateTime.Now.Year + 1).ToString();
                    else
                        anne_scolaire = (DateTime.Now.Year - 1).ToString() + "/" + DateTime.Now.Year.ToString();
                    font = new Font(fontfamily, 22, FontStyle.Regular, GraphicsUnit.Pixel);
                    g.DrawString(uc_ajouter.groupe.ToUpper() + " - " + anne_scolaire, font, solidBrush, new PointF(770, 175));


                }

                
                SqlCommand cmd = new SqlCommand("update stagiaire set carte=@carte where cfe=@cfe", Form1.cx);
            cmd.Parameters.AddWithValue("@cfe", int.Parse(uc_ajouter.cfe));

            MemoryStream STREAM = new MemoryStream();
            bitmap.Save(STREAM, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] pic = STREAM.ToArray();
            cmd.Parameters.AddWithValue("@carte", pic);

            Form1.cx.Open();
            cmd.ExecuteNonQuery();
            Form1.cx.Close();
                pictureBox1.Visible = false;
                pictureBox3.Image = bitmap;
            } 
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            imprimer_carte f = new imprimer_carte();
            this.Hide();
            f.Show();

        }
    }
}
