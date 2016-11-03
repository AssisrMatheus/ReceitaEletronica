using RM_e.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RM_e.Web.Models
{
    public class BuscaViewModel
    {
        public string NumeroReceita { get; set; }

        public ReceitaResult Resultado { get; set; }

        public IEnumerable<ReceitaMedicaBusca> Receitas { get; set; }

        public BuscaViewModel()
        {
            this.Receitas = new List<ReceitaMedicaBusca>();
        }
    }
}