using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorProcess
{
    public class ElevatorController
    {
        public static void Main(string[] args)  
        {
            int MinFloor = 0;
            int MaxFloor = 0;
            int CurrentFloor = 0;

            Console.WriteLine("How many floors are there in the building.??");
            string input = Console.ReadLine();
            List<int> RequestList = new List<int>();
            if (Int32.TryParse(input, out MaxFloor))
            {
                RequestList = GetRequestsFromUser(MinFloor, MaxFloor);
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }

            #region Abstract Elevator
            AbstractElevator _AbstractElevator = new ElevatorOne(MinFloor, MaxFloor, CurrentFloor); 
            ElevatorService AbstractElevatorService = new ElevatorService(_AbstractElevator);
            int AbstractElevatorStatus = AbstractElevatorService.AbstractElevatorCall(RequestList);

            //_AbstractElevator = new ElevatorTwo(MinFloor, MaxFloor, CurrentFloor);

            #endregion


            #region Interface Elevator
            //IElevator _IElevator = new ElevatorFour(MinFloor, MaxFloor, CurrentFloor);
            //ElevatorService InterfaceElevatorService = new ElevatorService(_IElevator);
            //int InterfaceElevatorStatus = InterfaceElevatorService.InterfaceElevatorCall(RequestList);
            #endregion

            Console.ReadLine();
        }

        private const string Close = "c";
        public static List<int> GetRequestsFromUser(int MinFloor, int MaxFloors)
        {
            List<int> RquestList = new List<int>();
            string RequestedFloorInput = string.Empty;
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Which floor you wanna go.??");

            while (RequestedFloorInput != Close)
            {
                RequestedFloorInput = Console.ReadLine();
                int RequestedFloor = 0;
                bool ValidInput = Int32.TryParse(RequestedFloorInput, out RequestedFloor);
                if (RequestedFloorInput != Close)
                {
                    if (ValidInput && (RequestedFloor >= MinFloor && RequestedFloor <= MaxFloors))
                        RquestList.Add(RequestedFloor);
                    else
                        Console.WriteLine("Invalid floor.");
                }
                else
                {
                    Console.WriteLine("Closing doors...");
                    break;
                }
            }
            return RquestList;
        }




    }
}
