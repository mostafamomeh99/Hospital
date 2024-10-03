using Hospital.data;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Hospital.Controllers
{
    public class AppointmentController : Controller
    {
        ApplicationDbContext context=new ApplicationDbContext();
        //Doctor currentdoctor = new Doctor();
        public IActionResult Index(int id)
        {
            var doctor = context.Doctors.ToList().Find(e => e.Id == id);
            TempData["CurrentDoctorName"] = doctor.Name;
            //TempData[doctor.Name]
            //currentdoctor = doctor;
            return View(doctor);
        }
        public IActionResult Book(Appointment appointment)
        {
            //appointment.DoctorName = currentdoctor.Name;
            appointment.DoctorName = (string)TempData["CurrentDoctorName"];
            appointment.AppointmentDate = DateOnly.FromDateTime(DateTime.Parse(appointment.AppointmentDate.ToString()));
    appointment.AppointmentTime = TimeOnly.FromDateTime(DateTime.Parse(appointment.AppointmentTime.ToString()));
            context.Appointments.Add(appointment);
            context.SaveChanges();
            return RedirectToAction("MyAppointments");
        }

        public IActionResult MyAppointments()
        {
            var appointments = context.Appointments.ToList();

            return View(appointments);
        }

    }
}
