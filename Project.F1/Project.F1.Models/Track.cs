using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Project.F1.Models
{
    public class Track
    {
        public int TrackId { get; set; }
        [DisplayName("Track Name")]
        public string TrackName { get; set; }

        
        public ICollection<Race> Races { get; set; }

    }
}
