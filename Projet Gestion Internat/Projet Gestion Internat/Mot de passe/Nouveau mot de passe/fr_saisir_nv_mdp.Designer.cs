namespace Projet_Gestion_Internat
{
    partial class fr_saisir_nv_mdp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fr_saisir_nv_mdp));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_connecter = new Bunifu.Framework.UI.BunifuThinButton2();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(267, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 20);
            this.textBox1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Taper votre nouveau mot de passe :";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(267, 72);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(120, 20);
            this.textBox2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Retaper votre nouveau mot de passe :";
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
            this.tb_connecter.ButtonText = "Enregitrer";
            this.tb_connecter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tb_connecter.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_connecter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(69)))), ((int)(((byte)(240)))));
            this.tb_connecter.IdleBorderThickness = 2;
            this.tb_connecter.IdleCornerRadius = 1;
            this.tb_connecter.IdleFillColor = System.Drawing.Color.White;
            this.tb_connecter.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(69)))), ((int)(((byte)(240)))));
            this.tb_connecter.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(69)))), ((int)(((byte)(240)))));
            this.tb_connecter.Location = new System.Drawing.Point(183, 109);
            this.tb_connecter.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tb_connecter.Name = "tb_connecter";
            this.tb_connecter.Size = new System.Drawing.Size(84, 38);
            this.tb_connecter.TabIndex = 126;
            this.tb_connecter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tb_connecter.Click += new System.EventHandler(this.tb_connecter_Click);
            // 
            // fr_saisir_nv_mdp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(454, 169);
            this.Controls.Add(this.tb_connecter);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Name = "fr_saisir_nv_mdp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fr_saisir_nv_mdp";
            this.Load += new System.EventHandler(this.fr_saisir_nv_mdp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuThinButton2 tb_connecter;
    }
}