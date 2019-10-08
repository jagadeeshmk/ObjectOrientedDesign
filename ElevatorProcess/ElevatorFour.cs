using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElevatorProcess
{
    public class ElevatorFour : IElevator
    {
        private int BottomFloor;
        private int TopFloor;
        public static int CurrentFloor;
        public ElevatorFour(int MinFloor, int MaxFloor, int _CurrentFloor)
        {
            BottomFloor = MinFloor;
            TopFloor = MaxFloor;
            CurrentFloor = _CurrentFloor;
        }

        #region IElevator Members

        public int MoveUp(int CurrentFloor, int RequestedFloor)
        {
            Console.WriteLine("Elevator moving up...");
            int _CurrentRunningFloor = 0;
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

        public int MoveDown(int CurrentFloor, int RequestedFloor)
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

        public void Stop()
        {
            Console.WriteLine("Elevator stopped.");
        }

        public void StayThere()
        {
            Console.WriteLine("You are on the same floor.");
        }

        public void OverTheLimit(int UpperLimit)
        {
            Console.WriteLine("Upper limit is {0}. Cannot move up.!!", UpperLimit);
        }

        public void UnderTheLimit(int LoweLimit)
        {
            Console.WriteLine("Lower limit is {0}. Cannot move down.!!", LoweLimit);
        }

        public void DoorOpen()
        {
            Console.WriteLine("Door opened.");
        }

        public void DoorClosed()
        {
            Console.WriteLine("Doors closed");
        }

        public List<int> SortedRequestList(List<int> RequestList, int CurrentFloor)
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

        public int ProcessRequest(List<int> RquestList)
        {
            RquestList = SortedRequestList(RquestList, CurrentFloor);
            foreach (var RequestedFloor in RquestList)
            {
                Console.WriteLine(Environment.NewLine);

                if (RequestedFloor > TopFloor)
                    OverTheLimit(TopFloor);
                else if (RequestedFloor < BottomFloor)
                    UnderTheLimit(BottomFloor);
                else if (RequestedFloor == CurrentFloor)
                    StayThere();
                else if (RequestedFloor > CurrentFloor)
                {
                    CurrentFloor = MoveUp(CurrentFloor, RequestedFloor);
                    Stop();
                    DoorOpen();
                    Thread.Sleep(2000);
                    DoorClosed();
                }
                else if (RequestedFloor < CurrentFloor)
                {
                    CurrentFloor = MoveDown(CurrentFloor, RequestedFloor);
                    Stop();
                    DoorOpen();
                    Thread.Sleep(2000);
                    DoorClosed();
                }
            }
            return CurrentFloor;
        }

        #endregion

        
    }
}
