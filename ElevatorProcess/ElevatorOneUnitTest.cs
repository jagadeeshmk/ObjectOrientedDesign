using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorProcess
{
    [TestClass]
    public class ElevatorOneUnitTest
    {
        [TestMethod]
        public void ElevatorOneTest()  
        {
            int MinFloor = 0, MaxFloors = 10, CurrentFloor = 0;
            List<int> RequestList = new List<int>();
            RequestList.Add(5);
            RequestList.Add(4);
            RequestList.Add(11);
            RequestList.Add(-1);
            
            AbstractElevator _ElevatorOne = new ElevatorOne(MinFloor, MaxFloors, CurrentFloor);   //manual IOC without unity
            Console.WriteLine("Requested floors are ");
            foreach (var item in RequestList)
            {
                Console.WriteLine(item);
            }
            foreach (var item in RequestList)
            {
                CurrentFloor = _ElevatorOne.MoveUp(CurrentFloor, item);
            }
            foreach (var item in RequestList)
            {
                CurrentFloor = _ElevatorOne.MoveDown(CurrentFloor, item);
            }
            Console.ReadLine();
        }
    }
}
