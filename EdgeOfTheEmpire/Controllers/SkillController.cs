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
    public class SkillController : Controller
    {
        IStaticDataRepository staticDataRepository;
        public SkillController(IStaticDataRepository staticDataRepository)
        {
            this.staticDataRepository = staticDataRepository;
        }
        // GET: /<controller>/
        public IActionResult Index(string skill)
        {
            Skill theSkill = staticDataRepository.GetSkill(skill);
            IList<Career> careers = staticDataRepository.GetCareersWithSkill(theSkill);
            IList<Specialization> specializations = staticDataRepository.GetSpecializationsWithSkill(theSkill);
            var vm = new SkillViewModel() { Skill = theSkill, Careers = careers, Specializations = specializations };
            return View(vm);
        }
        public IActionResult List()
        {
            return View(staticDataRepository.GetSkills());
        }
    }
}
