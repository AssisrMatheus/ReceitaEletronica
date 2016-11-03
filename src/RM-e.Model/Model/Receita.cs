using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM_e.Model.Model
{
    public class Receita
    {
        public Medico Medico { get; set; }

        public Paciente Paciente { get; set; }

        public IList<ItemReceita> Itens { get; set; }

        public DateTime DataCadastro { get; set; }

        public Receita()
        {
            this.Itens = new List<ItemReceita>();
        }
    }
}
