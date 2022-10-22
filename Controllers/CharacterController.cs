using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Service.CharacterService;
using Microsoft.AspNetCore.Mvc;


namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
    public ICharacterService CharacterService { get; }
      public CharacterController(ICharacterService characterService)
      {
      this.CharacterService = characterService;
        
      }

        [HttpGet("Character")]
        
        public ActionResult<List<Character>> Get()
        {
            return Ok(CharacterService.GetAllCharacter());
        }

        [HttpGet("{id}")]
        
        public ActionResult<Character> GetOne(int id)
        {
            return Ok(CharacterService.GetCharacterById(id));
        }

        [HttpPost]
        public ActionResult<List<Character>> AddCharacter(Character newCharacter){
            
            return Ok(CharacterService.AddCharacter(newCharacter));
        }
    }
}