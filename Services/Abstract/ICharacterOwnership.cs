using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BasementDnD.Models;
using System.Threading.Tasks;

namespace BasementDnD.Services.Abstract
{
    public interface ICharacterOwnership
    {
        Task<List<string>> GetAllCharacters(byte[] userID);
        Task<string> CheckCharacter(byte[] userID, string characterID);
        Task<bool> CreateCharacter(byte[] userID, string characterID);
        Task<bool> DeleteCharacter(byte[] userID, string characterID);
    }
}