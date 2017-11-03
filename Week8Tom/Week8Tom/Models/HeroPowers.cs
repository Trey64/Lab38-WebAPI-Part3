using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week8Tom.Models
{
    public class HeroPowers
    {
        public int Id { get; set; }
        public string PowerName { get; set; }
        public List<HeroStats> Powers { get; set; }

    }
}
