using RM_e.Model.Context;
using RM_e.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RM_e.WebService.Service.Medicos
{
    public class MedicosService
    {
        public bool Cadastrar(Medico medico)
        {
            return DbContext.Instance.MedicoRepository.Gravar(medico);
        }

        public Medico Buscar(string CRM)
        {
            return DbContext.Instance.MedicoRepository.GetAll().Where(x => x.CRM == CRM).FirstOrDefault();
        }
    }
}