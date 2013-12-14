using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrQustionnaire.Data
{
    public class CloseEndedQuestionMap : QuestionClassMap<CloseEndedQuestion>
    {
        public CloseEndedQuestionMap()
        {
            Map(x => x.Choices);
        }
    }
}
