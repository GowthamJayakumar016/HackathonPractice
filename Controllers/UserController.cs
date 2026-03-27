using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NangaNaluPeru.DTOs;
using NangaNaluPeru.Services.Interfaces;
using System.Threading.Tasks;


namespace NangaNaluPeru.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IBookingService _bookingService;

        public UserController(AppDbContext context, IBookingService bookingService)
        {
            _context = context;
            _bookingService = bookingService;
        }

        // 🔥 USER DASHBOARD (Show Hotels)
        public async Task<IActionResult> Dashboard()
        {
            var hotels = await _context.Hotels
                .Include(h => h.Rooms)
                .ToListAsync();

            return View("~/Views/User/Dashboard.cshtml", hotels);
        }

        // 🔥 APPLY PAGE (GET)
        public async Task<IActionResult> Apply(int hotelId)
        {
            var hotel = await _context.Hotels
                .Include(h => h.Rooms)
                .FirstOrDefaultAsync(h => h.HotelId == hotelId);

            return View("~/Views/User/Apply.cshtml", hotel);
        }

        // 🔥 APPLY BOOKING (POST)
        [HttpPost]
        public async Task<IActionResult> Apply(BookingDto dto)
        {
            int userId = 1; // ⚠️ replace with session later

            await _bookingService.CreateBooking(dto, userId);

            return RedirectToAction("MyBookings");
        }

        // 🔥 VIEW MY BOOKINGS
        public async Task<IActionResult> MyBookings()
        {
            int userId = 1; // ⚠️ replace later

            var bookings = await _bookingService.GetUserBookings(userId);

            return View("~/Views/User/MyBookings.cshtml", bookings);
        }
    }
}