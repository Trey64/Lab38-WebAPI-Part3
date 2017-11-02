using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Week8Tom.Models
{
    public class HeroStats
    {
        public int Id { get; set; }

        //required for valid model state
        [MinLength(5)]
        public string Alias { get; set; }
        public string Name { get; set; }

    }
}
