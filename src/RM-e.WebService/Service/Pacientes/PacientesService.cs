using RM_e.Model.Context;
using RM_e.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RM_e.WebService.Service.Pacientes
{
    public class PacientesService
    {
        public void Cadastrar(Paciente paciente)
        {
            DbContext.Pacientes.Add(paciente);
        }

        public Paciente Buscar(string CPF)
        {
            return DbContext.Pacientes.Where(x => x.CPF == CPF).FirstOrDefault();
        }
    }
}