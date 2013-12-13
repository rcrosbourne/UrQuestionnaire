using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace UrQustionnaire.Data
{
    public static class UrQuestionnaireDbConfig
    {
        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        "Data Source=(LocalDB)\\v11.0;AttachDbFilename=\"C:\\Users\\rainaldo crosbourne\\Documents\\GitHub\\UrQuestionnaire\\src\\UrQustionnaire.Data\\SqlServer\\UrQuestionnaireDB.mdf\";Integrated Security=True"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<OpenEndedQuestionMap>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();

        }

        private static void BuildSchema(Configuration configuration)
        {
            new SchemaExport(configuration).Create(false, true);
        }
    }
}
