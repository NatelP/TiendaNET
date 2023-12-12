using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ENTITIES;
using DESIGNER.Tools;
using BOL;


namespace DESIGNER.Modulos
{
    public partial class formEmpresa : Form
    {

        Empresa empresa = new Empresa();
        EEmpresa entEmpresa = new EEmpresa();

        string direccion = "NULL";
        string telefono = "NULL";
        string email = "NULL";
        string website = "NULL";

        DataView dv;

        public formEmpresa()
        {
            InitializeComponent();
        }
        private void frmempresa_Load(object sender,EventArgs e)
        {
            actualizarDatos();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(Aviso.Preguntar("¿Quieres guardar estos datos?") == DialogResult.Yes)
            {
                entEmpresa.razonsocial = txtRazonsocial.Text;
                entEmpresa.RUC = txtRUC.Text;
                entEmpresa.direccion = txtDireccion.Text;
                entEmpresa.telefono = txtTelefono.Text;
                entEmpresa.email = txtEmail.Text;
                entEmpresa.website = txtWebsite.Text;

                if (empresa.Registrar(entEmpresa) > 0)
                {
                    reiniciarInterfaz();
                    actualizarDatos();
                    Aviso.Informar("Empresa Registrada");
                }
                else
                {
                    Aviso.Advertir("No se ha podido registrar la empresa");
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void actualizarDatos()
        {
            dv = new DataView(empresa.Listar());
            grdEmpresas.DataSource = dv;
            grdEmpresas.Refresh();

            grdEmpresas.Columns[0].Visible = false;

            grdEmpresas.Columns[1].Width = 300;
            grdEmpresas.Columns[3].Width = 200;
            grdEmpresas.Columns[5].Width = 150;
            grdEmpresas.Columns[6].Width = 150;

        }
        private void reiniciarInterfaz()
        {
            txtRazonsocial.Clear();
            txtRUC.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtEmail.Clear();
            txtWebsite.Clear();
            txtRazonsocial.Focus();
        }
        private void grdEmpresas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdEmpresas.ClearSelection();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            reiniciarInterfaz();
        }

        private void formEmpresa_Load(object sender, EventArgs e)
        {
            actualizarDatos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscar_KeyUp_1(object sender, KeyEventArgs e)
        {
            dv.RowFilter = "razonsocial LIKE '%" + txtBuscar.Text + "%' OR RUC LIKE '%" + txtBuscar.Text + "%'";
        }
    }
}
