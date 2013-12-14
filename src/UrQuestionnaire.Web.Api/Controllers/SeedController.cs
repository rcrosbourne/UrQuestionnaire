﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NHibernate;
using UrQuestionnaire.Web.Api.Models;
using UrQuestionnaire.Web.Api.TypeMappers;

namespace UrQuestionnaire.Web.Api.Controllers
{
    public class SeedController : ApiController
    {
        private readonly ISession _session;
        private readonly IQuestionMapper _question;

        public SeedController(ISession session, IQuestionMapper questionMapper)
        {
            _session = session;
            _question = questionMapper;
        }

        public HttpResponseMessage Post(HttpRequestMessage request)
        {
            var questions = new List<IQuestion>
            {
                new OpenEndedQuestion()
                {
                    Description = "This is the first Seeded Question",
                    Text = "How do u like NHibernate as a ORM"
                },
                new OpenEndedQuestion()
                {
                    Description = "This is the second seeded question",
                    Text = "How does it compare to Entity Framework"
                }
            };
            foreach (var question in questions)
            {
                _session.Save(_question.CreateQuestion(question));
            }
            var response = request.CreateResponse(HttpStatusCode.Created, questions);
            return response;
        }
    }
}