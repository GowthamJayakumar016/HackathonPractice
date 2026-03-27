namespace NangaNaluPeru.DTOs
{
   
        public class BookingDto
        {
            public int HotelId { get; set; }

            public int RoomTypeId { get; set; }

            public DateTime CheckIn { get; set; }

            public DateTime CheckOut { get; set; }

            public int Guests { get; set; }
        }
    }

