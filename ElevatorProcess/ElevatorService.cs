using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorProcess
{
    public class ElevatorService
    {
        private readonly AbstractElevator AbstractElevator = null;    
        public ElevatorService(AbstractElevator _AbstractElevator)
        {
            this.AbstractElevator = _AbstractElevator;
        }
        public int AbstractElevatorCall(List<int> RequestList)
        {
            int CurrentFloor = AbstractElevator.ProcessRequest(RequestList);
            return CurrentFloor;
        }


        /// <summary>
        /// Interface Elevator
        /// </summary>
        /// <param name="_IElevator"></param>        
        private readonly IElevator IElevator = null;
        public ElevatorService(IElevator _IElevator)
        {
            this.IElevator = _IElevator;
        }
        public int InterfaceElevatorCall(List<int> RequestList)
        {
            int CurrentFloor = IElevator.ProcessRequest(RequestList);
            return CurrentFloor;
        }



    }
}
