using Microsoft.EntityFrameworkCore;
using PizzaApp.Api.Models;
using System.Collections.Generic;

namespace PizzaApp.Api.Infrastructure
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options) { }

        public DbSet<Pizza> Pizzas { get; set; }
    }
}
