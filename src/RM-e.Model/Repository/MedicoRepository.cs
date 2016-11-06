using NHibernate;
using RM_e.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM_e.Model.Repository
{
    public class MedicoRepository
    {
        private ISession session;

        public MedicoRepository(ISession session)
        {
            this.session = session;
        }

        public IList<Medico> GetAll()
        {
            var medicos = this.session.CreateCriteria<Medico>().List<Medico>();
            return medicos;
        }

        public bool Gravar(Medico medico)
        {
            try
            {
                var transacao = this.session.BeginTransaction();

                this.session.SaveOrUpdate(medico);

                transacao.Commit();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Excluir(Medico medico)
        {
            try
            {
                var transacao = this.session.BeginTransaction();

                this.session.Delete(medico);

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
