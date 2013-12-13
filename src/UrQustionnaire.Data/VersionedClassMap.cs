using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace UrQustionnaire.Data
{
    public abstract class VersionedClassMap<T> : ClassMap<T> where T : IVersionedModelObject
    {
        protected VersionedClassMap()
        {
            Version(x => x.Version).Column("ts")
                .CustomSqlType("Rowversion")
                .Generated.Always()
                .UnsavedValue("null");
        }
        //Data Source=(LocalDB)\v11.0;AttachDbFilename="C:\Users\rainaldo crosbourne\Documents\GitHub\UrQuestionnaire\src\UrQustionnaire.Data\SqlServer\UrQuestionnaireDB.mdf";Integrated Security=True
    }
}
