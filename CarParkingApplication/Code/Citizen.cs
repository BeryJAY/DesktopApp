using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarParkingApplication
{
    public class Citizen
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Sex{ get; set; }
        public string NIN { get; set; }

    }

    public enum Gender
    {
        Male,Female
    }
}