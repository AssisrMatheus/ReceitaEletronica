using RM_e.Model.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM_e.Client.Receitas
{
    /// <summary>
    /// Toma conta de todas as chamadas à API de RM-e
    /// </summary>
    public class Receitas
    {
        /// <summary>
        /// Chama a api de cadastro de receita
        /// </summary>
        public static ReceitaResult Cadastrar(Receita receita)
        {
            var resultado = RMeAPI.Call<ReceitaResult>("api/Receita/CadastrarReceita", receita);
            return resultado;
        }

        /// <summary>
        /// Chama a api de busca de receita
        /// </summary>
        public static ReceitaMedicaBusca Buscar(string numeroReceita)
        {
            var resultado = RMeAPI.Call<ReceitaMedicaBusca>("api/Receita/ObterReceita", numeroReceita);
            return resultado;
        }

        /// <summary>
        /// Chama a api para utilizar uma receita
        /// </summary>
        public static ReceitaResult Utilizar(string numeroReceita)
        {
            var resultado = RMeAPI.Call<ReceitaResult>("api/Receita/UtilizarReceita", numeroReceita);
            return resultado;
        }

        /// <summary>
        /// Chama a api para cancelar uma receita
        /// </summary>
        public static ReceitaResult Cancelar(string numeroReceita)
        {
            var resultado = RMeAPI.Call<ReceitaResult>("api/Receita/CancelarReceita", numeroReceita);
            return resultado;
        }

    }
}
