using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM_e.Model.Model
{
    public class ReceitaMedica : Receita
    {
        public string NumeroReceita { get; set; }

        public bool Utilizada { get; set; }

        public bool Cancelada { get; set; }

        public ReceitaMedica()
        {
            this.Utilizada = false;
            this.Cancelada = false;
        }

        public ReceitaMedica(Receita receita)
        {
            Itens = receita.Itens;
            Medico = receita.Medico;
            Paciente = receita.Paciente;

            this.Utilizada = false;
            this.Cancelada = false;
        }
    }
}
