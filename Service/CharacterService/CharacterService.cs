using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpg.Dtos.Character;

namespace dotnet_rpg.Service.CharacterService
{

  public class CharacterService : ICharacterService
  {

    private static List<Character> characters = new List<Character>{


            new Character(),
            new Character{Id = 1, Name = "pinger"}

        };
    private readonly IMapper mapper;

    public CharacterService(IMapper mapper)
    {
      this.mapper = mapper;
    }
    public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
    {
      var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
      Character character = mapper.Map<Character>(newCharacter);
      character.Id = characters.Max(c => c.Id) + 1;
      characters.Add(character);
      serviceResponse.Data = characters.Select(c => mapper.Map<GetCharacterDto>(c)).ToList();
      return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
    {
      ServiceResponse<List<GetCharacterDto>> res = new ServiceResponse<List<GetCharacterDto>>();
      try
      {

        Character character = characters.First(c => c.Id == id);
        characters.Remove(character);
        res.Data = characters.Select(c => mapper.Map<GetCharacterDto>(c)).ToList();

      }
      catch (Exception ex)
      {
        res.Success = false;
        res.Message = ex.Message;
      }


      return res;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter()
    {
      var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
      serviceResponse.Data = characters.Select(c => mapper.Map<GetCharacterDto>(c)).ToList();
      return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
    {
      var serviceResponse = new ServiceResponse<GetCharacterDto>();
      serviceResponse.Data = mapper.Map<GetCharacterDto>(characters.FirstOrDefault(c => c.Id == id));
      return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
    {
      ServiceResponse<GetCharacterDto> res = new ServiceResponse<GetCharacterDto>();
      try
      {

        Character character = characters.FirstOrDefault(c => c.Id == updateCharacter.Id);

        mapper.Map(updateCharacter, character);
        res.Data = mapper.Map<GetCharacterDto>(character);
      }
      catch (Exception ex)
      {
        res.Success = false;
        res.Message = ex.Message;
      }


      return res;
    }
  }
}