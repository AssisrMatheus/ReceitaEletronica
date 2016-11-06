using RM_e.Model.Context;
using RM_e.Model.Model;
using RM_e.WebService.Service.ItensReceita;
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

            if (result.Ok)
            {
                result.Ok = new MedicosService().Cadastrar(receita.Medico);
                if(!result.Ok)
                {
                    result.Mensagem = "Não foi possível gravar o Médico";
                    return result;
                }

                result.Ok = new PacientesService().Cadastrar(receita.Paciente);
                if (!result.Ok)
                {
                    result.Mensagem = "Não foi possível gravar o Paciente";
                    return result;
                }

                result.Ok = new ItensReceitaService().Cadastrar(receita.Itens);
                if (!result.Ok)
                {
                    result.Mensagem = "Não foi possível algum dos itens da receita";
                    return result;
                }

                receita.DataCadastro = DateTime.Now;

                result.Ok = DbContext.Instance.ReceitasRepository.Gravar(receita);
                if (!result.Ok)
                {
                    result.Mensagem = "Não foi possível gravar o Médico";
                    return result;                 
                }

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
                //Busca a receita
                var receita = DbContext.Instance.ReceitasRepository.GetAll().Where(x => x.NumeroReceita == numeroReceita).FirstOrDefault();
                receita.Cancelada = true;

                //Grava depois de alterada
                DbContext.Instance.ReceitasRepository.Gravar(receita);

                result.Ok = receita.Cancelada;
                result.Mensagem = "A receita agora está cancelada";
            }

            return result;
        }

        public ReceitaResult Utilizar(string numeroReceita)
        {
            var result = ValidaNumeroReceita(numeroReceita);

            if (result.Ok)
            {
                //Busca a receita
                var receita = DbContext.Instance.ReceitasRepository.GetAll().Where(x => x.NumeroReceita == numeroReceita).FirstOrDefault();
                receita.Utilizada = true;

                //Grava depois de alterada
                DbContext.Instance.ReceitasRepository.Gravar(receita);

                result.Ok = receita.Utilizada;
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

            var receita = DbContext.Instance.ReceitasRepository.GetAll().Where(x => x.NumeroReceita == numeroReceita).FirstOrDefault();

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

            var receita = DbContext.Instance.ReceitasRepository.GetAll().Where(x => x.NumeroReceita == numeroReceita).FirstOrDefault();

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