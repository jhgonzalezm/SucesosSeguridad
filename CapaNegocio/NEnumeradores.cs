using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NEnumeradores
    {
        public static DataSet Consultar(string sp_sql, int criterio)
        {
            DEnumeradores Obj = new DEnumeradores();
            Obj.Criterio = criterio;
            Obj.Sp_sql = sp_sql;
            return Obj.CargarOpciones(Obj);
        }

    }



}
