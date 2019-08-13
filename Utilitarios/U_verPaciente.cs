using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class U_verPaciente
    {
        private DataTable pacientes;

        public DataTable Pacientes { get => pacientes; set => pacientes = value; }
    }
}
