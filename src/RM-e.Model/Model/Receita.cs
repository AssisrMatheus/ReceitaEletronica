using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM_e.Model.Model
{
    public class Receita
    {
        public virtual Medico Medico { get; set; }

        public virtual Paciente Paciente { get; set; }

        public virtual IList<ItemReceita> Itens { get; set; }

        public virtual DateTime DataCadastro { get; set; }

        public Receita()
        {
            this.Itens = new List<ItemReceita>();
        }
    }
}
