using Microsoft.EntityFrameworkCore;
using NangaNaluPeru.DTOs;
using NangaNaluPeru.Models;
using NangaNaluPeru.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NangaNaluPeru.Services
{
    public class BookingService : IBookingService
    {
        private readonly AppDbContext _context;

        public BookingService(AppDbContext context)
        {
            _context = context;
        }

        // 🔥 CREATE BOOKING
        public async Task CreateBooking(BookingDto dto, int userId)
        {
            var booking = new Booking
            {
                user_id = userId,
                room_id = dto.RoomTypeId,
                check_in_date = dto.CheckIn,
                check_out_date = dto.CheckOut,
                status = "Pending"
            };

            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        // 🔥 GET USER BOOKINGS
        public async Task<List<Booking>> GetUserBookings(int userId)
        {
            return await _context.Bookings
                .Include(b => b.Room)
                .ThenInclude(r => r.Hotel)
                .Where(b => b.user_id == userId)
                .ToListAsync();
        }
    }
}