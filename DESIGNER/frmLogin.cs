using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BOL;
using CryptSharp;
using DESIGNER.Tools;  //Traemos nuestras herramientas
namespace DESIGNER
{
    public partial class frmLogin : Form
    {
        Usuario usuario = new Usuario();
        DataTable dtRpta = new DataTable();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void Login()
        {
            if (textEmail.Text.Trim() == String.Empty)
            {
                errorLogin.SetError(textEmail, "Por favor Ingrese su Email");
                textEmail.Focus();
            }
            else
            {
                errorLogin.Clear();
                if (textClaveAcceso.Text.Trim() == String.Empty)
                {
                    errorLogin.SetError(textClaveAcceso, "Escriba su contraseña");
                    textClaveAcceso.Focus();
                }
                else
                {
                    errorLogin.Clear();

                    //Los datos fueron ingresados, validamos
                    dtRpta = usuario.iniciarSesion(textEmail.Text);

                    if (dtRpta.Rows.Count > 0)
                    {
                        string claveEncriptada = dtRpta.Rows[0][4].ToString();
                        string apellidos = dtRpta.Rows[0][1].ToString();
                        string nombres = dtRpta.Rows[0][2].ToString();

                        if (Crypter.CheckPassword(textClaveAcceso.Text, claveEncriptada))
                        {
                            Aviso.Informar($"Bienvenido {apellidos} {nombres}");
                            frmMain formMain = new frmMain(); 
                            formMain.Show(); //Abre el formulario Principal
                            this.Hide(); //Login se oculta
                        }

                        else
                        {
                            Aviso.Advertir("Error en la contraseña");
                        }
                    }
                    else
                    {
                        Aviso.Advertir("EL usuario Ingresado no existe");
                    }

                }
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void textClaveAcceso_TextChanged(object sender, EventArgs e)
        {

        }

        private void textClaveAcceso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Login();
            }
        }
    }
}
