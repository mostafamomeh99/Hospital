namespace Hospital.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }

        public DateOnly AppointmentDate { get; set; }=new DateOnly();
        public TimeOnly AppointmentTime { get; set; } = new TimeOnly();

    }
}
