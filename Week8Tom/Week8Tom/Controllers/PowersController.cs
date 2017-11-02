using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week8Tom.Data;

namespace Week8Tom.Controllers
{
    public class PowersController
    {
        private readonly HeroStatsDbContext _context;
        //Dependency injection of context
        public PowersController(HeroStatsDbContext context)
        {
            _context = context;
        }
    }
}
