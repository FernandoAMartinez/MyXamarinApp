using System.Runtime.Serialization;

namespace Entity
{
    [DataContract]
    public class Statistics
    {
        public Statistics() { }
        [DataMember (Name = "error", Order = 0)]
        public bool Error { get; set; }
        [DataMember (Name = "statusCode", Order = 1)]
        public int StatusCode { get; set; }
        [DataMember (Name = "message", Order = 2)]
        public string Message { get; set; }
        [DataMember(Name = "data", Order = 3)]
        public StatisticsContent Data { get; set; }
    }
}
