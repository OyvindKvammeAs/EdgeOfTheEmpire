using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EdgeOfTheEmpire.Models;
using EdgeOfTheEmpire.ViewModels;
using EdgeOfTheEmpire.Entities;
using EdgeOfTheEmpire.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EdgeOfTheEmpire.Controllers
{
    public class CharacterController : Controller
    {
        private ICharacterRepository characterRepository;
        public CharacterController(ICharacterRepository characterRepository)
        {
            this.characterRepository= characterRepository;
        }
        // GET: /<controller>/
        public IActionResult Index(string characterName)
        {
            Character character = characterRepository.GetCharacter(characterName);                       
            CharacterViewModel a = new CharacterViewModel() { Character = character };
            return View(a);
        }

        public IActionResult List()
        {
            return View(characterRepository.Characters);
        }

        public IActionResult AddCharacter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCharacter(InitialCharacter character)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            characterRepository.AddCharacter(character);
            return View();
        }

        public IActionResult AddBattleScarAdvance()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBattleScarAdvance(CharacterBattleScarAdvance battleScarAdvance)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            characterRepository.AddBattleScarAdvance(battleScarAdvance);
            return View();
        }

        public IActionResult AddSkillAdvance()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSkillAdvance(CharacterSkillAdvance skillAdvance)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            characterRepository.AddSkillAdvance(skillAdvance);
            return View();
        }

        public IActionResult AddSpecializationAdvance()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSpecializationAdvance(CharacterSpecializationAdvance specializationAdvance)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            characterRepository.AddSpecializationAdvance(specializationAdvance);
            return View();
        }

        public IActionResult AddSignatureAbility()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSignatureAbility(CharacterSignatureAbility signatureAbility)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            characterRepository.AddSignatureAbility(signatureAbility);
            return View();
        }


        public IActionResult AddSignatureAbilityAdvance()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSignatureAbilityAdvance(CharacterSignatureAbilityAdvance signatureAbilityAdvance)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            characterRepository.AddSignatureAbilityAdvance(signatureAbilityAdvance);
            return View();
        }



        public IActionResult AddSpecialization()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSpecialization(Entities.CharacterSpecialization specialization)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            characterRepository.AddSpecialization(specialization);
            return View();
        }
    }
}
