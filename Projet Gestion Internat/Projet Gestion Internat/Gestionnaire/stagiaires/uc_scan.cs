using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.Aztec;
using ZXing.QrCode;
using System.Data.SqlClient;
using MessagingToolkit.QRCode.Codec.Data;
namespace Projet_Gestion_Internat
{
    public partial class uc_scan : UserControl
    {
        private FilterInfoCollection CaptureDevice;
        private VideoCaptureDevice FinalFrame;
        string decoded;
        public static int v_cfe ;
        int i = 0;
        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Image)eventArgs.Frame.Clone();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            BarcodeReader Reader = new BarcodeReader();
            Result result = Reader.Decode((Bitmap)pictureBox1.Image);


            try
            {
                decoded = result.ToString().Trim();
                textBox1.Text = decoded;
                v_cfe = Int32.Parse(textBox1.Text);
                SqlCommand cmd = new SqlCommand("select count(*) from stagiaire where cfe=" + decoded, Form1.cx);
                Form1.cx.Open();
                i = (int)cmd.ExecuteScalar();
                Form1.cx.Close();
                if (i > 0)
                {
                    v_cfe = int.Parse(textBox1.Text);

                    if (uc_stagiaire.v_operation == "modifier")
                    {
                        panel1.Controls.Clear();
                        uc_modifier uc_modifier = new uc_modifier();
                        panel1.Controls.Add(uc_modifier);

                    }
                    else if (uc_stagiaire.v_operation == "supprimer")
                    {
                        panel1.Controls.Clear();
                        uc_supprimer uc_supprimer = new uc_supprimer();
                        panel1.Controls.Add(uc_supprimer);

                    }
                    else if (uc_stagiaire.v_operation == "scanner")
                    {
                        panel1.Controls.Clear();
                        uc_details_scan uc_details_scan = new uc_details_scan();
                        panel1.Controls.Add(uc_details_scan);
                    }

                }
                else MessageBox.Show("Ce stagiaire n'existe pas. Veuillez vérifier le CFE");




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public uc_scan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            v_cfe = Int32.Parse(textBox1.Text);
            SqlCommand cmd = new SqlCommand("select count(*) from stagiaire where cfe=" + v_cfe.ToString(), Form1.cx);
            Form1.cx.Open();
            i = (int)cmd.ExecuteScalar();
            Form1.cx.Close();
            if (i > 0)
            {
                v_cfe = int.Parse(textBox1.Text);

                if (uc_stagiaire.v_operation == "modifier")
                {
                    panel1.Controls.Clear();
                    uc_modifier uc_modifier = new uc_modifier();
                    panel1.Controls.Add(uc_modifier);
                   
                }
                else if(uc_stagiaire.v_operation == "supprimer")
                {
                    panel1.Controls.Clear();
                    uc_supprimer uc_supprimer = new uc_supprimer();
                    panel1.Controls.Add(uc_supprimer);
                 
                }
                else if(uc_stagiaire.v_operation == "scanner")
                {
                    panel1.Controls.Clear();
                   uc_details_scan uc_details_scan = new uc_details_scan();
                    panel1.Controls.Add(uc_details_scan);
                }
                
            }
            else MessageBox.Show("Ce stagiaire n'existe pas. Veuillez vérifier le CFE");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uc_scan_Load(object sender, EventArgs e)
        {

            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in CaptureDevice)
            {
                comboBox1.Items.Add(Device.Name);
            }
            comboBox1.SelectedIndex = 0;

            FinalFrame = new VideoCaptureDevice(CaptureDevice[comboBox1.SelectedIndex].MonikerString);
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
           
            comboBox1.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FinalFrame.Start();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            v_cfe = Int32.Parse(textBox1.Text);
            SqlCommand cmd = new SqlCommand("select count(*) from stagiaire where cfe=" + v_cfe.ToString(), Form1.cx);
            Form1.cx.Open();
            i = (int)cmd.ExecuteScalar();
            Form1.cx.Close();
            if (i > 0)
            {
                v_cfe = int.Parse(textBox1.Text);

                if (uc_stagiaire.v_operation == "modifier")
                {
                    panel1.Controls.Clear();
                    uc_modifier uc_modifier = new uc_modifier();
                    panel1.Controls.Add(uc_modifier);

                }
                else if (uc_stagiaire.v_operation == "supprimer")
                {
                    panel1.Controls.Clear();
                    uc_supprimer uc_supprimer = new uc_supprimer();
                    panel1.Controls.Add(uc_supprimer);

                }
                else if (uc_stagiaire.v_operation == "scanner")
                {
                    panel1.Controls.Clear();
                    uc_details_scan uc_details_scan = new uc_details_scan();
                    panel1.Controls.Add(uc_details_scan);
                }
                

            }
            else MessageBox.Show("Ce stagiaire n'existe pas. Veuillez vérifier le CFE");
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            FinalFrame.Start();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG | *.jpg", ValidateNames = true, Multiselect = false })
            {
                FinalFrame.Stop();
                if (ofd.ShowDialog() == DialogResult.OK)
                {

                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                    MessagingToolkit.QRCode.Codec.QRCodeDecoder decoder = new MessagingToolkit.QRCode.Codec.QRCodeDecoder();
                    textBox1.Text = decoder.decode(new QRCodeBitmapImage(pictureBox1.Image as Bitmap));
                    v_cfe = Int32.Parse(textBox1.Text);
                    SqlCommand cmd = new SqlCommand("select count(*) from stagiaire where cfe=" + v_cfe.ToString(), Form1.cx);
                    Form1.cx.Open();
                    i = (int)cmd.ExecuteScalar();
                    Form1.cx.Close();
                    if (i > 0)
                    {
                        v_cfe = int.Parse(textBox1.Text);

                        if (uc_stagiaire.v_operation == "modifier")
                        {
                            panel1.Controls.Clear();
                            uc_modifier uc_modifier = new uc_modifier();
                            panel1.Controls.Add(uc_modifier);

                        }
                        else if (uc_stagiaire.v_operation == "supprimer")
                        {
                            panel1.Controls.Clear();
                            uc_supprimer uc_supprimer = new uc_supprimer();
                            panel1.Controls.Add(uc_supprimer);

                        }
                        else if (uc_stagiaire.v_operation == "scanner")
                        {
                            panel1.Controls.Clear();
                            uc_details_scan uc_details_scan = new uc_details_scan();
                            panel1.Controls.Add(uc_details_scan);
                        }


                    }
                    else MessageBox.Show("Ce stagiaire n'existe pas. Veuillez vérifier le CFE");
                }
            }
        }
    }
}
