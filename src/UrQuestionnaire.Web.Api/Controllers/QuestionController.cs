using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using NHibernate;
using UrQuestionnaire.Web.Api.Models;
using UrQuestionnaire.Web.Api.TypeMappers;
using UrQuestionnaire.Web.Common;

namespace UrQuestionnaire.Web.Api.Controllers
{
    [LoggingNHibernateSession]
    public class QuestionController : ApiController
    {
        private readonly ISession _session;
        private readonly IQuestionMapper _question;

        public QuestionController(ISession session, IQuestionMapper question)
        {
            _session = session;
            _question = question;
        }

        public IEnumerable<IQuestion> Get()
        {
            var questions = _session
                .QueryOver<UrQustionnaire.Data.OpenEndedQuestion>()
                .List()
                .Select(_question.CreateQuestion)
                .ToList()
                .Concat(_session
                    .QueryOver<UrQustionnaire.Data.CloseEndedQuestion>()
                    .List()
                    .Select(_question.CreateQuestion)
                    .ToList());
            return questions;
        }
    }
}
