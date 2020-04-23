using System;

namespace CampLouAnna.Models
{
    public enum Recreation1
    {
        Basketball, Soccer, Baseball
    }

     public enum Recreation2
    {
        Monopoly, DandD, Risk
    }

        public enum Recreation3
    {
        Programing, Graphics, Video
    }
    public class Game
    {
        public Guid ID { get; set; }
       
        public Recreation1 Gym { get; set; }
        public Recreation2 RecRoom { get; set; }
        public Recreation3 Computer { get; set;}

    }
}