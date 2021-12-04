using Booking.DAL.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.DAL.Models
{
    public class Hoster : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public HosterState State { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }


}
