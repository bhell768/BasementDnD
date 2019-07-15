using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BasementDnD.Models.Character;

namespace BasementDnD.Services.Abstract
{
    public interface ICharacterService
    {
        Task<List<Character>> Get();
        Character Get(string id);
        Character Create(Character character);
        Character Update(string id, Character characterIn);
        bool Remove(Character characterIn);
        bool Remove(string id);
    }
}