using basketball.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace basketball.Controllers
{
    [Route("Matchdatum")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Matchdatum> Post(CreateMatchdataDto createMatchdataDto)
        {
            using (var context = new BasketteamContext())
            {
                var match = new Matchdatum()
                {
                    Id = Guid.NewGuid(),
                    Try = createMatchdataDto.Try,
                    Goal = createMatchdataDto.Goal,
                    Fault = createMatchdataDto.Fault,
                    PlayerId = createMatchdataDto.PlayerId,
                    Belep = DateTime.Now,
                    CreatedTime = DateTime.Now,
                };
                if (match != null)
                {
                    context.Add(match);
                    context.SaveChanges();
                    return StatusCode(201, match);
                }
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult<Matchdatum> Get()
        {
            using (var context = new BasketteamContext())
            {
                return Ok(context.Matchdata.ToList());
            }
        }

        [HttpGet("With_Id")]
        public ActionResult<Matchdatum> GetWithId(Guid id)
        {
            using (var context = new BasketteamContext())
            {
                var match = context.Matchdata.FirstOrDefault(x => x.Id == id);

                if (match != null)
                {
                    return StatusCode(200, match);
                }
                return NotFound();
            }
        }

        [HttpPut]
        public ActionResult<Matchdatum> Put(Guid id, UpdateMatchdataDto updateMatchdataDto)
        {
            using (var context = new BasketteamContext())
            {
                var existingMatch = context.Matchdata.FirstOrDefault(x => x.Id == id);
                if (existingMatch != null)
                {
                    existingMatch.Try=updateMatchdataDto.Try;
                    existingMatch.Goal=updateMatchdataDto.Goal;
                    existingMatch.Fault=updateMatchdataDto.Fault;
                    existingMatch.Lejon=DateTime.Now;
                    existingMatch.UpdatedTime=DateTime.Now;
                    context.SaveChanges();
                    return StatusCode(200, existingMatch);
                }
                return NotFound();
            }
        }

        [HttpDelete]
        public ActionResult<Matchdatum> Delete(Guid id)
        {
            using (var context = new BasketteamContext())
            {
                var delMatch = context.Matchdata.FirstOrDefault(x => x.Id == id);
                if (delMatch != null)
                {
                    context.Matchdata.Remove(delMatch);
                    context.SaveChanges();
                    return StatusCode(200, "Matchdata deleted!");
                }
                return NotFound();
            }
        }
    }
}
