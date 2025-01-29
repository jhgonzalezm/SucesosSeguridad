using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace CapaDatos
{
    public class CD_Usuarios
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar(string placa)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "A02QueryAF";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@PLACA", placa);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "A02QueryAFtb";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable MostrarCapturas(string terminal)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "A02QueryAFterminal";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@TERMINAL", terminal);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public void Insertar(DateTime fechaHora, string terminal, int area, string placa, string serial, string descripcion, string reporta, string observacion)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "S01InsertarReg";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@USUCODIGO", fechaHora);
            comando.Parameters.AddWithValue("@USUNOMBRE", terminal);
            comando.Parameters.AddWithValue("@USUCLAVE", area);
            comando.Parameters.AddWithValue("@USUPERFIL", placa);
            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
    }
}
