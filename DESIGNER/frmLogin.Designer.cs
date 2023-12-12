
namespace DESIGNER
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
            this.components = new System.ComponentModel.Container();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.textClaveAcceso = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.errorLogin = new System.Windows.Forms.ErrorProvider(this.components);
            this.btAcercaDe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIniciar.Location = new System.Drawing.Point(75, 301);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(273, 30);
            this.btnIniciar.TabIndex = 5;
            this.btnIniciar.Text = "Iniciar Sesion";
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFinalizar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFinalizar.Location = new System.Drawing.Point(76, 337);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(273, 30);
            this.btnFinalizar.TabIndex = 6;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Perpetua Titling MT", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Acceso al sistema";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // textEmail
            // 
            this.textEmail.BackColor = System.Drawing.Color.White;
            this.textEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEmail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textEmail.Location = new System.Drawing.Point(75, 142);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(273, 20);
            this.textEmail.TabIndex = 2;
            this.textEmail.TextChanged += new System.EventHandler(this.textEmail_TextChanged);
            // 
            // textClaveAcceso
            // 
            this.textClaveAcceso.BackColor = System.Drawing.Color.White;
            this.textClaveAcceso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textClaveAcceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textClaveAcceso.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textClaveAcceso.Location = new System.Drawing.Point(75, 211);
            this.textClaveAcceso.Name = "textClaveAcceso";
            this.textClaveAcceso.PasswordChar = '*';
            this.textClaveAcceso.Size = new System.Drawing.Size(273, 20);
            this.textClaveAcceso.TabIndex = 4;
            this.textClaveAcceso.TextChanged += new System.EventHandler(this.textClaveAcceso_TextChanged);
            this.textClaveAcceso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textClaveAcceso_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(71, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Correo Electrónico";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(71, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Clave de Acceso";
            // 
            // errorLogin
            // 
            this.errorLogin.ContainerControl = this;
            // 
            // btAcercaDe
            // 
            this.btAcercaDe.Location = new System.Drawing.Point(75, 373);
            this.btAcercaDe.Name = "btAcercaDe";
            this.btAcercaDe.Size = new System.Drawing.Size(274, 29);
            this.btAcercaDe.TabIndex = 7;
            this.btAcercaDe.Text = "Acerca de";
            this.btAcercaDe.UseVisualStyleBackColor = true;
            this.btAcercaDe.Click += new System.EventHandler(this.btAcercaDe_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 448);
            this.Controls.Add(this.btAcercaDe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textClaveAcceso);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.btnIniciar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.TextBox textClaveAcceso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorLogin;
        private System.Windows.Forms.Button btAcercaDe;
    }
}