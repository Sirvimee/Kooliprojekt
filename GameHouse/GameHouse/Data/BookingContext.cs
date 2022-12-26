using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GameHouse.Data;

    public class BookingContext : DbContext
    {
        public BookingContext (DbContextOptions<BookingContext> options)
            : base(options)
        {
        }

        public DbSet<GameHouse.Data.Booking> Booking { get; set; } = default!;
    }
