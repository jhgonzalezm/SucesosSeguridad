using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Users
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public int Perfil { get; set; }
        public string Nombre { get; set; }

        
        //Conexión base de datos y variables a utilizar
        private CD_Conexion conexion = new CD_Conexion();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        //public CD_Users(string id, string password, int perfil, string nombre)
        //{
        //    Id = id;
        //    Password = password;
        //    Perfil = perfil;
        //    Nombre = nombre;
        //}

        //Autenticar en base de datos
        public DataTable AutenticarUsuario(string id, string password)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_GENUSUAUT";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ID", id);
            comando.Parameters.AddWithValue("@PASSWORD", password);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
    }
}
