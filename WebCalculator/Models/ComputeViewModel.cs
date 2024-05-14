using System.Runtime.Serialization;

namespace WebCalculator.Models
{
    [Serializable]
    public class ComputeViewModel
    {
        [DataMember]
        public string Display { get; set; }
        [DataMember]
        public bool Whole { get; set; }
    }
}
