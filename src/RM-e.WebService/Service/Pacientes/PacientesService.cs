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
        public bool Cadastrar(Paciente paciente)
        {
            return DbContext.Instance.PacienteRepository.Gravar(paciente);
        }

        public Paciente Buscar(string CPF)
        {
            return DbContext.Instance.PacienteRepository.GetAll().Where(x => x.CPF == CPF).FirstOrDefault();
        }
    }
}