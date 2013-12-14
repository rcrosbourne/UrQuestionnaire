using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrQuestionnaire.Web.Api.Models;
using UrQustionnaire.Data;

namespace UrQuestionnaire.Web.Api.TypeMappers
{
    public class QuestionMapper : IQuestionMapper
    {
        public Question CreateQuestion(OpenEndedQuestion openEndedQuestion)
        {
            return new Question
            {
                Id = openEndedQuestion.Id,
                Text = openEndedQuestion.Text,
                Description = openEndedQuestion.Descriiption
            };
        }
    }
}