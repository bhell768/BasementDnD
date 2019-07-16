using System.Collections.Generic;
using BasementDnD.Models.Skill;
using BasementDnD.Services.Abstract;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace BasementDnD.Controllers
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