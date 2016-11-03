using RM_e.Model.Context;
using RM_e.Model.Model;
using RM_e.WebService.Service.Medicos;
using RM_e.WebService.Service.Pacientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RM_e.WebService.Receitas.Service
{
    public class ReceitasService
    {
        public ReceitaResult Cadastrar(ReceitaMedica receita)
        {
            var result = this.ValidarReceita(receita);

            if(result.Ok)
            {
                //Só cadastra se não existir 
                if (!DbContext.Medicos.Any(x => x.CRM == receita.Medico.CRM))
                    new MedicosService().Cadastrar(receita.Medico);

                if (!DbContext.Pacientes.Any(x => x.CPF == receita.Paciente.CPF))
                    new PacientesService().Cadastrar(receita.Paciente);

                //Gera a chave inicial
                receita.NumeroReceita = Guid.NewGuid().ToString();

                receita.DataCadastro = DateTime.Now;

                DbContext.Receitas.Add(receita);

                result.NumeroReceita = receita.NumeroReceita;
                result.DataCadastro = receita.DataCadastro;
                result.Mensagem = "Receita salva com sucesso";
                result.CRMMedico = receita.Medico.CRM;
                result.CPFPaciente = receita.Paciente.CPF;
            }            

            return result;
        }

        public ReceitaResult Cancelar(string numeroReceita)
        {
            var result = ValidaNumeroReceita(numeroReceita);

            if (result.Ok)
            {
                DbContext.Receitas.Where(x => x.NumeroReceita == numeroReceita).FirstOrDefault().Cancelada = true;
                result.Ok = DbContext.Receitas.Where(x => x.NumeroReceita == numeroReceita).FirstOrDefault().Cancelada;
                result.Mensagem = "A receita agora está cancelada";
            }

            return result;
        }

        public ReceitaResult Utilizar(string numeroReceita)
        {
            var result = ValidaNumeroReceita(numeroReceita);

            if(result.Ok)
            {
                DbContext.Receitas.Where(x => x.NumeroReceita == numeroReceita).FirstOrDefault().Utilizada = true;
                result.Ok = DbContext.Receitas.Where(x => x.NumeroReceita == numeroReceita).FirstOrDefault().Utilizada;
                result.Mensagem = "A receita agora está utilizada";
            }

            return result;
        }

        public ReceitaMedicaBusca Buscar(string numeroReceita)
        {
            var receitaMedicaBusca = new ReceitaMedicaBusca()
            {
                NumeroReceita = numeroReceita
            };

            var receita = DbContext.Receitas.Where(x => x.NumeroReceita == numeroReceita).FirstOrDefault();
            
            if (receita == null)
            {
                receitaMedicaBusca.Situacao = "Receita não encontrada";
            }
            else
            {
                receitaMedicaBusca = new ReceitaMedicaBusca(receita);
            }

            return receitaMedicaBusca;
        }

        private ReceitaResult ValidaNumeroReceita(string numeroReceita)
        {
            var result = new ReceitaResult()
            {
                Ok = false,
                NumeroReceita = numeroReceita
            };

            var receita = DbContext.Receitas.Where(x => x.NumeroReceita == numeroReceita).FirstOrDefault();

            if (receita == null)
            {
                result.Mensagem = "Não foi encontrado nenhuma receita com o número fornecido";
            }
            else if (receita.Cancelada)
            {
                result.Mensagem = "Esta receita já se encontra cancelada";
            }
            else if (receita.Utilizada)
            {
                result.Mensagem = "Esta receita já foi utilizada";
            }
            else
            {
                result.Ok = true;
            }

            return result;
        }

        private ReceitaResult ValidarReceita(Receita receita)
        {
            var result = new ReceitaResult()
            {
                Ok = true                
            };

#warning Cada validacao de medico/paciente deveria estar no seu proprio service
            if (receita.Medico == null || string.IsNullOrEmpty(receita.Medico.CRM))
            {
                result.Ok = false;
                result.Mensagem = "Médico não pode estar vazio ou sem CRM";
            }

            if (receita.Paciente == null || string.IsNullOrEmpty(receita.Paciente.CPF))
            {
                result.Ok = false;
                result.Mensagem = "Paciente não pode estar vazio ou sem CPF";
            }

            return result;
        }
    }
}