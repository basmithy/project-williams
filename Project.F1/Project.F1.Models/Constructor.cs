using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Project.F1.Models
{
    public class Constructor
    {
        public Constructor()
        {
            Drivers = new List<Driver>();
        }

        public int ConstructorId { get; set; }
        [DisplayName("Constructor")]
        public string ConstructorName { get; set; }
        [DisplayName("Colour")]
        public string ConstructorColour { get; set; }
        public double ConstructorTotalPoints { get; set; }

        public ICollection<Driver> Drivers { get; set; }
    }
}
