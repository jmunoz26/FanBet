using System;
using FanBet.Shared.Entites;
using Microsoft.EntityFrameworkCore;

namespace FanBet.Backend.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
  public DbSet<Country> Countries { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();
  }
}

