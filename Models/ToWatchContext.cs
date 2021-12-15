using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Lab5.Models
{
    public class ToWatchContext :DbContext
    {
        public ToWatchContext(DbContextOptions<ToWatchContext> options) : base(options)
        {
        }

        public DbSet<ToWatchItem> ToWatchItems { get; set; }
    }
}
