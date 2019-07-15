using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BasementDnD.Models.Race;

namespace BasementDnD.Services.Abstract
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