using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorFullstackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SuperHeroController : ControllerBase
    {

        public static List<Comic> comics = new List<Comic> { 
            new Comic { Id = 1, Name = "Marvel" },
            new Comic { Id = 2, Name = "DC" }
        };

        public static List<Superhero> heroes = new List<Superhero> {
            new Superhero {
                Id = 1,
                FirstName = "Peter",
                LastName = "Parker",
                HeroName = "Spiderman",
                Comic = comics[0]
            },
            new Superhero {
                Id = 2,
                FirstName = "Bruce",
                LastName = "Wayne",
                HeroName = "Batman",
                Comic = comics[1]
            },
        };
    [HttpGet]

    public async Task<ActionResult<List<Superhero>>> GetSuperHeroes()
    {
            return Ok(heroes);
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<List<Superhero>>> GetSingleHero(int id)
    {
        var hero = heroes.FirstOrDefault(h => h.Id == id);
        if (hero == null)
        {
            return NotFound(hero);
        }
        return Ok(hero);
    }
    }
}

