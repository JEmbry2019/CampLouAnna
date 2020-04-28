using CampLouAnna.Models;
using Microsoft.EntityFrameworkCore;

namespace CampLouAnna.Data
{
    //Creates a new database context named CampLouAnnaContext
    public class CampLouAnnaContext : DbContext
    {
        public CampLouAnnaContext(DbContextOptions<CampLouAnnaContext> options) : base(options)
        {
        }

        //This is where we register our models as entities
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Camper> Campers { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}