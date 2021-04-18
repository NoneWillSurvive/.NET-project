namespace Client.DTO
{
    public class PersonDTO
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }
        
        public PhoneNumberDTO PhoneNumber { get; set; }
        
    }
}