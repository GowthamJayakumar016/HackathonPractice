using NangaNaluPeru.DTOs;
using NangaNaluPeru.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace NangaNaluPeru.Services.Interfaces
{
    public interface IBookingService
    {
        Task CreateBooking(BookingDto dto, int userId);

        Task<List<Booking>> GetUserBookings(int userId);
    }
}