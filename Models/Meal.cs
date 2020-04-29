using System;

namespace CampLouAnna.Models
{
    public enum Morn
    {
        Cereal, Sausage, Eggs
    }

     public enum Mid
    {
        Hotdog, Hamburger, Salad
    }

        public enum Food
    {
        Apple, Chips, Fruitbar
    }
    public class Meal
  
    {
        public Guid ID { get; set; }
       
        public Morn Breakfast { get; set; }
        public Mid Lunch { get; set; }
        public Food Snack { get; set;}
        public string FoodDisplay {get{return $"{Breakfast}, { Lunch}, and {Snack}";}}

    }






}