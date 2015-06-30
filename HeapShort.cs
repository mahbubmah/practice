using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CSharp.oDesk.Api.Interfaces;
using CSharp.oDesk.Connect;
using Spring.Json;
using Spring.Social.OAuth1;

namespace UpWorkProfilesApp
{
    class Program
    {
        static void Main(string[] args)
        {        

            int[] intArry = {10,15,48,74,1,5,48,4646,7};
            
            HeapSort(intArry);

            foreach (var i in intArry)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();          

        }
        public static void HeapSort(int[] input)
        {
            //Build-Max-Heap
            int heapSize = input.Length;
            for (int p = (heapSize - 1) / 2; p >= 0; p--)
                MaxHeapify(input, heapSize, p);

            for (int i = input.Length - 1; i > 0; i--)
            {
                //Swap
                int temp = input[i];
                input[i] = input[0];
                input[0] = temp;

                heapSize--;
                MaxHeapify(input, heapSize, 0);
            }
        }
        private static void MaxHeapify(int[] input, int heapSize, int index)
        {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest = 0;

            if (left < heapSize && input[left] > input[index])
                largest = left;
            else
                largest = index;

            if (right < heapSize && input[right] > input[largest])
                largest = right;

            if (largest != index)
            {
                int temp = input[index];
                input[index] = input[largest];
                input[largest] = temp;

                MaxHeapify(input, heapSize, largest);
            }
        }
    }
}
