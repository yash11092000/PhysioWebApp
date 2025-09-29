using Microsoft.AspNetCore.Mvc;
using PhysioWeb.Models;
using PhysioWeb.Repository;

namespace PhysioWeb.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _BookingService;

        public BookingController(IBookingService bookingService)
        {
            _BookingService = bookingService;
        }
        [HttpGet]
        public async Task<ActionResult> BookSession(int BookingType = 1)



        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SaveSession(Booking booking)
        {
            var result  = await _BookingService.SaveBooking(booking); 
            return Json(result);
        }
    }
}
