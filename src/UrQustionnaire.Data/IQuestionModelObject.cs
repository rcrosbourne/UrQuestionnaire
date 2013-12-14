using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrQustionnaire.Data
{
    public interface IQuestionModelObject
    {
        long Id { get; set; }
        string Text { get; set; }
        string Description { get; set; }
        byte[] Version { get; set; }
    }
}
