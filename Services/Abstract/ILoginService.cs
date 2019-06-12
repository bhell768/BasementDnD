using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BasementDnD.Models;
using System.Threading.Tasks;


namespace BasementDnD.Services.Abstract
{
    public interface ILoginService
    {
        Task<IEnumerable<Login>> Get();
        Task<Login> Get(int id);
        Task<int> Create(Login login);
        Task<bool> Update(int id, Login loginIn);
        Task<bool> Remove(Login loginIn);
        Task<bool> Remove(int id); 
    }
}