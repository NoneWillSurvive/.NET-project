using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain;

namespace DataAccess.Entities
{
    public partial class PhoneNumber
    {
        public PhoneNumber()
        {
            this.Person = new HashSet<Person>();
            this.Operator = new HashSet<Operator>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Number { get; set; }

        public virtual ICollection<Person> Person { get; set; }
        public virtual ICollection<Operator> Operator { get; set; }
    }
}