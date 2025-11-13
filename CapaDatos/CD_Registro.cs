using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Registro
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar( int usuario) { 
       
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_EAGREGIS";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Clear();

            comando.Parameters.AddWithValue("@GENUSUARI", usuario);

            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
            
        }
        public DataTable MostrarPM(int OID)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_EAGMPLAN";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Clear();

            comando.Parameters.AddWithValue("@OID", OID);

            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        public DataTable MostrarPMCorreos(int OID)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_EAGCPLAN";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Clear();

            comando.Parameters.AddWithValue("@OID", OID);

            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }
        public void Insertar(DateTime fecha,string idPac,string nomPac,int asegur, int edad, string descrip, int relaci, string relMed, 
            string relInv, string relLot, DateTime relFec, int repRol, string repNom, int regSed ) {
            //REGISTRO INICIAL DEL SUCESO

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_EARREGIS";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Clear();

            comando.Parameters.AddWithValue("@EAID", 0);
            comando.Parameters.AddWithValue("@EAFECHA", fecha);
            comando.Parameters.AddWithValue("@EAIDPAC", idPac);
            comando.Parameters.AddWithValue("@EANOMPAC", nomPac);
            comando.Parameters.AddWithValue("@EAASEGUR", asegur);
            comando.Parameters.AddWithValue("@EAEDAD", edad);
            comando.Parameters.AddWithValue("@EADESCRIP", descrip);
            comando.Parameters.AddWithValue("@EARELACI", relaci);
            comando.Parameters.AddWithValue("@EARELMED", relMed);
            comando.Parameters.AddWithValue("@EARELINV", relInv);
            comando.Parameters.AddWithValue("@EARELLOT", relLot);
            comando.Parameters.AddWithValue("@EARELFEC", relFec);
            comando.Parameters.AddWithValue("@EAREPROL", repRol);
            comando.Parameters.AddWithValue("@EAREPNOM", repNom);
            comando.Parameters.AddWithValue("@EAREGSED", regSed);
            comando.Parameters.AddWithValue("@EAFECREG", fecha);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        
        }


        public void InsertarPlan(int EAOID, string que, string quien, string como, string donde, string cuando, int cumplio, string responsable, int verificado)
        {
            //REGISTRO INICIAL DEL SUCESO

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_EARMPLAN";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Clear();

            comando.Parameters.AddWithValue("@EAOID", EAOID);
            comando.Parameters.AddWithValue("@PMQUE", que);
            comando.Parameters.AddWithValue("@PMQUIEN", quien);
            comando.Parameters.AddWithValue("@PMCOMO", como);
            comando.Parameters.AddWithValue("@PMDONDE", donde);
            comando.Parameters.AddWithValue("@PMCUANDO", cuando);
            comando.Parameters.AddWithValue("@PMCUMPLIO", cumplio);
            comando.Parameters.AddWithValue("@PMRESPON", responsable);
            comando.Parameters.AddWithValue("@PMVERIFI", verificado);
            comando.Parameters.AddWithValue("@PMFECREG", DateTime.Now);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();

        }

        public void InsertarRegCor(int EAOID, int correo, int usuario)
        {
            //REGISTRO INICIAL DEL SUCESO

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_EARCPLAN";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Clear();


            comando.Parameters.AddWithValue("@EAOID", EAOID);
            comando.Parameters.AddWithValue("@PMCORREO", correo);
            comando.Parameters.AddWithValue("@GENUSUARI", usuario);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();

        }
        public void Editar(DateTime fecha, string municipio, string id, string reporta, string evento, int oid)
        {
            
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "A01EditarReg";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Clear();

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
            comando.Parameters.Clear();

            comando.Parameters.AddWithValue("@idpro",id);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
        public void updateRegAnalisis(int oid, int tipoReporte, int componente, int causaRaiz, string analizado, int estado, int londres)
        {
            //REGISTRO INICIAL DEL SUCESO

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_EAUANALI";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Clear();

            comando.Parameters.AddWithValue("@EAOID", oid);
            comando.Parameters.AddWithValue("@EAATIPRE", tipoReporte);
            comando.Parameters.AddWithValue("@EAACOMPO", componente);
            comando.Parameters.AddWithValue("@EAACAURA", causaRaiz);
            comando.Parameters.AddWithValue("@EAAANALI", analizado);
            comando.Parameters.AddWithValue("@EAAESTAD", estado);
            comando.Parameters.AddWithValue("@EAALONDR", londres);
            comando.ExecuteNonQuery();

            comando.Parameters.Clear();

        }

        public void updateRegProtocolo(int oid, string paciente, string tarea, string individuo, string equipo, string ambiente, string organizacion, string contexto)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_EAUPROTO";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Clear();

            comando.Parameters.AddWithValue("@EAOID", oid);
            comando.Parameters.AddWithValue("@EAPPACIE", paciente);
            comando.Parameters.AddWithValue("@EAPTAREA", tarea);
            comando.Parameters.AddWithValue("@EAPINDIV", individuo);
            comando.Parameters.AddWithValue("@EAPEQUTR", equipo);
            comando.Parameters.AddWithValue("@EAPAMBIE", ambiente);
            comando.Parameters.AddWithValue("@EAPORGAN", organizacion);
            comando.Parameters.AddWithValue("@EAPCONTE", contexto);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        //public void updateRegProtocolo2(int oid, string equipo, DateTime fecha, string historia, string protocolo, string declaraciones, string entrevista, string acciones, int codAcciones, string comunicacion, string lecciones)
        //{
        //    comando.Connection = conexion.AbrirConexion();
        //    comando.CommandText = "sp_EAUPROTO2";
        //    comando.CommandType = CommandType.StoredProcedure;
        //    comando.Parameters.Clear();

        //    comando.Parameters.AddWithValue("@EAOID", oid);
        //    comando.Parameters.AddWithValue("@EAPEQUIP", equipo);
        //    comando.Parameters.AddWithValue("@EAPFECHA", fecha);
        //    comando.Parameters.AddWithValue("@EAPHISTO", historia);
        //    comando.Parameters.AddWithValue("@EAPPROTO", declaraciones);
        //    comando.Parameters.AddWithValue("@EAPDECLA", declaraciones);
        //    comando.Parameters.AddWithValue("@EAPENTRE", entrevista);
        //    comando.Parameters.AddWithValue("@EAPACCIO", acciones);
        //    comando.Parameters.AddWithValue("@EAPINSEG", codAcciones);
        //    comando.Parameters.AddWithValue("@EAPCOMUN", comunicacion);
        //    comando.Parameters.AddWithValue("@EAPLECCI", lecciones);

        //    comando.ExecuteNonQuery();

        //    comando.Parameters.Clear();
        //}

    }
}
