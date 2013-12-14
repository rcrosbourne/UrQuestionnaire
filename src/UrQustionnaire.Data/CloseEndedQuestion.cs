using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrQustionnaire.Data
{
    public class CloseEndedQuestion : IQuestionModelObject
    {
        public virtual long Id { get; set; }
        public virtual string Text { get; set; }
        public virtual string Description { get; set; }
        public virtual string Choices { get; set; }
        public virtual byte[] Version { get; set; }
    }
}
