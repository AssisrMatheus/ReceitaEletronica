using RM_e.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM_e.Model.Context
{
    public class DbContext
    {
        public static List<Medico> Medicos = new List<Medico>();
        public static List<Paciente> Pacientes = new List<Paciente>();
        public static List<ItemReceita> ItensReceita = new List<ItemReceita>();
        public static List<ReceitaMedica> Receitas = new List<ReceitaMedica>();
    }
}
