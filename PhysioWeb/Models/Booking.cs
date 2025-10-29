namespace PhysioWeb.Models
{
    public class Booking:CommanProp
    {
        public string PatientName { get; set; }

        public string MobileNumber { get; set; }

        public string City { get; set; }

        public string Pincode { get; set; }

        public string Address { get; set; }

        public string PainCondition { get; set; }

        public string AppointmentDate { get; set; }

        public string AppointmentTime { get; set; }

        public int BookingType { get; set; }
    }
}
