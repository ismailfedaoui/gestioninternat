namespace Projet_Gestion_Internat
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tb_user = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.tb_connecter = new Bunifu.Framework.UI.BunifuThinButton2();
            this.tb_password = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuImageButton2 = new Bunifu.Framework.UI.BunifuImageButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkbox_gest = new Bunifu.Framework.UI.BunifuCheckbox();
            this.checkbox_dir = new Bunifu.Framework.UI.BunifuCheckbox();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_user
            // 
            this.tb_user.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(66)))), ((int)(((byte)(182)))));
            this.tb_user.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.tb_user.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(66)))), ((int)(((byte)(182)))));
            this.tb_user.BorderThickness = 3;
            this.tb_user.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_user.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.tb_user.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.tb_user.isPassword = false;
            this.tb_user.Location = new System.Drawing.Point(109, 215);
            this.tb_user.Margin = new System.Windows.Forms.Padding(4);
            this.tb_user.Name = "tb_user";
            this.tb_user.Size = new System.Drawing.Size(209, 33);
            this.tb_user.TabIndex = 10;
            this.tb_user.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // tb_connecter
            // 
            this.tb_connecter.ActiveBorderThickness = 1;
            this.tb_connecter.ActiveCornerRadius = 20;
            this.tb_connecter.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.tb_connecter.ActiveForecolor = System.Drawing.Color.White;
            this.tb_connecter.ActiveLineColor = System.Drawing.Color.SeaShell;
            this.tb_connecter.BackColor = System.Drawing.Color.White;
            this.tb_connecter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tb_connecter.BackgroundImage")));
            this.tb_connecter.ButtonText = "Connexion";
            this.tb_connecter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tb_connecter.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_connecter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.tb_connecter.IdleBorderThickness = 3;
            this.tb_connecter.IdleCornerRadius = 3;
            this.tb_connecter.IdleFillColor = System.Drawing.Color.White;
            this.tb_connecter.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.tb_connecter.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.tb_connecter.Location = new System.Drawing.Point(136, 347);
            this.tb_connecter.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tb_connecter.Name = "tb_connecter";
            this.tb_connecter.Size = new System.Drawing.Size(150, 47);
            this.tb_connecter.TabIndex = 11;
            this.tb_connecter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tb_connecter.Click += new System.EventHandler(this.tb_connecter_Click);
            // 
            // tb_password
            // 
            this.tb_password.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(66)))), ((int)(((byte)(182)))));
            this.tb_password.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.tb_password.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(66)))), ((int)(((byte)(182)))));
            this.tb_password.BorderThickness = 3;
            this.tb_password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_password.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.tb_password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.tb_password.isPassword = true;
            this.tb_password.Location = new System.Drawing.Point(109, 269);
            this.tb_password.Margin = new System.Windows.Forms.Padding(4);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(209, 33);
            this.tb_password.TabIndex = 12;
            this.tb_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label2.Location = new System.Drawing.Point(106, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Pseudo :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label3.Location = new System.Drawing.Point(106, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Mot de passe :";
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.BackColor = System.Drawing.Color.White;
            this.bunifuImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.Image")));
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(289, 275);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(23, 22);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 16;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 10;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // bunifuImageButton2
            // 
            this.bunifuImageButton2.BackColor = System.Drawing.Color.White;
            this.bunifuImageButton2.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton2.Image")));
            this.bunifuImageButton2.ImageActive = null;
            this.bunifuImageButton2.Location = new System.Drawing.Point(289, 275);
            this.bunifuImageButton2.Name = "bunifuImageButton2";
            this.bunifuImageButton2.Size = new System.Drawing.Size(23, 22);
            this.bunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton2.TabIndex = 17;
            this.bunifuImageButton2.TabStop = false;
            this.bunifuImageButton2.Zoom = 10;
            this.bunifuImageButton2.Click += new System.EventHandler(this.bunifuImageButton2_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.DarkSlateBlue;
            this.linkLabel1.Location = new System.Drawing.Point(110, 305);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(190, 13);
            this.linkLabel1.TabIndex = 18;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Vous avez oublié votre mot de passe ?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_Click);
            this.linkLabel1.DoubleClick += new System.EventHandler(this.linkLabel1_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label4.Location = new System.Drawing.Point(242, 330);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Getionnaire";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label1.Location = new System.Drawing.Point(147, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Directeur";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // checkbox_gest
            // 
            this.checkbox_gest.BackColor = System.Drawing.Color.Transparent;
            this.checkbox_gest.ChechedOffColor = System.Drawing.Color.Transparent;
            this.checkbox_gest.Checked = true;
            this.checkbox_gest.CheckedOnColor = System.Drawing.Color.Transparent;
            this.checkbox_gest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.checkbox_gest.Location = new System.Drawing.Point(222, 326);
            this.checkbox_gest.Name = "checkbox_gest";
            this.checkbox_gest.Size = new System.Drawing.Size(20, 20);
            this.checkbox_gest.TabIndex = 24;
            this.checkbox_gest.OnChange += new System.EventHandler(this.checkbox_gest_OnChange);
            // 
            // checkbox_dir
            // 
            this.checkbox_dir.BackColor = System.Drawing.Color.Transparent;
            this.checkbox_dir.ChechedOffColor = System.Drawing.Color.Transparent;
            this.checkbox_dir.Checked = true;
            this.checkbox_dir.CheckedOnColor = System.Drawing.Color.Transparent;
            this.checkbox_dir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.checkbox_dir.Location = new System.Drawing.Point(128, 325);
            this.checkbox_dir.Name = "checkbox_dir";
            this.checkbox_dir.Size = new System.Drawing.Size(20, 20);
            this.checkbox_dir.TabIndex = 23;
            this.checkbox_dir.OnChange += new System.EventHandler(this.checkbox_dir_OnChange);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(419, 499);
            this.Controls.Add(this.checkbox_dir);
            this.Controls.Add(this.checkbox_gest);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_connecter);
            this.Controls.Add(this.bunifuImageButton2);
            this.Controls.Add(this.bunifuImageButton1);
            this.Controls.Add(this.tb_user);
            this.Controls.Add(this.tb_password);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(435, 538);
            this.MinimumSize = new System.Drawing.Size(435, 538);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bienvenue";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuMetroTextbox tb_user;
        private Bunifu.Framework.UI.BunifuThinButton2 tb_connecter;
        private Bunifu.Framework.UI.BunifuMetroTextbox tb_password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuCheckbox checkbox_gest;
        private Bunifu.Framework.UI.BunifuCheckbox checkbox_dir;
    }
}

