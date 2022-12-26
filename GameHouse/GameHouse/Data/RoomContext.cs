using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GameHouse.Data;

    public class RoomContext : DbContext
    {
        public RoomContext (DbContextOptions<RoomContext> options)
            : base(options)
        {
        }

        public DbSet<GameHouse.Data.Room> Room { get; set; } = default!;
    }
