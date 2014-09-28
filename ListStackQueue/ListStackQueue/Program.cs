using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListStackQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> nameList = new List<string>();
            Queue<string> nameQueue = new Queue<string>();
            Stack<string> nameStack = new Stack<string>();

            nameList.Add("a");

            nameList[6] = "b";

            string st = nameList[12];

            nameStack.Push("s");

            //nameStack[34] = "jhj";


            nameQueue.Enqueue("q");




        }
    }
}
