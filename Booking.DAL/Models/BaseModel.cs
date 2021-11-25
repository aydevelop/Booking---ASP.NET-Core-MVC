using System.ComponentModel.DataAnnotations;

namespace Booking.DAL.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
