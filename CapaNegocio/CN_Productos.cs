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
    public class CN_Productos
    {
        private CD_Productos objetoCD = new CD_Productos();

        public DataTable MostrarReg() {

            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public void InsertarReg ( DateTime fecha,string municipio,string id,string reporta, string evento){

            objetoCD.Insertar(fecha,municipio,id,reporta,evento);
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
