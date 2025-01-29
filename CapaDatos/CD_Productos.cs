using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Productos
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar() { 
       
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "A01MostrarReg";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
            
        }

        public void Insertar(DateTime fecha,string municipio,string id,string reporta, string evento ) {
            //PROCEDIMNIENTO
            
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "A01InsertarReg";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@fecha",fecha);
            comando.Parameters.AddWithValue("@municipio",municipio);
            comando.Parameters.AddWithValue("@id",id);
            comando.Parameters.AddWithValue("@reporta",reporta);
            comando.Parameters.AddWithValue("@evento",evento);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        
        }

        public void Editar(DateTime fecha, string municipio, string id, string reporta, string evento, int oid)
        {
            
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "A01EditarReg";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@fecha", fecha);
            comando.Parameters.AddWithValue("@municipio", municipio);
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@reporta", reporta);
            comando.Parameters.AddWithValue("@evento", evento);
            comando.Parameters.AddWithValue("@oid",oid);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        public void Eliminar(int id) {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "A01EliminarReg";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idpro",id);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

    }
}
