using RM_e.Client.Receitas;
using RM_e.Model.Model;
using RM_e.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RM_e.Web.Controllers
{
    public class ReceitaController : Controller
    {
        /// <summary>
        /// Página de cadastro de receita
        /// </summary>
        public ActionResult Cadastrar()
        {
            var receita = new Receita();

            receita.Itens.Add(new ItemReceita());
            return View(receita);
        }

        /// <summary>
        /// Ação de cadastrar uma receita, chamada a partir do form da página Cadastrar
        /// </summary>
        /// <param name="receita">Model Receita</param>
        [HttpPost]
        public ActionResult Cadastrar(Receita receita)
        {
            var resultado = Receitas.Cadastrar(receita);

            if(resultado.Ok)
                return RedirectToAction("Sucesso", resultado);

            //Se deu erro adiciono a mensagem de erro e retorno à tela
            ModelState.AddModelError("receita", resultado.Mensagem);

            return View(receita);
        }

        /// <summary>
        /// Retorna um partial para cada item da receita, usado para criar múltiplos itens numa lista
        /// Chamado a partir da página Cadastrar em javascript/ajax
        /// </summary>
        [HttpPost]
        public ActionResult ItemReceita(Receita receita)
        {
            if (Request.IsAjaxRequest())
            {
                receita.Itens.Add(new ItemReceita());

                return PartialView("_CadastrarItemReceita", receita);
            }
            return RedirectToAction("Cadastrar");
        }

        /// <summary>
        /// Página de receita cadastrada com sucesso, chamada a partir de Cadastrar via post
        /// </summary>
        public ActionResult Sucesso(ReceitaResult resultado)
        {
            return View(resultado);
        }

        /// <summary>
        /// Página de busca de receitas
        /// </summary>
        public ActionResult Buscar()
        {
            return View(new BuscaViewModel());
        }

        /// <summary>
        /// Resultado da busca de receitas
        /// </summary>
        [HttpPost]
        public ActionResult Buscar(BuscaViewModel viewModel)
        {
            //Busco a receita na API
            var receita = Receitas.Buscar(viewModel.NumeroReceita);

            if (!receita.Itens.Any())
                ModelState.AddModelError("receita", receita.Situacao);
            else
            {
                //Adiciono a receita à lista
                var receitas = viewModel.Receitas.ToList();
                receitas.Add(receita);
                viewModel.Receitas = receitas;
            }            

            //Retorno à tela
            return View(viewModel);
        }

        /// <summary>
        /// Resultado da busca de receitas
        /// </summary>
        public ActionResult Utilizar(string numeroReceita)
        {
            var resultado = Receitas.Utilizar(numeroReceita);
            var receita = Receitas.Buscar(numeroReceita);

            var viewModel = new BuscaViewModel()
            {
                NumeroReceita = numeroReceita,
                Resultado = resultado
            };

            if (!receita.Itens.Any())
                ModelState.AddModelError("receita", receita.Situacao);
            else
            {
                //Adiciono a receita à lista
                var receitas = viewModel.Receitas.ToList();
                receitas.Add(receita);
                viewModel.Receitas = receitas;
            }

            return View("Buscar", viewModel);
        }

        /// <summary>
        /// Resultado da busca de receitas
        /// </summary>        
        public ActionResult Cancelar(string numeroReceita)
        {
            var resultado = Receitas.Cancelar(numeroReceita);
            var receita = Receitas.Buscar(numeroReceita);

            var viewModel = new BuscaViewModel()
            {
                NumeroReceita = numeroReceita,
                Resultado = resultado
            };

            if (!receita.Itens.Any())
                ModelState.AddModelError("receita", receita.Situacao);
            else
            {
                //Adiciono a receita à lista
                var receitas = viewModel.Receitas.ToList();
                receitas.Add(receita);
                viewModel.Receitas = receitas;
            }

            return View("Buscar", viewModel);
        }
    }
}