using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Registro
    {
        private CD_Registro objetoCD = new CD_Registro();

        public DataTable MostrarReg() {

            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public DataTable MostrarRegPM(int OID)
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarPM(OID);
            return tabla;
        }

        public DataTable MostrarRegPMCorreos(int OID)
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarPMCorreos(OID);
            return tabla;
        }

        public DataTable MostrarRegCor(int OID)
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarPM(OID);
            return tabla;
        }
        public void InsertarReg (DateTime fecha, string idPac, string nomPac, int asegur, int edad, string descrip, int relaci, string relMed,
            string relInv, string relLot, DateTime relFec, int repRol, string repNom, int regSed) 
        {

            objetoCD.Insertar(fecha,  idPac,  nomPac,  asegur,  edad,  descrip,  relaci,  relMed,
             relInv,  relLot, relFec,  repRol,  repNom,  regSed);
        }

        public void InsertarRegPlan(int OID,string que, string quien, string como, string donde, string cuando,int cumplio, string responsable, int verificado)
        {
            objetoCD.InsertarPlan(OID, que, quien, como, donde, cuando, cumplio, responsable, verificado);

        }

        public void InsertarRegCor(int EAOID, int correo)
        {
            objetoCD.InsertarCor(EAOID, correo);

        }
        public void EditarReg(DateTime fecha, string municipio, string id, string reporta, string evento, string oid)
        {
            objetoCD.Editar(fecha, municipio, id, reporta, evento, Convert.ToInt32(oid));
        }

        public void EliminarReg(string oid) {

            objetoCD.Eliminar(Convert.ToInt32(oid));
        }

    }
}
