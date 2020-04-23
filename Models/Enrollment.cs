using System;

namespace CampLouAnna.Models
{
    public enum Grade
    {
        Primary, Middle, High
    }

    public class Enrollment
    {
        public Guid ID { get; set; }
        public Guid CamperID { get; set; }
        public Guid MealsID { get; set; }
        public Guid GameID { get; set; }
        public Grade? Grade { get; set; }
        

        public Course Course { get; set; }
        public Camper Camper { get; set; }

        
    }
}