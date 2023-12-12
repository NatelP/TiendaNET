using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Data.SqlClient;
namespace BOL
{
    public class Subcategoria
    {
        DBAccess conexion = new DBAccess();

        public DataTable Listar(int idcategoria)
        {
            return conexion.listarDatosVariables("spu_subcategorias_listar", "@idcategoria", idcategoria);
        }
    }
}
