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
            characterRepository.AddCharacter(character);
            return View();
        }
    }
}
