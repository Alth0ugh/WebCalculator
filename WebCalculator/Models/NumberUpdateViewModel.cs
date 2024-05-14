using System.Runtime.Serialization;

namespace WebCalculator.Models
{
    [Serializable]
    public class NumberUpdateViewModel
    {
        [DataMember]
        public int Number { get; set; }
        [DataMember]
        public string Display { get; set; } = "0";
        [DataMember]
        public bool Decimal { get; set; }

    }
}
