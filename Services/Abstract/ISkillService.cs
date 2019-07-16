using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BasementDnD.Models.Skill;

namespace BasementDnD.Services.Abstract
{
    public interface ISkillService
    {
        List<Skill> Get();
        Skill Get(string id);
    }
}