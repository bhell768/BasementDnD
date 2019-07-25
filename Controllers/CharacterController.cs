using System.Collections.Generic;
using BasementRPG.Models.Character;
using BasementRPG.Services.Abstract;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace BasementRPG.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public Task<List<Character>> Get()
        {
            return _characterService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetCharacter")]
        public ActionResult<Character> Get(string id)
        {
            var character = _characterService.Get(id);

            if (character == null)
            {
                return NotFound();
            }

            return character;
        }
        //Movie m = JsonConvert.DeserializeObject<Movie>(json);

        [HttpPost]
        public IActionResult Create([FromBody]Character characterIn)
        {
            
            var character = _characterService.Create(characterIn);

            if(character == null)
            {
                return NotFound();
            }

            return Ok(character);
        }

        [HttpPost]
        public IActionResult Update([FromBody] Character characterIn)
        {
            var character = _characterService.Get(characterIn.Id);

            if (character == null)
            {
                return NotFound();
            }

            var uCharacter = _characterService.Update(characterIn.Id, characterIn);
            if(uCharacter == null)
            {
                return NotFound();
            }

            return Ok(uCharacter);
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var character = _characterService.Get(id);

            if (character == null)
            {
                return NotFound();
            }

            var result = _characterService.Remove(character.Id);
            if(!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        public class CharacterResponse
        {
            public string Result {get; set;}
        }
    }
}