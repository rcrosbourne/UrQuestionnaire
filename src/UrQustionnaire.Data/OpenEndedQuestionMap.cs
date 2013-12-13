using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrQustionnaire.Data
{
    public class OpenEndedQuestionMap : VersionedClassMap<OpenEndedQuestion>
    {
        public OpenEndedQuestionMap()
        {
            Id(x => x.Id);
            Map(x => x.Text).Not.Nullable();
            Map(x => x.Descriiption).Nullable();
        }
    }
}
