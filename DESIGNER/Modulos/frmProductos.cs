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
    public partial class frmProductos : Form
    {
        Producto producto = new Producto();
        Categoria categoria = new Categoria();
        Subcategoria subcategoria = new Subcategoria();
        Marca marca = new Marca();
        Eproductos entProductos = new Eproductos();

        DataView dv;

        //Bandera = Variable Lógica que controla estados
        bool categoriasListas = false;

        public frmProductos()
        {
            InitializeComponent();
        }

        #region Métodos

        private void actualizarMarcas()
        {
            cboMarca.DataSource = marca.listar();
            cboMarca.DisplayMember = "marca"; //Mostrar
            cboMarca.ValueMember = "idmarca"; //PK (guarda)
            cboMarca.Refresh();
        }

        private void actualizarCategorias()
        {
            cboCategoria.DataSource = categoria.listar();
            cboCategoria.DisplayMember = "categoria";
            cboCategoria.ValueMember = "idcategoria";
            cboCategoria.Refresh();
        }

        private void actualizarProductos()
        {
            gridProductos.DataSource = producto.listar();
            gridProductos.Refresh();
        }

        #endregion

        private void frmProductos_Load(object sender, EventArgs e)
        {
            actualizarProductos();
            actualizarMarcas();
            actualizarCategorias();

            gridProductos.Columns[0].Visible = false;
            gridProductos.Columns[1].Width = 130;
            gridProductos.Columns[2].Width = 130;
            gridProductos.Columns[3].Width = 150;
            gridProductos.Columns[4].Width = 240;
            gridProductos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridProductos.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridProductos.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            categoriasListas = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (categoriasListas)
            {
                //Invocar al método que carga las subcategorias
                int idcategoria = Convert.ToInt32(cboCategoria.SelectedValue.ToString());
                cboSubcategoria.DataSource = subcategoria.Listar(idcategoria);
                cboSubcategoria.DisplayMember = "subcategoria";
                cboSubcategoria.ValueMember = "idsubcategoria";
                cboSubcategoria.Refresh();
                cboSubcategoria.Text = "";
            }
        }
        private void actualizarDatos()
        {
            dv = new DataView(producto.listar());
            gridProductos.DataSource = dv;
            gridProductos.Refresh();
        }
        private void reiniciarInterfaz()
        {
            cboMarca.Text = "";
            cboSubcategoria.Text = "";
            cboCategoria.Text = "";
            txtDescipcion.Clear();
            txtGarantia.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //1.Crear instancia del reporte (CrystalReport)
            Reportes.rptProductos reporte = new Reportes.rptProductos();
            //2.Asignar los datos del objeto reporte (creado en el paso 1)
            reporte.SetDataSource(producto.listar());
            reporte.Refresh();
            //3.Instanciar el formulario donde se mostrarán los reportes
            Reportes.VisorReportes formulario = new Reportes.VisorReportes();
            //4.Pasamos el reporte al visor
            formulario.visor.ReportSource = reporte;
            formulario.visor.Refresh();
            //5.Mostramos el formulario conteniendo el reporte
            formulario.ShowDialog();
        }
        /// <summary>
        /// Genera un archivo físico del reporte
        /// </summary>
        /// <param name="extension">Utilice: XLS o PDF</param>
        private void ExportarDatos(string extension)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Title = "Reporte de productos";
            sd.Filter = $"Archivos en formato {extension.ToUpper()}|*.{extension.ToLower()}";

            if (sd.ShowDialog() == DialogResult.OK)
            {
                //Creamos una version del reporte en formato PDF
                //1. Instancia del objeto reporte (CrystalReport)
                Reportes.rptProductos reporte = new Reportes.rptProductos();
                //2.Asignar los datos del objeto reporte (creado en el paso 1)
                reporte.SetDataSource(producto.listar());
                reporte.Refresh();
                //3.El reporte creado y en memoria se Escribirá en el STORAGE
                if (extension.ToUpper() == "PDF")
                {
                    reporte.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, sd.FileName);
                }
                else if (extension.ToUpper() == "XLSX")
                {
                    reporte.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.ExcelWorkbook, sd.FileName);
                }
                //4.Notificar al usuario la creación del archivo
                Aviso.Informar("Se ha creado el reporte Correctamente");
            }
        }

        private void exportabtnXLS_Click(object sender, EventArgs e)
        {
            ExportarDatos("XLSX");
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            ExportarDatos("PDF");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Aviso.Preguntar("¿Quieres guardar estos datos?") == DialogResult.Yes)
            {
                entProductos.idmarca = Convert.ToInt32(cboMarca.SelectedValue.ToString());
                entProductos.idsubcategoria = Convert.ToInt32(cboSubcategoria.SelectedValue.ToString());
                entProductos.descripcion = txtDescipcion.Text;
                entProductos.garantia = Convert.ToInt16(txtGarantia.ToString());
                entProductos.precio = Convert.ToDouble(txtPrecio.Text);
                entProductos.stock = Convert.ToInt32(txtStock.Text);

                if (producto.Registrar(entProductos) > 0)
                {
                    reiniciarInterfaz();
                    actualizarDatos();
                    Aviso.Informar("Producto Registrada");
                }
                else
                {
                    Aviso.Advertir("No se ha podido registrar el producto");
                }
            }
        }
    }
}
