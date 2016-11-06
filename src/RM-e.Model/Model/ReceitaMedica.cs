using FluentNHibernate.Conventions.Inspections;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM_e.Model.Model
{
    public class ReceitaMedica : Receita
    {
        public virtual string NumeroReceita { get; set; }

        public virtual bool Utilizada { get; set; }

        public virtual bool Cancelada { get; set; }

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
            this.NumeroReceita = Guid.NewGuid().ToString();
        }

        public class ReceitaMedicaMap : ClassMapping<ReceitaMedica>
        {
            public ReceitaMedicaMap()
            {
                Table("receita_medica");

                Id(x => x.NumeroReceita);
                Property(x => x.Utilizada);
                Property(x => x.Cancelada);
                Property(x => x.DataCadastro);

                ManyToOne(x => x.Medico, m => m.Column("NumAnvisa"));
                ManyToOne(x => x.Paciente, m => m.Column("CPF"));

                Bag(x => x.Itens, m => 
                {
                    m.Cascade(NHibernate.Mapping.ByCode.Cascade.All);
                    m.Lazy(CollectionLazy.Lazy);
                    //m.Inverse(true);
                    m.Key(k => k.Column("NumeroReceita"));
                }, r => r.OneToMany());
            }
        }
    }
}
