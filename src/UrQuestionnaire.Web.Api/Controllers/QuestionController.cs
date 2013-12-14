using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NHibernate;
using NHibernate.Linq;
using UrQuestionnaire.Web.Api.Models;
using UrQuestionnaire.Web.Api.TypeMappers;
using UrQustionnaire.Data;
using IQuestion = UrQuestionnaire.Web.Api.Models.IQuestion;
using OpenEndedQuestion = UrQuestionnaire.Web.Api.Models.OpenEndedQuestion;

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

        public List<IQuestion> Get()
        {
            var openEndedList = _session
                .QueryOver<UrQustionnaire.Data.OpenEndedQuestion>()
                .List()
                .Select(_question.CreateQuestion)
                .ToList();
            return openEndedList;
        }
    }
}
