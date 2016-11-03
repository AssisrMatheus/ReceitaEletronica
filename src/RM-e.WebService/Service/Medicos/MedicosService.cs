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
        public void Cadastrar(Medico medico)
        {
            DbContext.Medicos.Add(medico);
        }

        public Medico Buscar(string CRM)
        {
            return DbContext.Medicos.Where(x => x.CRM == CRM).FirstOrDefault();
        }
    }
}