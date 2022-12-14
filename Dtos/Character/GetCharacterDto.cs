using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Dtos.Character
{
  public class GetCharacterDto
  {


    public int Id { get; set; }

    public string Name { get; set; } = "Toby";
    public int Hitpoints { get; set; } = 100;

    public int Strength { get; set; } = 10;

    public int Defense { get; set; } = 10;

    public int Intelligence { get; set; } = 100;

    public RpgClass Class { get; set; } = RpgClass.Mage;
  }
}