using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 12, 11, 13, 5, 6, 7 };
            Console.WriteLine("Original: " + string.Join(", ", array));

            sort(array);

            Console.WriteLine("Sorted: " + string.Join(", ", array));
        }

        public static void sort(int[] arr)
        {
            int n = arr.Length;

            // Build heap (rearrange array)
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(arr, n, i);

            // Extract elements from heap one by one
            for (int i = n - 1; i > 0; i--)
            {
                // Move current root to end
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                // Call max heapify on the reduced heap
                heapify(arr, i, 0);
            }
        }
        public static void heapify(int[] arr, int n, int i)
        {
            int largest = i; // Initialize largest as root
            int left = 2 * i + 1; // left = 2*i + 1
            int right = 2 * i + 2; // right = 2*i + 2

            // If left child is larger than root
            if (left < n && arr[left] > arr[largest])
                largest = left;

            // If right child is larger than largest so far
            if (right < n && arr[right] > arr[largest])
                largest = right;

            // If largest is not root
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                // Recursively heapify the affected sub-tree
                heapify(arr, n, largest);
            }
        }
    }
}
