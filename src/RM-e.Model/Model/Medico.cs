using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM_e.Model.Model
{
    public class Medico
    {
        public virtual string CRM { get; set; }
        public virtual string Nome { get; set; }
    }

    public class MedicoMap : ClassMapping<Medico>
    {
        public MedicoMap()
        {
            Table("medico");

            Id(x => x.CRM);

            Property(x => x.Nome);
        }
    }
}
