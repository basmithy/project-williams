using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.F1.Models
{
    public class PreviousRaceInfoModel
    {
        public string TrackName { get; set; }


        public string WinnerName { get; set; }
        private string winnerPhoto;
        public string WinnerPhoto { get { return winnerPhoto; } set { winnerPhoto = $"../../images/drivers/{value}.png"; } }
        private string winnerTeamColour;
        public string WinnerTeamColour { get { return winnerTeamColour; } set { winnerTeamColour = $"{value}33"; } }


        public string FastestLapName { get; set; }
        private string fastestLapPhoto;
        public string FastestLapPhoto { get { return fastestLapPhoto; } set { fastestLapPhoto = $"../../images/drivers/{value}.png"; } }
        private string fastestLapTeamColour;
        public string FastestLapTeamColour { get { return fastestLapTeamColour; } set { fastestLapTeamColour = $"{value}33"; } }


        public string MostTeamPtsGained { get; set; }
    }
}
