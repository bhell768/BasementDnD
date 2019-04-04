using System.Collections.Generic;
using BasementDnD.Models;
using BasementDnD.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace BasementDnD.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CharacterController : ControllerBase
    {
        private readonly CharacterService _characterService;

        public CharacterController(CharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public List<Character> Get()
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
            
            _characterService.Create(characterIn);

            //CreatedAtRoute("GetCharacter", new {id = character.Id.ToString()}, character);

            return NoContent();
        }

        [HttpPost]
        public IActionResult Update([FromBody] Character characterIn)
        {
            var character = _characterService.Get(characterIn.Id);

            if (character == null)
            {
                return NotFound();
            }

            _characterService.Update(characterIn.Id, characterIn);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var character = _characterService.Get(id);

            if (character == null)
            {
                return NotFound();
            }

            _characterService.Remove(character.Id);

            return NoContent();
        }

        public class CharacterResponse
        {
            public string Result {get; set;}
        }
    }
}