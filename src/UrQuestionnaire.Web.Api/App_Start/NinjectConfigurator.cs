using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using FluentNHibernate.Cfg.Db;
using Microsoft.Ajax.Utilities;
using NHibernate;
using NHibernate.Context;
using Ninject;
using FluentNHibernate.Cfg;
using Ninject.Activation;
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

        private void AddBindings(IKernel container)
        {
            ConfigureNHibernate(container);
            //Other bindings
            container.Bind<IQuestionMapper>().To<QuestionMapper>();
        }

        private void ConfigureNHibernate(IKernel container)
        {
            var sessionFactory = Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        "Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\Users\\Smurf\\Documents\\GitHub\\UrQuestionnaire\\src\\UrQustionnaire.Data\\SqlServer\\UrQuestionnaireDB.mdf;Integrated Security=True"))
                       // "Data Source=(LocalDB)\\v11.0;AttachDbFilename=\"C:\\Users\\rainaldo crosbourne\\Documents\\GitHub\\UrQuestionnaire\\src\\UrQustionnaire.Data\\SqlServer\\UrQuestionnaireDB.mdf\";Integrated Security=True"))
                .CurrentSessionContext("web")
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<OpenEndedQuestionMap>())
                .BuildSessionFactory();

            container.Bind<ISessionFactory>().ToConstant(sessionFactory);
            container.Bind<ISession>().ToMethod(CreateSession);
           // container.Bind<ICurrentSessionContextAdapter>().To<CurrentSessionContextAdapter>();
        }

        private ISession CreateSession(IContext context)
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
