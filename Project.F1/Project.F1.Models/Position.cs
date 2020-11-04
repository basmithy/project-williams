using System;
using System.Collections.Generic;
using System.Text;

namespace Project.F1.Models
{
    public class Position
    {
        public int PositionId { get; set; }
        public int PositionNumber { get; set; }


        public int RaceId { get; set; }
        public int DriverId { get; set; }
        public Race Race { get; set; }
        public Driver Driver { get; set; }
    }

}
