using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrQuestionnaire.Web.Api.Models;
using UrQustionnaire.Data;

namespace UrQuestionnaire.Web.Api.TypeMappers
{
    public interface IQuestionMapper
    {
        //Question CreateQuestion(OpenEndedQuestion openEndedQuestion);
        //OpenEndedQuestion CreateQuestion(Question question);

        UrQuestionnaire.Web.Api.Models.IQuestion CreateQuestion(UrQustionnaire.Data.IQuestionModelObject question);
        UrQustionnaire.Data.IQuestionModelObject CreateQuestion(UrQuestionnaire.Web.Api.Models.IQuestion question);
    }
}