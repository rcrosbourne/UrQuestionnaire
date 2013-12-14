using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrQuestionnaire.Web.Api.Models
{
    public class CloseEndedQuestion : IQuestion
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public List<string> Choices { get; set; } 
    }
}
