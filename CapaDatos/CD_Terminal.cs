using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Terminal
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar(string terminal)
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "A02MostrarTerminal";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@TERMINAL", terminal);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }
    }
}
