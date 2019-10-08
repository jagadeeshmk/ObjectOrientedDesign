using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorProcess
{
    public class ElevatorFourUnitTest
    {
        public static void Main1(string[] args) 
        {
            int MinFloor = 0, MaxFloor = 10, CurrentFloor = 0;
            int RequestedFloor = 8;
            IElevator _IElevator = new ElevatorFour(MinFloor, MaxFloor, CurrentFloor);
            _IElevator.MoveUp(CurrentFloor, RequestedFloor);
            _IElevator.Stop();
            _IElevator.DoorOpen();
            _IElevator.DoorClosed();
            _IElevator.OverTheLimit(MaxFloor);
            _IElevator.UnderTheLimit(MinFloor);
            _IElevator.StayThere();
            _IElevator.MoveDown(CurrentFloor, RequestedFloor);
            Console.ReadLine();
        }
    }
}
