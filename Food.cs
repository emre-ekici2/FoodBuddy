using System.ComponentModel.DataAnnotations;

namespace FoodBuddy
{
    public class Food
    {
        [Key]
        public int Id { get; set; }
        public string Foodname { get; set; }
        public int Calories { get; set; }
        public int ServingSize{ get; set; }
        public string ServingType { get; set; }
        public int Protein{ get; set; }
        public int Carbohydrate { get; set; }
        public int Fat { get; set; }

    }
}