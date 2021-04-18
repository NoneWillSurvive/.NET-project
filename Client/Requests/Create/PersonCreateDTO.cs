using System.ComponentModel.DataAnnotations;

namespace Client.Requests.Create
{
    public class PersonCreateDTO
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }
        
        public int? PhoneNumberId { get; set; }
    }
}