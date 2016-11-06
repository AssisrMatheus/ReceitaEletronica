using RM_e.Model.Context;
using RM_e.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RM_e.WebService.Service.ItensReceita
{
    public class ItensReceitaService
    {
        public bool Cadastrar(ItemReceita item)
        {
            var medicamentoOk = DbContext.Instance.MedicamentoRepository.Gravar(item.Medicamento);
            if (!medicamentoOk)
                return false;

            return DbContext.Instance.ItemReceitaRepository.Gravar(item);
        }

        public bool Cadastrar(IEnumerable<ItemReceita> itens)
        {
            var sucesso = true;
            foreach(var item in itens)
            {
                if (!this.Cadastrar(item))
                    sucesso = false;
            }
            return sucesso;
        }
    }
}