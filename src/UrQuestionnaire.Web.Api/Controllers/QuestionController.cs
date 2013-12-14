using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NHibernate;
using UrQuestionnaire.Web.Api.Models;
using UrQuestionnaire.Web.Api.TypeMappers;
using UrQustionnaire.Data;

namespace UrQuestionnaire.Web.Api.Controllers
{
    public class QuestionController : ApiController
    {
        private readonly ISession _session;
        private readonly IQuestionMapper _question;

        public QuestionController(ISession session, IQuestionMapper question)
        {
            _session = session;
            _question = question;
        }

        public IEnumerable<Question> Get()
        {
            return _session
                .QueryOver<OpenEndedQuestion>()
                .List()
                .Select(_question.CreateQuestion)
                .ToList();
        } 
    }
}
