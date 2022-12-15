using Microsoft.EntityFrameworkCore;
using System.Data.SQLite;
using System.IO;

namespace FoodBuddy
{
    public class DataContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = DataFile.db");
        }

        public DbSet<User> User { get; set; }

        public DbSet<Weight> Weight { get; set; }

        public DbSet<DailyCalories> DailyCalories { get; set; }

        public DbSet<Food> Food { get; set; }

        public DbSet<DailyFoodList> DailyFoodList { get; set; }

    }
    
}
