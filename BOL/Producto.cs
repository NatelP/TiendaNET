using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DAL;
using ENTITIES;

namespace BOL
{
    public class Producto
    {
        DBAccess conexion = new DBAccess();

        public DataTable listar()
        {
            return conexion.listarDatos("spu_productos_listar");
        }

        public int Registrar(Eproductos entidad)
        {
            int totalRegistros;
            conexion.abrirConexion();

            try
            {
                SqlCommand comando = new SqlCommand("spu_productos_registrar", conexion.Getconexion());
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@idmarca", entidad.idmarca);
                comando.Parameters.AddWithValue("@idsubcategoria", entidad.idsubcategoria);
                comando.Parameters.AddWithValue("@stock", entidad.stock);
                comando.Parameters.AddWithValue("@garantia", entidad.garantia);
                comando.Parameters.AddWithValue("@descripcion", entidad.descripcion);
                comando.Parameters.AddWithValue("@tprecio", entidad.precio);

                totalRegistros = comando.ExecuteNonQuery();
            }
            catch
            {
                totalRegistros = -1;
            }
            finally
            {
                conexion.cerrarConexion();
            }
            return totalRegistros;
        }
    }
}
