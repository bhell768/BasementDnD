using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BasementRPG.Models.Race;

namespace BasementRPG.Services.Abstract
{
    public interface IRaceService
    {
        List<Race> Get();
        List<Race> GetCore();
        Race Get(string id);
        Race GetCore(string id);
        Race Create(Race race);
        Race Update(string id, Race raceIn);
        bool Remove(Race raceIn);
        bool Remove(string id);
    }
}