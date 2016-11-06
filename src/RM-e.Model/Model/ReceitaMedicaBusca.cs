using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM_e.Model.Model
{
    public class ReceitaMedicaBusca : Receita
    {
        public string NumeroReceita { get; set; }

        public string Situacao { get; set; }

        public ReceitaMedicaBusca(ReceitaMedica receitaMedica)
        {
            this.Itens = receitaMedica.Itens;
            this.Medico = receitaMedica.Medico;
            this.Paciente = receitaMedica.Paciente;
            this.DataCadastro = receitaMedica.DataCadastro;
            this.NumeroReceita = receitaMedica.NumeroReceita;

            if(receitaMedica.Cancelada)
            {
                this.Situacao = "Receita cancelada";
            }
            else if(receitaMedica.Utilizada)
            {
                this.Situacao = "Receita utilizada";
            }
            else
            {
                this.Situacao = "Receita não utilizada";
            }
        }

        public ReceitaMedicaBusca()
        {
        }
    }
}
