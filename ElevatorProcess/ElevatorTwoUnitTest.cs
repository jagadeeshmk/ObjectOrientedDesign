using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorProcess
{
    public class ElevatorTwoUnitTest
    {
        public static void Main1(string[] args)
        {
            int MinFloor = 0, MaxFloor = 10, CurrentFloor = 0;
            int RequestedFloor = 8;
            AbstractElevator _AbstractElevator = new ElevatorTwo(MinFloor, MaxFloor, CurrentFloor); 
            CurrentFloor = _AbstractElevator.MoveUp(CurrentFloor, RequestedFloor);
            _AbstractElevator.Stop();
            _AbstractElevator.DoorOpen();
            _AbstractElevator.DoorClosed();
            CurrentFloor = _AbstractElevator.MoveDown(CurrentFloor, RequestedFloor);
            _AbstractElevator.OverTheLimit(11);
            _AbstractElevator.UnderTheLimit(-1);
            _AbstractElevator.StayThere();
            Console.ReadLine();
        }

    }
}
