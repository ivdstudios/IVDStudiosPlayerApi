using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IVDStudiosPlayerApi.Models; 

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IVDStudiosPlayerApi.Controllers
{
    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        public PlayerController(IPlayerAction players)
        {
            Players = players; 
        }

        public IPlayerAction Players { get; set;}

        /********************** CRUD HTTP Mehtods for our API ************************/


        // GET api/player
        [HttpGet]
        public IEnumerable<Player> Get()
        {
            return Players.GetAll(); 
        }

        // GET api/player/{id}
        [HttpGet("{id}", Name= "GetPlayer")]
        public IActionResult GetById(string id)
        {
            var player = Players.Find(id); 
            if(player == null)
            {
                return NotFound(); 
            }
            return new ObjectResult(player); 
        }

        // POST api/player
        [HttpPost]
        public IActionResult Create([FromBody]Player player)
        {
            if(player == null)
            {
                return BadRequest(); 
            }
            Players.Add(player); 
            return CreatedAtAction("GetPlayer", new {id = player.Key}, player); 

        }

        // PUT api/player/{id}
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody]Player player)
        {
            if(player == null || player.Key != id)
            {
                return BadRequest(); 
            }

            var myPlayer = Players.Find(id); 
            if(myPlayer == null)
            {
                return NotFound(); 
            }
            Players.Update(player); 
            return new NoContentResult(); 
        }

        // DELETE api/player/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var myPlayer = Players.Find(id); 
            if(myPlayer == null)
            {
                return NotFound(); 
            }
            
            Players.Remove(id); 
            return new NoContentResult(); 
        }
    }
}
