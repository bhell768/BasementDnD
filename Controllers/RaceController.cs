using System.Collections.Generic;
using BasementRPG.Models.Race;
using BasementRPG.Services.Abstract;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace BasementRPG.Controllers
{
    [Route("api/[controller]/[action]")]
    public class RaceController : ControllerBase
    {
        private readonly IRaceService _raceService;
        public RaceController(IRaceService raceService)
        {
            _raceService = raceService;
        }

        [HttpGet]
        public List<Race> GetCore()
        {
            return _raceService.GetCore();
        }
    }
}