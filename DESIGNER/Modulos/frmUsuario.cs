using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BOL;                      //Lógica
using ENTITIES;                 //Estructura
using DESIGNER.Tools;
using CryptSharp;

namespace DESIGNER.Modulos
{
    public partial class frmUsuario : Form
    {
        //Objeto "Usuario" Contiene las funciones/lógica => Registrar,Listar,Eliminar,etc.
        Usuario usuario = new Usuario();

        //Objeto "entUsuario" Contiene los datos => apellidos,nombres,email,claveacceso,nivelacceso,etc.
        EUsuario entUsuario = new EUsuario();

        string nivelAcceso = "INV";

        //Reservado en el espacio de memoria para el objeto (Vista de Datos)
        DataView dv;

        public frmUsuario()
        {
            InitializeComponent();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            actualizarDatos();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            nivelAcceso = "ADM";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Aviso.Preguntar("¿Estás Seguro de Guardar?") == DialogResult.Yes)
            {
                string claveEncriptada = Crypter.Blowfish.Crypt(txtClaveacceso.Text.Trim());
                entUsuario.apellidos = txtApellidos.Text;
                entUsuario.nombres = txtNombres.Text;
                entUsuario.email = txtEmail.Text;
                entUsuario.claveacceso = claveEncriptada;
                entUsuario.nivelacceso = nivelAcceso;

                if (usuario.Registrar(entUsuario) >0)
                {
                    reiniciarInterfaz();
                    actualizarDatos();
                    Aviso.Informar("Nuevo usuario registrado");
                }
                else
                {
                    Aviso.Advertir("No hemos podido terminar el registro");
                }
            }
        }

        private void actualizarDatos()
        {
            dv = new DataView(usuario.Listar());
            gridUsuarios.DataSource = dv;
            gridUsuarios.Refresh();

            gridUsuarios.Columns[0].Visible = false;//ID
            gridUsuarios.Columns[4].Visible = false;//CLAVE DE USUARIO

            gridUsuarios.Columns[1].Width = 289;//APELLIDOS
            gridUsuarios.Columns[2].Width = 289;//NOMBRES
            gridUsuarios.Columns[3].Width = 270;//EMAIL
            gridUsuarios.Columns[5].Width = 150;//NIVEL ACCESO

            gridUsuarios.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        private void reiniciarInterfaz()
        {
            txtApellidos.Clear();
            txtNombres.Clear();
            txtEmail.Clear();
            txtClaveacceso.Clear();
            optInvitado.Checked = true;
            nivelAcceso = "INV";
            txtApellidos.Focus();
        }

        private void optInvitado_CheckedChanged(object sender, EventArgs e)
        {
            nivelAcceso = "INV";
        }

        private void gridUsuarios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            gridUsuarios.ClearSelection();
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            dv.RowFilter = "apellidos LIKE '%" + txtBuscar.Text + "%' OR nombres LIKE '%" + txtBuscar.Text + "%'";
        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {

        }

        private void gridUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            reiniciarInterfaz();
        }
    }
}
