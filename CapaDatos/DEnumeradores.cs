using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class DEnumeradores
    {

        DataTable tabla = new DataTable();
        private CD_Conexion conexion = new CD_Conexion();

        private string _Sp_sql;
        private int _Criterio;

        public string Sp_sql
        {
            get { return _Sp_sql; }
            set { _Sp_sql = value; }
        }
        public int Criterio
        {
            get { return _Criterio; }
            set { _Criterio = value; }
        }

        // Constructor vacío
        public DEnumeradores ()
        {

        }

        public DEnumeradores(string sp_sql, int criterio)
        {
            this.Sp_sql = sp_sql;
            this.Criterio = criterio;
        }

        // Metodos
        public DataSet CargarOpciones(DEnumeradores Query)
        {
            DataSet DsResultado = new DataSet("tabla");
            SqlConnection SqlCon = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = Query.Sp_sql;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@CRITERIO", Query.Criterio);

                SqlDataAdapter SqlDat = new SqlDataAdapter(comando);
                SqlDat.Fill(DsResultado);

            }
            catch (Exception ex)
            {
                DsResultado = null;
                Console.WriteLine("There was an error: {0}", ex.Message);
            }
            return DsResultado;
        }
    }
}
