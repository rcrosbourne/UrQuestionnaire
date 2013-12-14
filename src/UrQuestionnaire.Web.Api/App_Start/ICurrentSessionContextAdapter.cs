using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace UrQuestionnaire.Web.Api.App_Start
{
    public interface ICurrentSessionContextAdapter
    {
        bool HasBind(ISessionFactory sessionFactory);
        ISession Unbind(ISessionFactory sessionFactory);
    }
}
