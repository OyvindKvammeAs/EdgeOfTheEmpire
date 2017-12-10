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
    public class SpecializationController : Controller
    {
        private readonly IStaticDataRepository staticDataRepository;

        public SpecializationController(IStaticDataRepository staticDataRepository)
        {
            this.staticDataRepository = staticDataRepository;
        }

        // GET: /<controller>/
        public IActionResult Index(string specializationName)
        {
            Specialization specialization = staticDataRepository.GetSpecialization(specializationName);
            Career career = specialization.Career;
            IEnumerable<Skill> skills = staticDataRepository.GetSpecializationSkills(specialization);           
            TalentTree talentTree = staticDataRepository.GetSpecializationTalentTree(specialization);
            SpecializationInfoViewModel vm = new SpecializationInfoViewModel()
            {
                Career = career,
                Skills = skills,
                Specialization = specialization,
                TalentTree = talentTree
            };
            return View(vm);
        }

        public IActionResult List()
        {
            return View(staticDataRepository.GetSpecializations());
        }
    }
}
