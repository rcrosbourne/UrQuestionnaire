using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrQuestionnaire.Web.Api.Models
{
    public interface IQuestion
    {
        long Id { get; set; }
        string Text { get; set; }
        string Description { get; set; }
    }
}