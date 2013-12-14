using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace UrQustionnaire.Data
{
    public abstract class QuestionClassMap<T> : ClassMap<T> where T : IQuestionModelObject //abstract class VersionedClassMap<T> : ClassMap<T> where T : IVersionedModelObject
    {
        protected QuestionClassMap()
        {
            Id(x => x.Id);
            Map(x => x.Text).Not.Nullable();
            Map(x => x.Description).Nullable();

            Version(x => x.Version).Column("ts")
                .CustomSqlType("Rowversion")
                .Generated.Always()
                .UnsavedValue("null");
        }
        
    }
}
