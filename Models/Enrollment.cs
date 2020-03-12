using System;

namespace StudentInformationThur.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public Guid ID { get; set; }
        public Guid SportsID { get; set; }
        public Guid CampersID { get; set; }
        public Grade? Grade { get; set; }

        public Sport Sport { get; set; }
        public Camper Camper { get; set; }
    }
}