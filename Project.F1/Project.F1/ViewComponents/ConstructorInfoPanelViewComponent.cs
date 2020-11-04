using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.F1.Context;
using Project.F1.Interface.Interface;
using Project.F1.Models;

namespace Project.F1.ViewComponents
{
    [ViewComponent(Name = "ConstructorInfoPanel")]
    public class ConstructorInfoPanelViewComponent : ViewComponent
    {
        private readonly DbInitializer _context;
        private readonly IPointCalculation _pointCalculation;
        public ConstructorInfoPanelViewComponent(DbInitializer context, IPointCalculation pointCalculation)
        {
            _pointCalculation = pointCalculation;
            _context = context;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var drivers = _context.Drivers.Include(x => x.Constructor);
            List<int> driverIds = new List<int>();
            foreach (var driver in drivers)
            {
                driverIds.Add(driver.DriverId);
            }

            var races = _context.Races.Include(t => t.Track).Include(p => p.Positions).Include(p => p.Positions).ThenInclude(d => d.Driver).ThenInclude(c => c.Constructor);

            List<DriverTableModel> driverModels = new List<DriverTableModel>();

            // Iterating through each driver by its ID value
            // in preparation to calculate points
            foreach (var id in driverIds)
            {
                List<int> posNums = new List<int>();
                int fastestLaps = 0;
                foreach (var race in races)
                {
                    // Checking if the driver is even in the top 10 positions, before making queries
                    if(race.Positions.Where(x => x.DriverId == id).Count() != 0)
                    {
                        foreach (var position in race.Positions)
                        {
                            if (position.DriverId == id)
                            {
                                // Adding all the race position numbers to a list related to each driver
                                posNums.Add(race.Positions.Where(x => x.DriverId == id).FirstOrDefault().PositionNumber);
                            }
                        }
                        // Adding one to a 'fastest laps' counter if present
                        if (race.FastestLapDriver == race.Positions.Where(x => x.DriverId == id)?.FirstOrDefault().Driver.DriverName)
                        {
                            fastestLaps++;
                        }
                    }
                }
                driverModels.Add(new DriverTableModel()
                {
                    DriverName = drivers.Where(x => x.DriverId == id).FirstOrDefault().DriverName,
                    ConstructorName = drivers.Where(x => x.DriverId == id).FirstOrDefault().Constructor.ConstructorName,
                    TotalPoints = _pointCalculation.GetPointsTotal(posNums, fastestLaps)
                });
            }



            var constructors = _context.Constructors.Include(x => x.Drivers);
            List<int> constructorIds = new List<int>();
            foreach (var constructor in constructors)
            {
                constructorIds.Add(constructor.ConstructorId);
            }

            List<DriverTableModel> constructorModels = new List<DriverTableModel>();
            foreach(var id in constructorIds)
            {
                constructorModels.Add(new DriverTableModel()
                {
                    ConstructorName = constructors.Where(x => x.ConstructorId == id).FirstOrDefault().ConstructorName,
                    TotalPoints = _pointCalculation.GetConstructorPointsTotal(driverModels, id)
                });
            }

            var viewModel = constructorModels.OrderByDescending(x => x.TotalPoints).ThenBy(x => x.ConstructorName).ToList();
            return View("ConstructorInfoPanel", viewModel);
        }

    }
}
