using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Project.F1.Context;
using Project.F1.Models;

namespace Project.F1.ConsoleApp
{
    public class Program
    {
        private static DbInitializer _context = new DbInitializer();
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing!");

            _context.Database.Migrate();
            
            if(_context.Constructors.Count() == 0)
            {
                AddTeamData();
            }
            if(_context.Positions.Count() == 0)
            {
                AddRacesData();
            }

            //AddTrackData();
            //AddRaceData();
        }


        private static void AddRacesData()
        {
            var races = new Race[]
            {
                new Race
                {
                    TrackId = 1,
                    Positions = new List<Position>
                    {
                        new Position
                        {
                            PositionNumber = 1,
                            DriverId = 1
                        },
                        new Position
                        {
                            PositionNumber = 2,
                            DriverId = 2
                        },
                        new Position
                        {
                            PositionNumber = 3,
                            DriverId = 3
                        },
                        new Position
                        {
                            PositionNumber = 4,
                            DriverId = 5
                        },
                        new Position
                        {
                            PositionNumber = 5,
                            DriverId = 10
                        },
                        new Position
                        {
                            PositionNumber = 6,
                            DriverId = 8
                        },
                        new Position
                        {
                            PositionNumber = 7,
                            DriverId = 6
                        },
                        new Position
                        {
                            PositionNumber = 8,
                            DriverId = 12
                        },
                        new Position
                        {
                            PositionNumber = 9,
                            DriverId = 4
                        },
                        new Position
                        {
                            PositionNumber = 10,
                            DriverId = 14
                        }
                    },
                    FastestLapDriver = "Lewis Hamilton"
                },
                new Race
                {
                    TrackId = 2,
                    Positions = new List<Position>
                    {
                        new Position
                        {
                            PositionNumber = 1,
                            DriverId = 1
                        },
                        new Position
                        {
                            PositionNumber = 2,
                            DriverId = 3
                        },
                        new Position
                        {
                            PositionNumber = 3,
                            DriverId = 4
                        },
                        new Position
                        {
                            PositionNumber = 4,
                            DriverId = 6
                        },
                        new Position
                        {
                            PositionNumber = 5,
                            DriverId = 8
                        },
                        new Position
                        {
                            PositionNumber = 6,
                            DriverId = 10
                        },
                        new Position
                        {
                            PositionNumber = 7,
                            DriverId = 5
                        },
                        new Position
                        {
                            PositionNumber = 8,
                            DriverId = 15
                        },
                        new Position
                        {
                            PositionNumber = 9,
                            DriverId = 18
                        },
                        new Position
                        {
                            PositionNumber = 10,
                            DriverId = 17
                        }
                    },
                    FastestLapDriver = "Max Verstappen"
                },
                new Race
                {
                    TrackId = 3,
                    Positions = new List<Position>
                    {
                        new Position
                        {
                            PositionNumber = 1,
                            DriverId = 2
                        },
                        new Position
                        {
                            PositionNumber = 2,
                            DriverId = 1
                        },
                        new Position
                        {
                            PositionNumber = 3,
                            DriverId = 3
                        },
                        new Position
                        {
                            PositionNumber = 4,
                            DriverId = 6
                        },
                        new Position
                        {
                            PositionNumber = 5,
                            DriverId = 4
                        },
                        new Position
                        {
                            PositionNumber = 6,
                            DriverId = 5
                        },
                        new Position
                        {
                            PositionNumber = 7,
                            DriverId = 12
                        },
                        new Position
                        {
                            PositionNumber = 8,
                            DriverId = 13
                        },
                        new Position
                        {
                            PositionNumber = 9,
                            DriverId = 10
                        },
                        new Position
                        {
                            PositionNumber = 10,
                            DriverId = 9
                        }
                    },
                    FastestLapDriver = "Valtteri Bottas"
                }
            };
            foreach (Race r in races)
            {
                foreach(Position p in r.Positions)
                {
                    p.Driver = _context.Drivers.Find(p.DriverId);
                }
                _context.Races.Add(r);
            }
            _context.SaveChanges();
        }

        private static void AddTeamData()
        {
            var teams = new Constructor[]
            {
                new Constructor
                {
                    ConstructorName = "Mercedes",
                    ConstructorColour = "#00D2BE"
                },
                new Constructor
                {
                    ConstructorName = "Red Bull Racing",
                    ConstructorColour = "#0600ef"
                },
                new Constructor
                {
                    ConstructorName = "Renault",
                    ConstructorColour = "#FFF500"
                },
                new Constructor
                {
                    ConstructorName = "Ferrari",
                    ConstructorColour = "#DC0000"
                },
                new Constructor
                {
                    ConstructorName = "Racing Point",
                    ConstructorColour = "#F596C8"
                },
                new Constructor
                {
                    ConstructorName = "McLaren",
                    ConstructorColour = "#FF8700"
                },
                new Constructor
                {
                    ConstructorName = "AlphaTauri",
                    ConstructorColour = "#ffffff"
                },
                new Constructor
                {
                    ConstructorName = "Alfa Romeo Racing",
                    ConstructorColour = "#960000"
                },
                new Constructor
                {
                    ConstructorName = "Haas F1 Constructor",
                    ConstructorColour = "#787878"
                },
                new Constructor
                {
                    ConstructorName = "Williams",
                    ConstructorColour = "#0082fa"
                }
            };
            foreach (Constructor t in teams)
            {
                _context.Constructors.Add(t);
            }
            _context.SaveChanges();
        }

        private static void AddTrackData()
        {
            var tracks = new Track[]
            {
                new Track{ TrackName = "Race 1"},
                new Track{ TrackName = "Race 2" },
                new Track{ TrackName = "Race 3" }
            };

            foreach(Track t in tracks)
            {
                _context.Tracks.Add(t);
            }
            _context.SaveChanges();
        }

        private static void AddRaceData()
        {
            var races = new Race[]
            {
                new Race
                {
                     Track = _context.Tracks.FirstOrDefault(x => x.TrackName == "Race 1"),
                     Positions = new List<Position>
                     {
                         new Position { PositionNumber = 1, DriverId = _context.Drivers.FirstOrDefault(x => x.DriverName == "Lewis Hamilton").DriverId },
                         new Position { PositionNumber = 2, DriverId = _context.Drivers.FirstOrDefault(x => x.DriverName == "Valtteri Bottas").DriverId },
                         new Position { PositionNumber = 3, DriverId = _context.Drivers.FirstOrDefault(x => x.DriverName == "Max Verstappen").DriverId },
                         new Position { PositionNumber = 4, DriverId = _context.Drivers.FirstOrDefault(x => x.DriverName == "Charles Leclerc").DriverId },
                         new Position { PositionNumber = 5, DriverId = _context.Drivers.FirstOrDefault(x => x.DriverName == "Pierre Gasly").DriverId },
                         new Position { PositionNumber = 6, DriverId = _context.Drivers.FirstOrDefault(x => x.DriverName == "Carlos Sainz").DriverId },
                         new Position { PositionNumber = 7, DriverId = _context.Drivers.FirstOrDefault(x => x.DriverName == "Sergio Perez").DriverId },
                         new Position { PositionNumber = 8, DriverId = _context.Drivers.FirstOrDefault(x => x.DriverName == "Esteban Ocon").DriverId },
                         new Position { PositionNumber = 9, DriverId = _context.Drivers.FirstOrDefault(x => x.DriverName == "Daniel Ricciardo").DriverId },
                         new Position { PositionNumber = 10, DriverId = _context.Drivers.FirstOrDefault(x => x.DriverName == "Sebastien Vettel").DriverId },
                     },
                     FastestLapDriver = "Lewis Hamilton"
                }
            };

            foreach (Race r in races)
            {
                _context.Races.Add(r);
            }
            _context.SaveChanges();
        }
    }
}
