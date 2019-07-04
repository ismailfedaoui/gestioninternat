namespace Projet_Gestion_Internat
{
    partial class fr_envoyer_sms
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fr_envoyer_sms));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_connecter = new Bunifu.Framework.UI.BunifuThinButton2();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(50, 45);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(356, 116);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Message :";
            // 
            // tb_connecter
            // 
            this.tb_connecter.ActiveBorderThickness = 1;
            this.tb_connecter.ActiveCornerRadius = 20;
            this.tb_connecter.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(69)))), ((int)(((byte)(240)))));
            this.tb_connecter.ActiveForecolor = System.Drawing.Color.White;
            this.tb_connecter.ActiveLineColor = System.Drawing.Color.SeaShell;
            this.tb_connecter.BackColor = System.Drawing.Color.White;
            this.tb_connecter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tb_connecter.BackgroundImage")));
            this.tb_connecter.ButtonText = "Envoyer";
            this.tb_connecter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tb_connecter.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_connecter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(69)))), ((int)(((byte)(240)))));
            this.tb_connecter.IdleBorderThickness = 2;
            this.tb_connecter.IdleCornerRadius = 1;
            this.tb_connecter.IdleFillColor = System.Drawing.Color.White;
            this.tb_connecter.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(69)))), ((int)(((byte)(240)))));
            this.tb_connecter.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(69)))), ((int)(((byte)(240)))));
            this.tb_connecter.Location = new System.Drawing.Point(322, 165);
            this.tb_connecter.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tb_connecter.Name = "tb_connecter";
            this.tb_connecter.Size = new System.Drawing.Size(84, 38);
            this.tb_connecter.TabIndex = 125;
            this.tb_connecter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tb_connecter.Click += new System.EventHandler(this.tb_connecter_Click);
            // 
            // fr_envoyer_sms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(454, 224);
            this.Controls.Add(this.tb_connecter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox1);
            this.Name = "fr_envoyer_sms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fr_envoyer_sms";
            this.Load += new System.EventHandler(this.fr_envoyer_sms_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuThinButton2 tb_connecter;
    }
}