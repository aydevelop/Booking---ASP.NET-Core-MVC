namespace Booking.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int AppartementId { get; set; }
        public int VisitorId { get; set; }
        public double Score { get; set; }
    }
}
