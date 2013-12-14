using System;
using UrQuestionnaire.Web.Api.Models;
using UrQustionnaire.Data;


namespace UrQuestionnaire.Web.Api.TypeMappers
{
    public class QuestionMapper : IQuestionMapper
    {
        //public Question CreateQuestion(OpenEndedQuestion openEndedQuestion)
        //{
        //    return new Question
        //    {
        //        Id = openEndedQuestion.Id,
        //        Text = openEndedQuestion.Text,
        //        Description = openEndedQuestion.Descriiption
        //    };
        //}
        //public OpenEndedQuestion CreateQuestion(Question question)
        //{
        //    return new OpenEndedQuestion
        //    {
        //        Text = question.Text,
        //        Descriiption = question.Description
        //    };
        //}

        Models.IQuestion IQuestionMapper.CreateQuestion(UrQustionnaire.Data.IQuestionModelObject question)
        {
            if (question.GetType() == typeof (UrQustionnaire.Data.OpenEndedQuestion))
            {
                return new UrQuestionnaire.Web.Api.Models.OpenEndedQuestion()
                {
                    Text = question.Text,
                    Description =  question.Description
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
                    Text = question.Text,
                    Description = question.Description
                };
            }
            throw new Exception(string.Format("Unknown question type {0} has no corresponding mapping", question.GetType()));
        }
    }
}