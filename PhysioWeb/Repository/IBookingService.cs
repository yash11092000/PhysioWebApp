using PhysioWeb.Models;

namespace PhysioWeb.Repository
{
    public interface IBookingService
    {
        Task<int> SaveBooking(Booking booking);
    }
}
