using System.Web.Http;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;
using Ninject;
using FluentNHibernate.Cfg;
using Ninject.Activation;
using Ninject.Syntax;
using UrQuestionnaire.Web.Api.TypeMappers;
using UrQustionnaire.Data;

namespace UrQuestionnaire.Web.Api.App_Start
{
    public class NinjectConfigurator
    {
        public void Configure(IKernel container)
        {
            AddBindings(container);
            var resolver = new NinjectDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        private static void AddBindings(IBindingRoot container)
        {
            ConfigureNHibernate(container);
            //Other bindings
            container.Bind<IQuestionMapper>().To<QuestionMapper>();
        }

        private static void ConfigureNHibernate(IBindingRoot container)
        {
            var sessionFactory = Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                    c => c.FromConnectionStringWithKey("UrQuestionnaireDB")).ShowSql())
                .CurrentSessionContext("web")
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<OpenEndedQuestionMap>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();

            container.Bind<ISessionFactory>().ToConstant(sessionFactory);
            container.Bind<ISession>().ToMethod(CreateSession);
           // container.Bind<ICurrentSessionContextAdapter>().To<CurrentSessionContextAdapter>();
            //Seed data
            
        }

       
        private static void BuildSchema(Configuration configuration)
        {
            //configuration.
            new SchemaExport(configuration).Create(false, true); //Cleans database and recreate schema
            //new SchemaUpdate(configuration).Execute(false,true); //Updates the schema with new changes
        }

        private static ISession CreateSession(IContext context)
        {
            var sessionFactory = context.Kernel.Get<ISessionFactory>();
            if (!CurrentSessionContext.HasBind(sessionFactory))
            {
                //Create new sesison
                var session = sessionFactory.OpenSession();
                CurrentSessionContext.Bind(session);
            }
            return sessionFactory.GetCurrentSession();
        }
    }
}
