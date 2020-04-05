using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entity
{
    [DataContract]
    public class StatisticsContent
    {
        public StatisticsContent() { }

        [IgnoreDataMember] //Ignoring by error on date formatting
        public DateTime LastChecked { get; set; }
        [DataMember(Name = "covid19Stats", Order = 1)]
        public List<CovidStat> CovidStats { get; set; }
    }
}
