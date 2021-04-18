using System.ComponentModel.DataAnnotations;

namespace Client.Requests.Create
{
    public class OperatorCreateDTO
    {
        [Required(ErrorMessage = "First name is required")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Last name is required")]
        public string CostForMonth { get; set; }
        
        
        public int? PhoneNumerId { get; set; }
    }
}