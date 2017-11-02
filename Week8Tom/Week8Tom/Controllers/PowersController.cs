using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week8Tom.Data;
using Week8Tom.Models;

namespace Week8Tom.Controllers
{
    public class PowersController : ControllerBase
    {
        private readonly HeroStatsDbContext _context;

        //Dependency injection of context
        public PowersController(HeroStatsDbContext context)
        {
            _context = context;
        }

        //Get all lists
        [HttpGet]
        public IEnumerable<HeroPowers> Get()
        {
            return _context.HeroPowers;
        }

        //id constraint
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            //get powers associated with id
            var getPowers = _context.HeroPowers.FirstOrDefault(p => p.Id == id);

            //get items from herostats where PowersId == specified id
            HeroPowers power = new HeroPowers();

            power.Powers = _context.HeroStats.Where(h => h.PowersId == id).ToList();
            power.PowerName = getPowers.PowerName;

            return Ok(power);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HeroPowers list)
        {
            await _context.HeroPowers.AddAsync(list);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = list.Id }, list);
        }

        [HttpPut("{int:id}")]
        public async Task<IActionResult> Put(int id, [FromBody] HeroPowers list)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var check = _context.HeroPowers.FirstOrDefault(p => p.Id == id);

            if (check != null)
            {
                check.PowerName = list.PowerName;
                _context.Update(check);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();

        }
    }
}
