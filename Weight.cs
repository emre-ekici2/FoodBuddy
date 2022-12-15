using System;
using System.ComponentModel.DataAnnotations;

namespace FoodBuddy
{
    public class Weight
    {
        [Key]
        public int WeightId { get; set; }
        public Double WeighIn { get; set; }
        
    }
}