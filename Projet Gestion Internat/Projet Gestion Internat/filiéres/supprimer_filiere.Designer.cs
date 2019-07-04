namespace Projet_Gestion_Internat
{
    partial class supprimer_filiere
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(supprimer_filiere));
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tb_connecter = new Bunifu.Framework.UI.BunifuThinButton2();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(76, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 124;
            this.label11.Text = "Groupe :";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(161, 77);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 123;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 122;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(76, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 121;
            this.label8.Text = "Filière :";
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(161, 50);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(121, 21);
            this.comboBox6.TabIndex = 120;
            this.comboBox6.SelectedIndexChanged += new System.EventHandler(this.comboBox6_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(12, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 11);
            this.label1.TabIndex = 125;
            this.label1.Text = "ATTENTION :";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(93, 158);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(281, 35);
            this.richTextBox1.TabIndex = 126;
            this.richTextBox1.Text = "Si vous supprimez cette filiére, tous les emplois de temps liés seront supprimés " +
    "mais les stagiaires sont gardés.";
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
            this.tb_connecter.ButtonText = "Supprimer";
            this.tb_connecter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tb_connecter.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_connecter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(69)))), ((int)(((byte)(240)))));
            this.tb_connecter.IdleBorderThickness = 2;
            this.tb_connecter.IdleCornerRadius = 1;
            this.tb_connecter.IdleFillColor = System.Drawing.Color.White;
            this.tb_connecter.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(69)))), ((int)(((byte)(240)))));
            this.tb_connecter.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(69)))), ((int)(((byte)(240)))));
            this.tb_connecter.Location = new System.Drawing.Point(161, 107);
            this.tb_connecter.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tb_connecter.Name = "tb_connecter";
            this.tb_connecter.Size = new System.Drawing.Size(84, 38);
            this.tb_connecter.TabIndex = 127;
            this.tb_connecter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tb_connecter.Click += new System.EventHandler(this.tb_connecter_Click);
            // 
            // supprimer_filiere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(390, 208);
            this.Controls.Add(this.tb_connecter);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox6);
            this.Name = "supprimer_filiere";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supprimer une filiére :";
            this.Load += new System.EventHandler(this.supprimer_filiere_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private Bunifu.Framework.UI.BunifuThinButton2 tb_connecter;
    }
}