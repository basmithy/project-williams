using System;
using System.Collections;
using System.Collections.Generic;

namespace Project.F1.Models
{
    public class Race
    {
        public Race()
        {
            Positions = new List<Position>();
        }

        public int RaceId { get; set; }
        public string FastestLapDriver { get; set; }

        public int TrackId { get; set; }
        public Track Track { get; set; }
        public ICollection<Position> Positions { get; set; }
    }
}