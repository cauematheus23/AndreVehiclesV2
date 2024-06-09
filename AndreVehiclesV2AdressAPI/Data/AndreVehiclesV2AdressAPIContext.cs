using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreVehiclesV2AdressAPI.Data
{
    public class AndreVehiclesV2AdressAPIContext : DbContext
    {
        public AndreVehiclesV2AdressAPIContext (DbContextOptions<AndreVehiclesV2AdressAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Adress> Adress { get; set; } = default!;
    }
}
