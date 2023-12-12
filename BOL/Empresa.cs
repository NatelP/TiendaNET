using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENTITIES;
using System.Data;
using System.Data.SqlClient;

namespace BOL
{
    public class Empresa
    {
        DBAccess conexion = new DBAccess();

        public int Registrar (EEmpresa entidad)
        {
            int totalRegistros = 0;
            SqlCommand comando = new SqlCommand("spu_empresa_registrar", conexion.Getconexion());
            comando.CommandType = CommandType.StoredProcedure;

            conexion.abrirConexion();

            try
            {
                comando.Parameters.AddWithValue("@razonsocial", entidad.razonsocial);
                comando.Parameters.AddWithValue("@RUC", entidad.RUC);
                comando.Parameters.AddWithValue("@direccion", entidad.direccion);
                comando.Parameters.AddWithValue("@telefono", entidad.telefono);
                comando.Parameters.AddWithValue("@email", entidad.email);
                comando.Parameters.AddWithValue("@website", entidad.website);

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

        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            SqlCommand comand = new SqlCommand("spu_empresas_listar", conexion.Getconexion());
            comand.CommandType = CommandType.StoredProcedure;

            conexion.abrirConexion();
            dt.Load(comand.ExecuteReader());
            conexion.cerrarConexion();
            return dt;
        }

    }
}
