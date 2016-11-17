using RM_e.Client.Receitas;
using RM_e.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;

namespace RM_e.Soap.Service
{
    /// <summary>
    /// Summary description for RMe
    /// </summary>
    [WebService(Namespace = "http://rmereceitas.com")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class RMe : System.Web.Services.WebService
    {
        [WebMethod]
        [XmlInclude(typeof(List<ItemReceita>))]
        public ReceitaResult Cadastrar(Receita receita)
        {
            return Receitas.Cadastrar(receita);
        }

        [WebMethod]
        [XmlInclude(typeof(List<ItemReceita>))]
        public ReceitaMedicaBusca Buscar(string numeroReceita)
        {
            return Receitas.Buscar(numeroReceita);
        }

        [WebMethod]
        [XmlInclude(typeof(List<ItemReceita>))]
        public ReceitaResult Utilizar(string numeroReceita)
        {
            return Receitas.Utilizar(numeroReceita);
        }

        [WebMethod]
        [XmlInclude(typeof(List<ItemReceita>))]
        public ReceitaResult Cancelar(string numeroReceita)
        {
            return Receitas.Cancelar(numeroReceita);
        }
    }
}
