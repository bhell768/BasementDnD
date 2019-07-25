using System.Collections.Generic;
using BasementRPG.Models.Skill;
using BasementRPG.Services.Abstract;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace BasementRPG.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        public List<Skill> Get()
        {
            return _skillService.Get();
        }
    }
}