using System.Collections.Generic;
using BasementDnD.Models.Race;
using BasementDnD.Services.Abstract;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace BasementDnD.Controllers
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