namespace OsanideDesktop
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            pictureBox1 = new PictureBox();
            label1 = new Label();
            txtSenha = new Guna.UI2.WinForms.Guna2TextBox();
            txtUsuario = new Guna.UI2.WinForms.Guna2TextBox();
            btnEntrar = new Guna.UI2.WinForms.Guna2Button();
            btnSair = new Guna.UI2.WinForms.Guna2Button();
            label2 = new Label();
            label3 = new Label();
            lblEsqueciSenha = new Label();
            lblCadastrar = new Label();
            mdEntrar = new Guna.UI2.WinForms.Guna2MessageDialog();
            chkSenha = new Guna.UI2.WinForms.Guna2CheckBox();
            mdSair = new Guna.UI2.WinForms.Guna2MessageDialog();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = Properties.Resources.round_logo1;
            pictureBox1.Location = new Point(258, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(300, 168);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(291, 190);
            label1.Name = "label1";
            label1.Size = new Size(242, 21);
            label1.TabIndex = 1;
            label1.Text = "Faça o login em nosso sistema";
            // 
            // txtSenha
            // 
            txtSenha.Anchor = AnchorStyles.None;
            txtSenha.BorderRadius = 15;
            txtSenha.CustomizableEdges = customizableEdges7;
            txtSenha.DefaultText = "";
            txtSenha.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSenha.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSenha.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSenha.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSenha.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSenha.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSenha.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSenha.Location = new Point(258, 334);
            txtSenha.Name = "txtSenha";
            txtSenha.PlaceholderText = "Insira sua senha";
            txtSenha.SelectedText = "";
            txtSenha.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtSenha.Size = new Size(300, 41);
            txtSenha.TabIndex = 2;
            txtSenha.UseSystemPasswordChar = true;
            txtSenha.KeyDown += txtSenha_KeyDown_1;
            // 
            // txtUsuario
            // 
            txtUsuario.Anchor = AnchorStyles.None;
            txtUsuario.BorderRadius = 15;
            txtUsuario.CustomizableEdges = customizableEdges5;
            txtUsuario.DefaultText = "";
            txtUsuario.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtUsuario.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtUsuario.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtUsuario.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtUsuario.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtUsuario.Font = new Font("Century Gothic", 9F);
            txtUsuario.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtUsuario.Location = new Point(258, 259);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.PlaceholderText = "Insira seu login";
            txtUsuario.SelectedText = "";
            txtUsuario.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtUsuario.Size = new Size(300, 41);
            txtUsuario.TabIndex = 3;
            txtUsuario.KeyDown += txtUsuario_KeyDown_1;
            // 
            // btnEntrar
            // 
            btnEntrar.Anchor = AnchorStyles.None;
            btnEntrar.BorderRadius = 15;
            btnEntrar.CustomizableEdges = customizableEdges3;
            btnEntrar.DisabledState.BorderColor = Color.DarkGray;
            btnEntrar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEntrar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEntrar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEntrar.FillColor = Color.FromArgb(2, 63, 29);
            btnEntrar.Font = new Font("Century Gothic", 9F);
            btnEntrar.ForeColor = Color.White;
            btnEntrar.Location = new Point(258, 462);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnEntrar.Size = new Size(142, 45);
            btnEntrar.TabIndex = 4;
            btnEntrar.Text = "Entrar";
            btnEntrar.Click += btnEntrar_Click;
            // 
            // btnSair
            // 
            btnSair.Anchor = AnchorStyles.None;
            btnSair.BorderRadius = 15;
            btnSair.CustomizableEdges = customizableEdges1;
            btnSair.DisabledState.BorderColor = Color.DarkGray;
            btnSair.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSair.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSair.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSair.FillColor = Color.FromArgb(64, 64, 64);
            btnSair.Font = new Font("Century Gothic", 9F);
            btnSair.ForeColor = Color.White;
            btnSair.Location = new Point(416, 462);
            btnSair.Name = "btnSair";
            btnSair.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnSair.Size = new Size(142, 45);
            btnSair.TabIndex = 4;
            btnSair.Text = "Sair";
            btnSair.Click += btnSair_Click_1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(258, 235);
            label2.Name = "label2";
            label2.Size = new Size(51, 21);
            label2.TabIndex = 1;
            label2.Text = "Login";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(258, 310);
            label3.Name = "label3";
            label3.Size = new Size(59, 21);
            label3.TabIndex = 1;
            label3.Text = "Senha";
            // 
            // lblEsqueciSenha
            // 
            lblEsqueciSenha.Anchor = AnchorStyles.None;
            lblEsqueciSenha.AutoSize = true;
            lblEsqueciSenha.Cursor = Cursors.Hand;
            lblEsqueciSenha.Location = new Point(319, 428);
            lblEsqueciSenha.Name = "lblEsqueciSenha";
            lblEsqueciSenha.Size = new Size(177, 21);
            lblEsqueciSenha.TabIndex = 1;
            lblEsqueciSenha.Text = "Esqueceu sua senha?";
            lblEsqueciSenha.Click += lblEsqueciSenha_Click_1;
            // 
            // lblCadastrar
            // 
            lblCadastrar.Anchor = AnchorStyles.None;
            lblCadastrar.AutoSize = true;
            lblCadastrar.Cursor = Cursors.Hand;
            lblCadastrar.Location = new Point(296, 549);
            lblCadastrar.Name = "lblCadastrar";
            lblCadastrar.Size = new Size(237, 42);
            lblCadastrar.TabIndex = 1;
            lblCadastrar.Text = "Ainda não está cadastrado?\r\nCadastre-se aqui!\r\n";
            lblCadastrar.TextAlign = ContentAlignment.MiddleCenter;
            lblCadastrar.Click += lblCadastrar_Click;
            // 
            // mdEntrar
            // 
            mdEntrar.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            mdEntrar.Caption = null;
            mdEntrar.Icon = Guna.UI2.WinForms.MessageDialogIcon.None;
            mdEntrar.Parent = this;
            mdEntrar.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            mdEntrar.Text = null;
            // 
            // chkSenha
            // 
            chkSenha.AutoSize = true;
            chkSenha.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            chkSenha.CheckedState.BorderRadius = 0;
            chkSenha.CheckedState.BorderThickness = 0;
            chkSenha.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            chkSenha.Location = new Point(490, 381);
            chkSenha.Name = "chkSenha";
            chkSenha.Size = new Size(68, 25);
            chkSenha.TabIndex = 5;
            chkSenha.Text = "Exibir";
            chkSenha.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            chkSenha.UncheckedState.BorderRadius = 0;
            chkSenha.UncheckedState.BorderThickness = 0;
            chkSenha.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
            chkSenha.CheckedChanged += chkSenha_CheckedChanged_1;
            // 
            // mdSair
            // 
            mdSair.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
            mdSair.Caption = null;
            mdSair.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
            mdSair.Parent = this;
            mdSair.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            mdSair.Text = null;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(800, 600);
            Controls.Add(chkSenha);
            Controls.Add(btnSair);
            Controls.Add(btnEntrar);
            Controls.Add(txtUsuario);
            Controls.Add(txtSenha);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblCadastrar);
            Controls.Add(lblEsqueciSenha);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmLogin";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private PictureBox pictureBox1;
        private Label label1;
        private Guna.UI2.WinForms.Guna2Button btnSair;
        private Guna.UI2.WinForms.Guna2Button btnEntrar;
        private Guna.UI2.WinForms.Guna2TextBox txtUsuario;
        private Guna.UI2.WinForms.Guna2TextBox txtSenha;
        private Label label3;
        private Label label2;
        private Label lblCadastrar;
        private Label lblEsqueciSenha;
        private Guna.UI2.WinForms.Guna2MessageDialog mdEntrar;
        private Guna.UI2.WinForms.Guna2CheckBox chkSenha;
        private Guna.UI2.WinForms.Guna2MessageDialog mdSair;
    }
}