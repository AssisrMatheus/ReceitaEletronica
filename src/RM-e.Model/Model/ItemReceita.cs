using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM_e.Model.Model
{
    public class ItemReceita
    {
        public int Id { get; set; }

        public Medicamento Medicamento { get; set; }

        public string Instrucao { get; set; }
    }

    public class ItemReceitaMap : ClassMapping<ItemReceita>
    {
        public ItemReceitaMap()
        {
            Table("item_receita");

            Id(x => x.Id);

            Property(x => x.Instrucao);

            ManyToOne(x => x.Medicamento, m => m.Column("NumAnvisa"));
        }
    }
}
