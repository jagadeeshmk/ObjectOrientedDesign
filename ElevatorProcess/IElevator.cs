using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorProcess
{
    public interface IElevator
    {
        int MoveUp(int CurrentFloor, int RequestedFloor);
        int MoveDown(int CurrentFloor, int RequestedFloor);
        void Stop();
        void StayThere();
        void OverTheLimit(int UpperLimit);
        void UnderTheLimit(int LoweLimit);
        void DoorOpen();
        void DoorClosed();
        List<int> SortedRequestList(List<int> RequestList, int CurrentFloor);
        int ProcessRequest(List<int> RquestList);
    }
}
