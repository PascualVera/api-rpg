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
        
        public async Task<ActionResult<ServiceResponse<List<Character>>>> Get()
        {
            return Ok(await CharacterService.GetAllCharacter());
        }

        [HttpGet("{id}")]
        
        public async Task<ActionResult<ServiceResponse<Character>>> GetOne(int id)
        {
            return Ok(await CharacterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> AddCharacter(Character newCharacter){
            
            return Ok(await CharacterService.AddCharacter(newCharacter));
        }
    }
}