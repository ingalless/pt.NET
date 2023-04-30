using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PT.Models;

namespace PT.Data
{
    public class PTContext : DbContext
    {
        public PTContext (DbContextOptions<PTContext> options)
            : base(options)
        {
        }

        public DbSet<PT.Models.Speaker> Speakers { get; set; } = default!;
        public DbSet<PT.Models.Congregation> Congregations { get; set; } = default!;

    }
}
