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
    public class Usuario
    {
        DBAccess conexion = new DBAccess();

        /// <summary>
        /// Inicia Sesión utilizando datos del servidor
        /// </summary>
        /// <param name="email">Identificar o nombre de usuarios</param>
        /// <returns>
        /// objeto DataTable Conteniendo toda la fila (varios Campos)
        /// </returns>

        public DataTable iniciarSesion(string email)
        {
            //1. Objeto que contendrá el resultado
            DataTable dt = new DataTable();

            //2. Abrir Conexión
            conexion.abrirConexion();

            //3. Objeto para enviar consulta
            SqlCommand comando = new SqlCommand("spu_usuarios_login", conexion.Getconexion());

            //4. Tipo de comando (procedimiento almacenado)
            comando.CommandType = CommandType.StoredProcedure;

            //5. Pasar la(s) variable(s)
            comando.Parameters.AddWithValue("@email", email);

            //6. Ejecutar y obtener/leer los datos
            dt.Load(comando.ExecuteReader());

            //7. Cerrar
            conexion.cerrarConexion();

            //8. Retornamos el objeto con la info
            return dt;
        }

        public DataTable login(string email)
        {
            return conexion.listarDatosVariables("spu_usuarios_login", "@email", email);
        }

        public int Registrar(EUsuario entidad)
        {
            int totalRegistros = 0;
            SqlCommand comando = new SqlCommand("spu_usuarios_registrar", conexion.Getconexion());
            comando.CommandType = CommandType.StoredProcedure;

            conexion.abrirConexion();

            try
            {
                comando.Parameters.AddWithValue("@apellidos", entidad.apellidos);
                comando.Parameters.AddWithValue("@nombres", entidad.nombres);
                comando.Parameters.AddWithValue("@email", entidad.email);
                comando.Parameters.AddWithValue("@claveacceso", entidad.claveacceso);
                comando.Parameters.AddWithValue("@nivelacceso", entidad.nivelacceso);

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
            SqlCommand comando = new SqlCommand("spu_usuarios_listar",conexion.Getconexion());
            comando.CommandType = CommandType.StoredProcedure;

            conexion.abrirConexion();
            dt.Load(comando.ExecuteReader());
            conexion.cerrarConexion();

            return dt;
        }

    }
}
