namespace Client.DTO
{
    public class OperatorDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CostForMonth { get; set; }
        public PhoneNumberDTO PhoneNumber { get; set; }
    }
}