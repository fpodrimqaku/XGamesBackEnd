using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XGames.Models;


namespace XGames.Data
{
    public class XGamesContext : DbContext
    {
        public XGamesContext (DbContextOptions<XGamesContext> options)
            : base(options)
        {
        }

        public DbSet<XGames.Models.Game> Game { get; set; }
        public DbSet<XGames.Models.GamePicture> GamePicture { get; set; }
        public DbSet<XGames.Models.Cart> Cart { get; set; }
        public DbSet<XGames.Models.LineItem> LineItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .Property(p => p.isActive)
                .HasDefaultValueSql("1");
            modelBuilder.Entity<LineItem>()
                .Property(p => p.isActive)
                .HasDefaultValueSql("1");
            modelBuilder.Entity<Cart>()
                .Property(p => p.isActive)
                .HasDefaultValueSql("1");
            modelBuilder.Entity<GamePicture>()
                .Property(p => p.isActive)
                .HasDefaultValueSql("1");
        }
    }
}
