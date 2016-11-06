using NHibernate;
using RM_e.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM_e.Model.Repository
{
    public class PacienteRepository
    {
        private ISession session;

        public PacienteRepository(ISession session)
        {
            this.session = session;
        }

        public IList<Paciente> GetAll()
        {
            var paciente = this.session.CreateCriteria<Paciente>().List<Paciente>();
            return paciente;
        }

        public bool Gravar(Paciente paciente)
        {
            try
            {
                var transacao = this.session.BeginTransaction();

                this.session.SaveOrUpdate(paciente);

                transacao.Commit();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Excluir(Paciente paciente)
        {
            try
            {
                var transacao = this.session.BeginTransaction();

                this.session.Delete(paciente);

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
