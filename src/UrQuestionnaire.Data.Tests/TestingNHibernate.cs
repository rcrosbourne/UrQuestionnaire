using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using UrQustionnaire.Data;

namespace UrQuestionnaire.Data.Tests
{
    [TestClass]
    public class TestingNHibernate
    {
        private readonly OpenEndedQuestion openQuestion = new OpenEndedQuestion()
        {
            Description = "This is a test", 
            Text = "Are you male or female"
        };
        [TestMethod]
        public void Testing_Inital_Creation_Of_Data()
        {
            var sessionFactory = UrQuestionnaireDbConfig.CreateSessionFactory();
            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(openQuestion);
                    transaction.Commit();
                }
            }
        }
    }
}
