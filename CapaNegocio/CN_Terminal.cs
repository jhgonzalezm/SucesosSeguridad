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
    public class CN_Terminal
    {
        private CD_Terminal objetoCD = new CD_Terminal();

        public DataTable MostrarReg(string terminal)
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar(terminal);
            return tabla;
        }
    }
}
