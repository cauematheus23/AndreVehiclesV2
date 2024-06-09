using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreVehiclesV2Job.Data
{
    public class AndreVehiclesV2JobContext : DbContext
    {
        public AndreVehiclesV2JobContext (DbContextOptions<AndreVehiclesV2JobContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Job> Job { get; set; } = default!;
    }
}
