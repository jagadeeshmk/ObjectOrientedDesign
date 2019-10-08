using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorProcess
{
    public class AsyncAwaitTest
    {

        public int GetInput()
        {
            string input = string.Empty;
            int InputID = 0;
            while (input != "c")
            {
                Console.WriteLine("Enter floor number.??");
                input = Console.ReadLine();

                Int32.TryParse(input, out InputID);
                //yield return InputID;
            }
            return InputID;
        }




    }
}
