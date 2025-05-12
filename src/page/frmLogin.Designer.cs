namespace applicationOccasAuto
{
    partial class frmLogin
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbPasswd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.llReset = new System.Windows.Forms.LinkLabel();
            this.btnShowPass = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLogin.Location = new System.Drawing.Point(321, 395);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(177, 67);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Se connecter";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tbUser
            // 
            this.tbUser.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbUser.Location = new System.Drawing.Point(280, 169);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(242, 22);
            this.tbUser.TabIndex = 1;
            // 
            // tbPasswd
            // 
            this.tbPasswd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbPasswd.Location = new System.Drawing.Point(280, 238);
            this.tbPasswd.Name = "tbPasswd";
            this.tbPasswd.PasswordChar = '*';
            this.tbPasswd.Size = new System.Drawing.Size(242, 22);
            this.tbPasswd.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(277, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Identifiant (nom.prenom):";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mot de Passe:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(280, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(245, 76);
            this.label3.TabIndex = 5;
            this.label3.Text = "LOGIN";
            // 
            // llReset
            // 
            this.llReset.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.llReset.AutoSize = true;
            this.llReset.Location = new System.Drawing.Point(277, 277);
            this.llReset.Name = "llReset";
            this.llReset.Size = new System.Drawing.Size(194, 16);
            this.llReset.TabIndex = 6;
            this.llReset.TabStop = true;
            this.llReset.Text = "Réinitialiser mon mot de passe.";
            this.llReset.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llReset_LinkClicked);
            // 
            // btnShowPass
            // 
            this.btnShowPass.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnShowPass.Location = new System.Drawing.Point(528, 238);
            this.btnShowPass.Name = "btnShowPass";
            this.btnShowPass.Size = new System.Drawing.Size(70, 23);
            this.btnShowPass.TabIndex = 7;
            this.btnShowPass.Text = "Afficher";
            this.btnShowPass.UseVisualStyleBackColor = true;
            this.btnShowPass.Click += new System.EventHandler(this.btnShowPass_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 497);
            this.Controls.Add(this.btnShowPass);
            this.Controls.Add(this.llReset);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPasswd);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.btnLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.Text = "frmLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbPasswd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel llReset;
        private System.Windows.Forms.Button btnShowPass;
    }
}