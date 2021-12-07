namespace Booking.DAL.Models
{
    public class Grade : BaseModel
    {
        public int ApartementId { get; set; }
        public int VisitorId { get; set; }
        public double Score { get; set; }
    }
}
