using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Users
    {
        private CD_Users objetoCD = new CD_Users();

        public DataTable AutenticarUsuario(string id, string password)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.AutenticarUsuario(id, password);
            return tabla;
        }
    }
}
