using Project.F1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.F1.Interface.Interface
{
    public interface IPointCalculation
    {
        int GetPointsTotal(List<int> posNums, int fastestLaps);
        int GetConstructorPointsTotal(List<DriverTableModel> driverModels, int id);
    }
}
