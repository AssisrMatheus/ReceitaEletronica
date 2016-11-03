using RM_e.Model.Model;
using RM_e.WebService.Receitas.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RM_e.WebService.Controllers
{
    [RoutePrefix("api/Receita")]
    public class ReceitaController : ApiController
    {
        [Route("CadastrarReceita")]
        public ReceitaResult CadastrarReceita(Receita receita)
        {
            var receitaMedica = new ReceitaMedica(receita);

            var result = new ReceitasService().Cadastrar(receitaMedica);

            return result;
        }

        [Route("CancelarReceita")]
        public ReceitaResult CancelarReceita([FromBody]string numeroReceita)
        {
            var result = new ReceitasService().Cancelar(numeroReceita);

            return result;
        }

        [Route("UtilizarReceita")]
        public ReceitaResult UtilizarReceita([FromBody]string numeroReceita)
        {
            var result = new ReceitasService().Utilizar(numeroReceita);

            return result;
        }

        [Route("ObterReceita")]
        public ReceitaMedicaBusca ObterReceita([FromBody]string numeroReceita)
        {
            var result = new ReceitasService().Buscar(numeroReceita);

            return result;
        }
    }
}