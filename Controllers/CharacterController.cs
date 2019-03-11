using System.Collections.Generic;
using BasementDnD.Models;
using BasementDnD.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasementDnD.Controllers
{
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly CharacterService _characterService;

        public CharacterController(CharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public ActionResult<List<Character>> Get()
        {
            List<Character> result = _characterService.Get();
            return result;
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

        [HttpPost]
        public ActionResult<Character> Create(Character character)
        {
            _characterService.Create(character);

            return CreatedAtRoute("GetCharacter", new {id = character.Id.ToString()}, character);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Character characterIn)
        {
            var character = _characterService.Get(id);

            if (character == null)
            {
                return NotFound();
            }

            _characterService.Update(id, characterIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
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
    }
}