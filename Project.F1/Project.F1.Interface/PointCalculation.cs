using Project.F1.Context;
using Project.F1.Interface.Interface;
using Project.F1.Models;
using System;
using System.Collections.Generic;

namespace Project.F1.Interface
{
    public class PointCalculation : IPointCalculation
    {
        private readonly DbInitializer _context;
        public PointCalculation(DbInitializer context)
        {
            _context = context;
        }


        public int GetPointsTotal(List<int> posNums, int fastestLaps)
        {
            int total = 0;
            foreach (var num in posNums)
            {
                switch (num)
                {
                    case 1:
                        total += 25;
                        break;
                    case 2:
                        total += 18;
                        break;
                    case 3:
                        total += 15;
                        break;
                    case 4:
                        total += 12;
                        break;
                    case 5:
                        total += 10;
                        break;
                    case 6:
                        total += 8;
                        break;
                    case 7:
                        total += 6;
                        break;
                    case 8:
                        total += 4;
                        break;
                    case 9:
                        total += 2;
                        break;
                    case 10:
                        total += 1;
                        break;
                }
            }
            return total + fastestLaps;
        }

        public int GetConstructorPointsTotal(List<DriverTableModel> driverModels, int id)
        {
            int total = 0;
            foreach (var driver in driverModels)
            {
                if (driver.ConstructorName == _context.Constructors.Find(id).ConstructorName)
                {
                    total += driver.TotalPoints;
                }
            }
            return total;
        }
    }
}
