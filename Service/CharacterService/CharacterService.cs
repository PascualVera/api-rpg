using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpg.Data;
using dotnet_rpg.Dtos.Character;
using Microsoft.EntityFrameworkCore;

namespace dotnet_rpg.Service.CharacterService
{

  public class CharacterService : ICharacterService
  {

    private readonly IMapper mapper;
    private readonly DataContext context;

    public CharacterService(IMapper mapper, DataContext context)
    {
      this.context = context;
      this.mapper = mapper;
    }



    //////////////Get all method
    public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter()
    {
      var res = new ServiceResponse<List<GetCharacterDto>>();
      var dbCharacters = await context.Characters.ToListAsync();
      res.Data = dbCharacters.Select(c => mapper.Map<GetCharacterDto>(c)).ToList();
      return res;
    }

    /////////////Get by Id method
    public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
    {
      var serviceResponse = new ServiceResponse<GetCharacterDto>();
      var dbCharacters = await context.Characters.ToListAsync();
      serviceResponse.Data = mapper.Map<GetCharacterDto>(dbCharacters.FirstOrDefault(c => c.Id == id));
      return serviceResponse;
    }

    ////////// Post Method
    public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
    {
      var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
      var dbCharacters = context.Characters;
      Character character = mapper.Map<Character>(newCharacter);
      dbCharacters.Add(character);
      await context.SaveChangesAsync();
      serviceResponse.Data = await dbCharacters.Select(c =>
      mapper.Map<GetCharacterDto>(c))
      .ToListAsync();
      return serviceResponse;
    }
    ////////////Update Method
    public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
    {
      ServiceResponse<GetCharacterDto> res = new ServiceResponse<GetCharacterDto>();
      try
      {
        var dbCharacters = context.Characters;

        var character = await dbCharacters
        .FirstOrDefaultAsync(c => c.Id == updateCharacter.Id);

        mapper.Map(updateCharacter, character);

        await context.SaveChangesAsync();

        res.Data = mapper.Map<GetCharacterDto>(character);
      }
      catch (Exception ex)
      {
        res.Success = false;
        res.Message = ex.Message;
      }


      return res;
    }


    ////////////// Delete method
    public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
    {
      ServiceResponse<List<GetCharacterDto>> res = new ServiceResponse<List<GetCharacterDto>>();
      try
      {
        var dbCharacters = context.Characters;
        Character character = await dbCharacters.FirstAsync(c => c.Id == id);
        dbCharacters.Remove(character);
        await context.SaveChangesAsync();
        res.Data = dbCharacters.Select(c => mapper.Map<GetCharacterDto>(c)).ToList();

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