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
                string[] parametersName = { "UniquId", "PatientName", "MobileNo", "City", "PinCode", "Address", "Pain Condition", "AppointmentDate", "AppointmentTime" };
                object[] Values = { booking.UniquId, booking.PatientName, booking.MobileNumber, booking.City, booking.Pincode, booking.Address, booking.PainCondition, booking.AppointmentDate, booking.AppointmentTime };

                string Sp = "FMR_SavePropertyCategory";
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
