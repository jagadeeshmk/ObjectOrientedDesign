using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorProcess
{
    public abstract class AbstractElevator //: IElevator
    {
        public virtual int MoveUp(int CurrentFloor, int RequestedFloor)
        {
            Console.WriteLine("Elevator moving up...");
            int _CurrentRunningFloor = CurrentFloor;
            for (int i = CurrentFloor; i <= RequestedFloor; i++)
            {
                _CurrentRunningFloor = i;
                if (_CurrentRunningFloor == RequestedFloor)
                {
                    Console.WriteLine("Floor {0}", _CurrentRunningFloor);
                    break;
                }
                else
                {
                    Console.WriteLine("Floor {0}", _CurrentRunningFloor);
                    continue;
                }
            }
            return _CurrentRunningFloor;
        }

        public virtual int MoveDown(int CurrentFloor, int RequestedFloor)
        {
            Console.WriteLine("Elevator moving down...");
            int _CurrentRunningFloor = 0;
            for (int i = CurrentFloor; i >= RequestedFloor; i--)
            {
                _CurrentRunningFloor = i;
                if (_CurrentRunningFloor == RequestedFloor)
                {
                    Console.WriteLine("Floor {0}", _CurrentRunningFloor);
                    break;
                }
                else
                {
                    Console.WriteLine("Floor {0}", _CurrentRunningFloor);
                    continue;
                }
            }
            return _CurrentRunningFloor;
        }

        public virtual void Stop()
        {
            Console.WriteLine("Elevator stopped.");
        }

        public virtual void StayThere()
        {
            Console.WriteLine("You are on the same floor.");
        }

        public virtual void OverTheLimit(int UpperLimit)
        {
            Console.WriteLine("Upper limit is {0}. Cannot move up.!!", UpperLimit);
        }

        public virtual void UnderTheLimit(int LoweLimit)
        {
            Console.WriteLine("Lower limit is {0}. Cannot move down.!!", LoweLimit);
        }

        public virtual void DoorOpen()
        {
            Console.WriteLine("Door opened.");
        }

        public virtual void DoorClosed()
        {
            Console.WriteLine("Doors closed");
        }

        public virtual List<int> SortedRequestList(List<int> RequestList, int CurrentFloor)
        {
            int FirstRequest = RequestList.FirstOrDefault();

            if (FirstRequest == CurrentFloor)
                FirstRequest = RequestList.Skip(1).FirstOrDefault();

            if (FirstRequest > CurrentFloor)
                RequestList = RequestList.OrderBy(x => x).ToList();
            else
                RequestList = RequestList.OrderByDescending(x => x).ToList();
            return RequestList;
        }

        public abstract int ProcessRequest(List<int> RquestList);
    }
}
