using basketball.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace basketball.Controllers
{
    [Route("Player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Player> Post(CreatePlayerDto createPlayerDto)
        {
            using (var context = new BasketteamContext())
            {
                var player = new Player()
                {
                    Id = Guid.NewGuid(),
                    Name = createPlayerDto.Name,
                    Height = createPlayerDto.Height,
                    Weight = createPlayerDto.Weight,

                };
                if (createPlayerDto.Name != null)
                {
                    context.Add(player);
                    context.SaveChanges();
                    return StatusCode(201, player);
                }
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult<Player> Get()
        {
            using ( var context = new BasketteamContext())
            {
                return Ok(context.Players.ToList());
            }
        }

        [HttpGet("With_Id")]
        public ActionResult<Player> GetWithId(Guid id)
        {
            using (var context = new BasketteamContext())
            {
                var player = context.Players.FirstOrDefault(x => x.Id == id);

                if (player != null)
                {
                    return StatusCode(200, player);
                }
                return NotFound();
            }
        }

        [HttpPut]
        public ActionResult<Player> Put(Guid id,UpdatePlayerDto updatePlayerDto)
        {
            using (var context = new BasketteamContext())
            {
                var existingPlayer = context.Players.FirstOrDefault(x => x.Id == id);
                if (existingPlayer != null)
                {
                    existingPlayer.Name = updatePlayerDto.Name;
                    existingPlayer.Height = updatePlayerDto.Height;
                    existingPlayer.Weight = updatePlayerDto.Weight;
                    context.SaveChanges();
                    return StatusCode(200, existingPlayer);
                }
                return NotFound();
            }
        }

        [HttpDelete]
        public ActionResult<Player> Delete(Guid id) 
        {
            using ( var context = new BasketteamContext())
            {
                var delPlayer = context.Players.FirstOrDefault(x => x.Id ==  id);
                if (delPlayer !=null)
                {
                    context.Players.Remove(delPlayer);
                    context.SaveChanges();
                    return StatusCode(200, "Player deleted!");
                }
                return NotFound();
            }
        }
    }
}
