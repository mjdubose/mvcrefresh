using System.ComponentModel.DataAnnotations;

namespace Videly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public Membershiptype Membershiptype { get; set; }
        public byte MembershiptTypeId  { get; set; }
    }
}