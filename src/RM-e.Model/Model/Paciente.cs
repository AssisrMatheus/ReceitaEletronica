using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM_e.Model.Model
{
    public class Paciente
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
    }

    public class PacienteMap : ClassMapping<Paciente>
    {
        public PacienteMap()
        {
            Table("paciente");

            Id(x => x.CPF);
            Property(x => x.Nome);
        }
    }
}
