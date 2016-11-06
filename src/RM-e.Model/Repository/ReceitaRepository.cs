using NHibernate;
using RM_e.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM_e.Model.Repository
{
    public class ReceitaRepository
    {
        private ISession session;

        public ReceitaRepository(ISession session)
        {
            this.session = session;
        }

        public IList<ReceitaMedica> GetAll()
        {
            var receitas = this.session.CreateCriteria<ReceitaMedica>().List<ReceitaMedica>();
            return receitas;
        }

        public bool Gravar(ReceitaMedica receita)
        {
            try
            {
                var transacao = this.session.BeginTransaction();

                this.session.SaveOrUpdate(receita);

                transacao.Commit();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Excluir(ReceitaMedica receita)
        {
            try
            {
                var transacao = this.session.BeginTransaction();

                this.session.Delete(receita);

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
