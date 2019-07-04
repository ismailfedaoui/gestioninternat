using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;
using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Data.SqlClient;

namespace Projet_Gestion_Internat
{
    public partial class fr_mot_de_passe_oublié : Form
    {
        Random r = new Random();
        string code_ver;
        public fr_mot_de_passe_oublié()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == code_ver)
            {
                fr_saisir_nv_mdp f = new fr_saisir_nv_mdp();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Le code tapé est incorrecte");
            }
        }

        private void fr_mot_de_passe_oublié_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            string result;
            SqlCommand cmd;
            if(Form1.pseudo==2)
                cmd= new SqlCommand("select telephone from gestionnaire where pseudo='"+form_pesuo_gest.pseudo+"'",Form1.cx);
            else
                cmd = new SqlCommand("select telephone from directeur", Form1.cx);
            Form1.cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            Form1.cx.Close();
            string apiKey = "your_api_key";
            string numbers = dt.Rows[0][0].ToString();  
            code_ver = "ISTA-MIR" + r.Next(1000,999999);
            string message = code_ver;
            string send = "I.S.T.A MIRLEFT";
            String url = "https://api.txtlocal.com/send/?apikey=" + apiKey + "&numbers=" + numbers + "&message=" + message + "&sender=" + send;
     

            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
            objRequest.Method = "POST";
            objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
            objRequest.ContentType = "application/x-www-form-urlencoded";
            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(url);
            }
            catch (Exception ex)
            {
              
                MessageBox.Show(null, "the error is" + ex, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                myWriter.Close();
            }

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                // Close and clean up the StreamReader
                sr.Close();
            }
            //return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result;
            SqlCommand cmd;
            if (Form1.pseudo == 2)
                cmd = new SqlCommand("select telephone from gestionnaire where pseudo='" + form_pesuo_gest.pseudo + "'", Form1.cx);
            else
                cmd = new SqlCommand("select telephone from directeur", Form1.cx);
            Form1.cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            Form1.cx.Close();
            string apiKey = "your_api_key";
            string numbers = dt.Rows[0][0].ToString();  // in a comma seperated list

            code_ver = "ISTA-MIR" + r.Next(1000, 999999);
            string message = code_ver;
            string send = "I.S.T.A MIRLEFT";
            String url = "https://api.txtlocal.com/send/?apikey=" + apiKey + "&numbers=" + numbers + "&message=" + message + "&sender=" + send;
            //refer to parameters to complete correct url string

            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
            objRequest.Method = "POST";
            objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
            objRequest.ContentType = "application/x-www-form-urlencoded";
            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(url);
            }
            catch (Exception ex)
            {
                //return e.Message;
                MessageBox.Show(null, "the error is" + ex, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                myWriter.Close();
            }

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                // Close and clean up the StreamReader
                sr.Close();
            }
            //return result;
        }

        private void tb_connecter_Click(object sender, EventArgs e)
        {
            string result;
            SqlCommand cmd;
            if (Form1.pseudo == 2)
                cmd = new SqlCommand("select telephone from gestionnaire where pseudo='" + form_pesuo_gest.pseudo + "'", Form1.cx);
            else
                cmd = new SqlCommand("select telephone from directeur", Form1.cx);
            Form1.cx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            Form1.cx.Close();
            string apiKey = "your_api_key";
            string numbers = dt.Rows[0][0].ToString();  // in a comma seperated list

            code_ver = "ISTA-MIR" + r.Next(1000, 999999);
            string message = code_ver;
            string send = "I.S.T.A MIRLEFT";
            String url = "https://api.txtlocal.com/send/?apikey=" + apiKey + "&numbers=" + numbers + "&message=" + message + "&sender=" + send;
            //refer to parameters to complete correct url string

            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
            objRequest.Method = "POST";
            objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
            objRequest.ContentType = "application/x-www-form-urlencoded";
            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(url);
            }
            catch (Exception ex)
            {
                //return e.Message;
                MessageBox.Show(null, "the error is" + ex, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                myWriter.Close();
            }

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                // Close and clean up the StreamReader
                sr.Close();
            }
            //return result;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == code_ver)
            {
                fr_saisir_nv_mdp f = new fr_saisir_nv_mdp();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Le code tapé est incorrecte");
            }
        }
    }
    
    
}
