using System.Runtime.Serialization;

namespace WebCalculator.Models
{
    [Serializable]
    public class CalculatorViewModel
    {
        [DataMember]
        public string Display { get; set; } = "0";
        [DataMember]
        public List<string> History { get; set; }
    }
}
