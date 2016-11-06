using NHibernate;
using RM_e.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM_e.Model.Repository
{
    public class ItemReceitaRepository
    {
        private ISession session;

        public ItemReceitaRepository(ISession session)
        {
            this.session = session;
        }

        public IList<ItemReceita> GetAll()
        {
            var itens = this.session.CreateCriteria<ItemReceita>().List<ItemReceita>();
            return itens;
        }

        public bool Gravar(ItemReceita item)
        {
            try
            {
                var transacao = this.session.BeginTransaction();

                this.session.SaveOrUpdate(item);

                transacao.Commit();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Excluir(ItemReceita item)
        {
            try
            {
                var transacao = this.session.BeginTransaction();

                this.session.Delete(item);

                transacao.Commit();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
