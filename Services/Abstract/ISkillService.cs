using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BasementRPG.Models.Skill;

namespace BasementRPG.Services.Abstract
{
    public interface ISkillService
    {
        List<Skill> Get();
        Skill Get(string id);
    }
}