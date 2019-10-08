using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElevatorProcess
{
    public class ElevatorTwo : AbstractElevator
    {
        private int BottomFloor;
        private int TopFloor;
        public static int CurrentFloor;
        public List<int> SkipList = new List<int>() { 3 };

        public ElevatorTwo(int MinFloor, int MaxFloor, int _CurrentFloor)
        {
            BottomFloor = MinFloor;
            TopFloor = MaxFloor;
            CurrentFloor = _CurrentFloor;
        }

        public override int ProcessRequest(List<int> RquestList)
        {
            RquestList = base.SortedRequestList(RquestList, CurrentFloor);
            foreach (var RequestedFloor in RquestList)
            {
                Console.WriteLine(Environment.NewLine);

                if (RequestedFloor > TopFloor)
                    base.OverTheLimit(TopFloor);
                else if (RequestedFloor < BottomFloor)
                    base.UnderTheLimit(BottomFloor);
                else if (RequestedFloor == CurrentFloor)
                    base.StayThere();
                else if (RequestedFloor > CurrentFloor)
                {
                    CurrentFloor = MoveUp(CurrentFloor, RequestedFloor);
                    if (!SkipList.Contains(RequestedFloor))
                    {
                        base.Stop();
                        base.DoorOpen();
                        Thread.Sleep(2000);
                        base.DoorClosed();
                    }
                }
                else if (RequestedFloor < CurrentFloor)
                {
                    CurrentFloor = MoveDown(CurrentFloor, RequestedFloor);
                    if (!SkipList.Contains(RequestedFloor))
                    {
                        base.Stop();
                        base.DoorOpen();
                        Thread.Sleep(2000);
                        base.DoorClosed();
                    }
                }
            }
            return CurrentFloor;
        }

        public override int MoveUp(int CurrentFloor, int RequestedFloor)
        {
            Console.WriteLine("Elevator moving up...");
            Console.WriteLine("Floor {0}", CurrentFloor);
            int _CurrentRunningFloor = 0;
            for (int i = CurrentFloor + 1; i <= RequestedFloor; i++)
            {
                _CurrentRunningFloor = i;
                if (SkipList.Contains(_CurrentRunningFloor))
                {
                    Console.WriteLine("Skipping Floor {0} . . .", _CurrentRunningFloor);
                    Console.WriteLine("Skipped Floor {0}", _CurrentRunningFloor);
                    continue;
                }
                else
                {
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
            }
            return _CurrentRunningFloor;
        }

        public override int MoveDown(int CurrentFloor, int RequestedFloor)
        {
            Console.WriteLine("Elevator moving down...");
            Console.WriteLine("Floor {0}", CurrentFloor);
            int _CurrentRunningFloor = 0;
            for (int i = CurrentFloor - 1; i >= RequestedFloor; i--)
            {
                _CurrentRunningFloor = i;
                if (SkipList.Contains(_CurrentRunningFloor))
                {
                    Console.WriteLine("Skipping Floor {0} . . .", _CurrentRunningFloor);
                    Console.WriteLine("Skipped Floor {0}", _CurrentRunningFloor);
                    continue;
                }
                else
                {
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
            }
            return _CurrentRunningFloor;
        }




    }
}
