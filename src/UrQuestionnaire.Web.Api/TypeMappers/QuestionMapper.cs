using System;
using System.Linq;
using UrQuestionnaire.Web.Api.Models;
using UrQustionnaire.Data;


namespace UrQuestionnaire.Web.Api.TypeMappers
{
    public class QuestionMapper : IQuestionMapper
    {
        Models.IQuestion IQuestionMapper.CreateQuestion(UrQustionnaire.Data.IQuestionModelObject question)
        {
            if (question.GetType() == typeof (UrQustionnaire.Data.OpenEndedQuestion))
            {
                return new UrQuestionnaire.Web.Api.Models.OpenEndedQuestion()
                {
                    Id = ((UrQustionnaire.Data.OpenEndedQuestion)question).Id,
                    Text = ((UrQustionnaire.Data.OpenEndedQuestion)question).Text,
                    Description = ((UrQustionnaire.Data.OpenEndedQuestion)question).Description
                };
            }
            if (question.GetType() == typeof(UrQustionnaire.Data.CloseEndedQuestion))
            {
                return new UrQuestionnaire.Web.Api.Models.CloseEndedQuestion()
                {
                    Id = ((UrQustionnaire.Data.CloseEndedQuestion)question).Id,
                    Text = ((UrQustionnaire.Data.CloseEndedQuestion)question).Text,
                    Description = ((UrQustionnaire.Data.CloseEndedQuestion)question).Description,
                    Choices = ((UrQustionnaire.Data.CloseEndedQuestion)question).Choices.Split('|').ToList()
                };
            }

            throw new Exception(string.Format("Unknown question type {0} has no corresponding mapping", question.GetType()));
        }


        IQuestionModelObject IQuestionMapper.CreateQuestion(IQuestion question)
        {
            if (question.GetType() == typeof(UrQuestionnaire.Web.Api.Models.OpenEndedQuestion))
            {
                return new UrQustionnaire.Data.OpenEndedQuestion()
                {
                    Id = ((UrQuestionnaire.Web.Api.Models.OpenEndedQuestion)question).Id,
                    Text = ((UrQuestionnaire.Web.Api.Models.OpenEndedQuestion)question).Text,
                    Description = ((UrQuestionnaire.Web.Api.Models.OpenEndedQuestion)question).Description
                };
            }
            if (question.GetType() == typeof (UrQuestionnaire.Web.Api.Models.CloseEndedQuestion))
            {
                return new UrQustionnaire.Data.CloseEndedQuestion()
                {
                    Id = ((UrQuestionnaire.Web.Api.Models.CloseEndedQuestion) question).Id,
                    Text = ((UrQuestionnaire.Web.Api.Models.CloseEndedQuestion) question).Text,
                    Description = ((UrQuestionnaire.Web.Api.Models.CloseEndedQuestion) question).Description,
                    Choices =
                        string.Join("|",
                            ((UrQuestionnaire.Web.Api.Models.CloseEndedQuestion) question).Choices.ToArray())
                };
            }
            throw new Exception(string.Format("Unknown question type {0} has no corresponding mapping", question.GetType()));
        }
    }
}