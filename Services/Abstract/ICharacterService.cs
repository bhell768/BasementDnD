using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BasementDnD.Models;

namespace BasementDnD.Services.Abstract
{
    public interface ICharacterService
    {
        List<Character> Get();
        Character Get(string id);
        Character Create(Character character);
        void Update(string id, Character characterIn);
        void Remove(Character characterIn);
        void Remove(string id);
    }
}