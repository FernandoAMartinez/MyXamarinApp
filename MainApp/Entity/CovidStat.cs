using System;
using System.Runtime.Serialization;

namespace Entity
{
    [DataContract]
    public class CovidStat
    {
        public CovidStat() { }

        [DataMember(Name = "city", Order = 0)]
        public string City { get; set; }
        [DataMember(Name = "province", Order = 1)]
        public string Province { get; set; }
        [DataMember(Name = "country", Order = 2)]
        public string Country { get; set; }
        //[DataMember(Name = "lastUpdate", Order = 3)]
        [IgnoreDataMember] //Ignoring by error on date formatting
        public DateTime LastUpdate { get; set ; }
        [DataMember(Name = "keyId", Order = 4)]
        public string KeyId { get; set; }
        [DataMember(Name = "confirmed", Order = 5)]
        public int Confirmed { get; set; }
        [DataMember(Name = "deaths", Order = 6)]
        public int Deaths { get; set; }
        [DataMember(Name = "recovered", Order = 7)]
        public int Recovered { get; set; }
    }
}
