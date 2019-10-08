using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElevatorProcess
{
    public class ElevatorOne : AbstractElevator
    {
        private int BottomFloor;
        private int TopFloor;
        public static int CurrentFloor;

        public ElevatorOne(int MinFloor, int MaxFloor, int _CurrentFloor)
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
                    CurrentFloor = base.MoveUp(CurrentFloor, RequestedFloor);
                    base.Stop();
                    base.DoorOpen();
                    Thread.Sleep(2000);
                    base.DoorClosed();
                }
                else if (RequestedFloor < CurrentFloor)
                {
                    CurrentFloor = base.MoveDown(CurrentFloor, RequestedFloor);
                    base.Stop();
                    base.DoorOpen();
                    Thread.Sleep(2000);
                    base.DoorClosed();
                }
            }
            return CurrentFloor;
        }




    }
}
