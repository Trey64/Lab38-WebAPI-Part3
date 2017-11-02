using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week8Tom.Models;

namespace Week8Tom.Data
{
    public class HeroStatsDbContext : DbContext
    {
        public HeroStatsDbContext(DbContextOptions<HeroStatsDbContext> options) : base(options)
        {

        }

        public DbSet<HeroStats> HeroStats { get; set; }
    }
}
