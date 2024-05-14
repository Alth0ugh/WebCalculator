using System.ComponentModel.DataAnnotations;

namespace WebCalculator.Models
{
    public class ExpressionModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Expression { get; set; }
        [Required]
        public float Result { get; set; }
    }
}
