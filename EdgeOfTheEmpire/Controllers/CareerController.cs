using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EdgeOfTheEmpire.Models;
using EdgeOfTheEmpire.ViewModels;
using EdgeOfTheEmpire.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EdgeOfTheEmpire.Controllers
{
    public class CareerController : Controller
    {
        private readonly IStaticDataRepository staticDataRepository;
        public CareerController(IStaticDataRepository staticDataRepository)
        {
            this.staticDataRepository = staticDataRepository;
        }
        // GET: /<controller>/
        public IActionResult List()
        {
            ViewBag.Title = "Careers";
            return View(staticDataRepository.GetCarreers());
        }

        public IActionResult Index(string career)
        {
            Career theCareer = staticDataRepository.GetCareer(career);
            IEnumerable<Skill> careerSkills = staticDataRepository.GetCareerSkills(theCareer);
            IEnumerable<Specialization> careerSpecializations = staticDataRepository.GetCareerSpecializations(theCareer);

            CareerInfoViewModel careerInfo = new CareerInfoViewModel()
            {
                Career = theCareer,
                Skills = careerSkills,
                Specializations = careerSpecializations
            };

            return View(careerInfo);
        }
    }
}
