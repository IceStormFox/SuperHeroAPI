using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Services.SuperHeroService;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;
        public SuperHeroController(ISuperHeroService superHeroService) 
        {
            _superHeroService = superHeroService;
        }
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            return await _superHeroService.GetAllHeroes();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleHero(int id)
        {
            var result = await _superHeroService.GetSingleHero(id);
            if (result is null) { return NotFound("Hero not found"); }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddHero([FromBody]SuperHero hero)
        {
            var result = await _superHeroService.AddHero(hero);
            if (result is null) { return NotFound("Hero not found"); }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateHero(int id, SuperHero request)
        {
            var result = await _superHeroService.UpdateHero(id, request);
            if (result is null) { return NotFound("Hero not found"); }
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var result = await _superHeroService.DeleteHero(id);
            if (result is null) { return NotFound("Hero not found"); }
            return Ok(result);
        }
    }
}
