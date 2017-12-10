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
    public class TalentController : Controller
    {
        private readonly IStaticDataRepository staticDataRepository;

        public TalentController(IStaticDataRepository staticDataRepository)
        {
            this.staticDataRepository = staticDataRepository;
        }

        // GET: /<controller>/
        public IActionResult Index(string talentName)
        {
            Talent talent = staticDataRepository.GetTalent(talentName);
            var specializations = staticDataRepository.GetSpecializationsWithTalent(talent);
            var vm = new TalentInfoViewModel() { Talent = talent, Specializations = specializations };
            return View(vm);
        }

        public IActionResult List()
        {
            return View(staticDataRepository.GetTalents());
        }
    }
}
