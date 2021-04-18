using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public partial class Operator
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public int CostForMonth { get; set; }
        public int? PhoneNumberId { get; set; }

        public virtual PhoneNumber PhoneNumber { get; set; }
    }
}