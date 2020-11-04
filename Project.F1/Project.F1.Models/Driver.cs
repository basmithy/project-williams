using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Project.F1.Models
{
    public class Driver
    {
        public Driver()
        {
            Positions = new List<Position>();
        }
        public int DriverId { get; set; }
        [DisplayName("Name")]
        public string DriverName { get; set; }
        [DisplayName("Photo URL")]
        public string DriverPhoto { get; set; }
        public double DriverTotalPoints { get; set; }

        public int ConstructorId { get; set; }
        public ICollection<Position> Positions { get; set; }
        public Constructor Constructor { get; set; }
    }
}
