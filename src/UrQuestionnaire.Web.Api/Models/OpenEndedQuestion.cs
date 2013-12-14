using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrQuestionnaire.Web.Api.Models
{
    public class OpenEndedQuestion : IQuestion
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }
}