using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5.Models
{
    public class ToWatchItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsWatched { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }

    }
}
