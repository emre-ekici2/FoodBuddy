using System.ComponentModel.DataAnnotations;

namespace FoodBuddy
{
    public class DailyCalories
    {

        [Key]
        public int CaloriesId { get; set; }
        public int Calories { get; set; }

    }
}