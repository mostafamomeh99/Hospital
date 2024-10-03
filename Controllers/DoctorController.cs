using Hospital.data;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class DoctorController : Controller
    {
        ApplicationDbContext context=new ApplicationDbContext();
        public IActionResult Index()
        {
            var doctors = context.Doctors.ToList();
            
            return View(doctors);
        }
    }
}
