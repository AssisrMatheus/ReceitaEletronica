using NHibernate;
using RM_e.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM_e.Model.Repository
{
    public class MedicamentoRepository
    {
        private ISession session;

        public MedicamentoRepository(ISession session)
        {
            this.session = session;
        }

        public IList<Medicamento> GetAll()
        {
            var medicamentos = this.session.CreateCriteria<Medicamento>().List<Medicamento>();
            return medicamentos;
        }

        public bool Gravar(Medicamento medicamento)
        {
            try
            {
                var transacao = this.session.BeginTransaction();

                this.session.SaveOrUpdate(medicamento);

                transacao.Commit();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Excluir(Medicamento medicamento)
        {
            try
            {
                var transacao = this.session.BeginTransaction();

                this.session.Delete(medicamento);

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
