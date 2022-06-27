using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        // public string User { get; set; }
        public string Address { get; set; }
        public string ContactPhone { get; set; }
        public int PhoneId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Phone Phone { get; set; }
    }
}
