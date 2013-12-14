using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace UrQuestionnaire.Web.Common
{
    public interface ICurrentSessionContextAdapter
    {
        bool HasBind(ISessionFactory sessionFactory);
        ISession Unbind(ISessionFactory sessionFactory);
    }
}
