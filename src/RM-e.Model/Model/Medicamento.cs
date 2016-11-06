using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM_e.Model.Model
{
    public class Medicamento
    {
        public virtual int NumAnvisa { get; set; }

        public virtual string Nome { get; set; }

        public virtual string Uso { get; set; }

        public virtual string ContraIndicacao { get; set; }
    }

    public class MedicamentoMap : ClassMapping<Medicamento>
    {
        public MedicamentoMap()
        {
            Table("medicamento");

            Id(x => x.NumAnvisa, m => m.Column("NumAnvisa"));

            Property(x => x.Nome);
            Property(x => x.Uso);
            Property(x => x.ContraIndicacao);            
        }
    }
}