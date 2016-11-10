using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Context;
using NHibernate.Mapping.ByCode;
using RM_e.Model.Model;
using RM_e.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RM_e.Model.Context
{
    public class DbContext
    {
        public static string StringConexao =
           "server=rmematheusadow.mysql.dbaas.com.br;SslMode=Preferred;" +
           "database=rmematheusadow;uid=rmematheusadow;pwd=dANADO$$2016";

        private ISessionFactory SessionFactory;


        private static DbContext _instance = null;
        public static DbContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DbContext();
                }

                return _instance;
            }
        }

        public ReceitaRepository ReceitasRepository { get; set; }
        public MedicoRepository MedicoRepository { get; set; }
        public PacienteRepository PacienteRepository { get; set; }
        public ItemReceitaRepository ItemReceitaRepository { get; set; }
        public MedicamentoRepository MedicamentoRepository { get; set; }

        public DbContext()
        {
            if (Conexao())
            {
                this.ReceitasRepository = new ReceitaRepository(this.Session);
                this.MedicoRepository = new MedicoRepository(this.Session);
                this.PacienteRepository = new PacienteRepository(this.Session);
                this.ItemReceitaRepository = new ItemReceitaRepository(this.Session);
                this.MedicamentoRepository = new MedicamentoRepository(this.Session);
            }
        }

        private bool Conexao()
        {
            //Cria a configuração com o NH
            var config = new Configuration();
            try
            {
                //Integração com o Banco de Dados
                config.DataBaseIntegration(c =>
                {
                    //Dialeto de Banco
                    c.Dialect<NHibernate.Dialect.MySQLDialect>();
                    //Conexao string
                    c.ConnectionString = StringConexao;
                    //Drive de conexão com o banco
                    c.Driver<NHibernate.Driver.MySqlDataDriver>();
                    // Provedor de conexão do MySQL 
                    c.ConnectionProvider<NHibernate.Connection.DriverConnectionProvider>();
                    // GERA LOG DOS SQL EXECUTADOS NO CONSOLE
                    c.LogSqlInConsole = true;
                    // DESCOMENTAR CASO QUEIRA VISUALIZAR O LOG DE SQL FORMATADO NO CONSOLE
                    c.LogFormattedSql = true;
                    // CRIA O SCHEMA DO BANCO DE DADOS SEMPRE QUE A CONFIGURATION FOR UTILIZADA
                    c.SchemaAction = SchemaAutoAction.Update;
                });

                //Realiza o mapeamento das classes
                var maps = this.Mapeamento();
                config.AddMapping(maps);

                //Verifico se a aplicação é Desktop ou Web
                if (System.Web.HttpContext.Current == null)
                {
                    config.CurrentSessionContext<ThreadStaticSessionContext>();
                }
                else
                {
                    config.CurrentSessionContext<WebSessionContext>();
                }

                this.SessionFactory = config.BuildSessionFactory();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        private HbmMapping Mapeamento()
        {
            var mapper = new ModelMapper();

            mapper.AddMappings(
                Assembly.GetAssembly(typeof(ItemReceita)).GetTypes()
            );

            mapper.AddMappings(
                Assembly.GetAssembly(typeof(Medicamento)).GetTypes()
            );

            mapper.AddMappings(
                Assembly.GetAssembly(typeof(Medico)).GetTypes()
            );

            mapper.AddMappings(
                Assembly.GetAssembly(typeof(Paciente)).GetTypes()
            );

            mapper.AddMappings(
                Assembly.GetAssembly(typeof(ReceitaMedica)).GetTypes()
            );

            return mapper.CompileMappingForAllExplicitlyAddedEntities();
        }

        private ISession Session
        {
            get
            {
                if (CurrentSessionContext.HasBind(SessionFactory))
                    return SessionFactory.GetCurrentSession();

                var session = SessionFactory.OpenSession();
                CurrentSessionContext.Bind(session);

                return session;
            }
        }

        //public static List<Medico> Medicos = new List<Medico>();
        //public static List<Paciente> Pacientes = new List<Paciente>();
        //public static List<ItemReceita> ItensReceita = new List<ItemReceita>();
        //public static List<ReceitaMedica> Receitas = new List<ReceitaMedica>();
    }
}
