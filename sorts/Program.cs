using System;

namespace Program
{
    class Program
    {
        static int InsertionSort(int[] arr)
        {
            int count = 0;
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;

                // Move elements of arr[0..i-1],
                // that are greater than key,
                // to one position ahead of
                // their current position
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                    count++;
                }
                arr[j + 1] = key;
            }
            return count;
        }

        static int quickSwaps = 0;
        static void swap(int[] arr, int i, int j)
        {
            quickSwaps++;
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        /* This function takes last element as pivot, places
             the pivot element at its correct position in sorted
             array, and places all smaller (smaller than pivot)
             to left of pivot and all greater elements to right
             of pivot */
        static int partition(int[] arr, int low, int high)
        {

            // pivot
            int pivot = arr[high];

            // Index of smaller element and
            // indicates the right position
            // of pivot found so far
            int i = (low - 1);

            for (int j = low; j <= high - 1; j++)
            {

                // If current element is smaller
                // than the pivot
                if (arr[j] < pivot)
                {

                    // Increment index of
                    // smaller element
                    i++;
                    swap(arr, i, j);
                }
            }
            swap(arr, i + 1, high);
            return (i + 1);
        }

        /* The main function that implements QuickSort
                    arr[] --> Array to be sorted,
                    low --> Starting index,
                    high --> Ending index
           */


        static void quickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {

                // pi is partitioning index, arr[p]
                // is now at right place
                int pi = partition(arr, low, high);

                // Separately sort elements before
                // partition and after partition
                quickSort(arr, low, pi - 1);
                quickSort(arr, pi + 1, high);
            }
        }

        static void printArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");

            Console.Write("\n");
        }

        static int[] FillArray(Random r, int l)
        {
            int[] arr = new int[l];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(1, 100000);
            }
            return arr;
        }
        static void Main(string[] args)
        {
            Random r = new Random();
            int l = 1000;
            int[] arr = FillArray(r, l);
            // printArray(arr);
            int insertionSwaps = InsertionSort(arr);
            // printArray(arr);
            Console.WriteLine("Insertion took " + insertionSwaps + " swaps");
            arr = FillArray(r, l);
            quickSort(arr, 0, arr.Length - 1);
            Console.WriteLine("Quick sort took " + quickSwaps + " swaps");

        }
    }
}