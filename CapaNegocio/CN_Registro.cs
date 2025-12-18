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

        public DataTable MostrarReg( int usuario) {
            DataTable tabla = new DataTable();
            tabla.Rows.Clear();
            tabla = objetoCD.Mostrar( usuario );
            return tabla;
        }
        public DataTable MostrarPM(int OID)
        {
            DataTable tabla = new DataTable();
            tabla.Rows.Clear();
            tabla = objetoCD.MostrarPM(OID);
            return tabla;
        }

        public DataTable MostrarRegPMCorreos(int OID)
        {
            DataTable tabla = new DataTable();
            tabla.Rows.Clear();
            tabla = objetoCD.MostrarPMCorreos(OID);
            return tabla;
        }

        public DataTable MostrarRegCor(int OID)
        {
            DataTable tabla = new DataTable();
            tabla.Rows.Clear();
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

        public void updatePM(int OID, string que, string quien, string como, string donde, string cuando, int cumplio, string responsable, int verificado, int oidPM)
        {
            objetoCD.updatePM(OID, que, quien, como, donde, cuando, cumplio, responsable, verificado, oidPM);
        }

        public void InsertarRegCor(int EAOID, int correo, int usuario)
        {
            objetoCD.InsertarRegCor(EAOID, correo, usuario);
        }
        public void EditarReg(DateTime fecha, string municipio, string id, string reporta, string evento, string oid)
        {
            objetoCD.Editar(fecha, municipio, id, reporta, evento, Convert.ToInt32(oid));
        }

        public void EliminarReg(string oid) {
            objetoCD.Eliminar(Convert.ToInt32(oid));
        }

        public void UpdateRegAnalisis(int oid, int tipoReporte, int componente, int causaRaiz, string analizado, int estado, int londres)
        {
            objetoCD.updateRegAnalisis(oid,  tipoReporte, componente,  causaRaiz,  analizado,  estado, londres);
        }

        public void UpdateRegProtocolo(int oid, string paciente, string tarea, string individuo, string equipo, string ambiente, string organizacion, string contexto, string equipoInv, DateTime fecha, string historia, string protocolo, string declaraciones, string entrevista, string acciones, int codAcciones, string comunicacion, string lecciones)
        {
            objetoCD.updateRegProtocolo(oid, paciente,  tarea,  individuo,  equipo,  ambiente,  organizacion,  contexto, equipoInv, fecha, historia, protocolo, declaraciones, entrevista, acciones, codAcciones, comunicacion, lecciones);
        }

        public void InsertarAdjunto(int EANMREGIS, string file, string path)
        {
            objetoCD.InsertarAdjunto(EANMREGIS, file, path);
        }
        public DataTable grillaAdjunto(int EANMREGIS)
        {
            DataTable tabla = new DataTable();
            tabla.Rows.Clear();
            tabla = objetoCD.grillaAdjunto(EANMREGIS);
            return tabla;
        }
    }
}
