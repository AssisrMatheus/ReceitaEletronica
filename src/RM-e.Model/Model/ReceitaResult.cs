using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM_e.Model.Model
{
    public class ReceitaResult
    {
        public bool Ok { get; set; }

        public string Mensagem { get; set; }

        public string CPFPaciente { get; set; }

        public string CRMMedico { get; set; }

        public DateTime DataCadastro { get; set; }

        public string NumeroReceita { get; set; }
    }
}
