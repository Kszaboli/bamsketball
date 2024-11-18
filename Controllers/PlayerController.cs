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
    }
}
