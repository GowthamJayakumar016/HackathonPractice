namespace NangaNaluPeru.Models
{
    public class Booking
    {
        public int booking_id { get; set; }

        public int user_id { get; set; }

        public int room_id { get; set; }

        public DateTime check_in_date { get; set; }

        public DateTime check_out_date { get; set; }

        public string status { get; set; } = "Pending";

        // Navigation properties (VERY IMPORTANT for joins)
        public User User { get; set; }

        public Room Room { get; set; }
    }
}
