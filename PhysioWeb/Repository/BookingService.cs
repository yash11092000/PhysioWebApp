using System.Globalization;
using PhysioWeb.Data;
using PhysioWeb.Models;

namespace PhysioWeb.Repository
{
    public class BookingService : IBookingService
    {
        private readonly DbHelper _dbHelper;
        public BookingService(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<int> SaveBooking(Booking booking)
        {
            try
            {
                var BookingDate = DateTime.ParseExact(booking.AppointmentDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                var BookingTime = DateTime.ParseExact(booking.AppointmentTime, "HH:mm", CultureInfo.InvariantCulture);
                string[] parametersName = { "UniquId", "PatientName", "MobileNo", "City", "PinCode", "Address", "PainCondition", "AppointmentDate", "AppointmentTime","BookingType" };
                object[] Values = { booking.UniquId, booking.PatientName, booking.MobileNumber, booking.City, booking.Pincode, booking.Address, booking.PainCondition, BookingDate, BookingTime, booking.BookingType };

                string Sp = "PHY_BookSession";
                int RecordAffected = await _dbHelper.ExecuteNonQueryAsync(Sp, parametersName, Values);
                return RecordAffected;
            }
            catch (Exception ex)
            {
                // Optional: log error here
                throw;
            }
        }
    }
}
