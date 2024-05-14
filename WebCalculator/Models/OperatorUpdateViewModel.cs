using System.Runtime.Serialization;

namespace WebCalculator.Models
{
    [Serializable]
    public class OperatorUpdateViewModel
    {
        [DataMember]
        public string Display { get; set; }
        [DataMember]
        public string Operator { get; set; }
        [DataMember]
        public bool Whole { get; set; }
    }
}
