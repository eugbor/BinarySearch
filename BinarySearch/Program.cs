using System;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var Array = new int[n];
            SetArray(Array);
            Print(Array);
            SortArray(Array);
            Print(Array);
            SearchValue(Array);
            Console.ReadKey();
        }

        public static void SearchValue(int[] a)
        {
            int averageIndex = 0; // переменная для хранения индекса среднего элемента массива
            int firstIndex = 0; // индекс первого элемента в массиве
            int lastIndex = a.Length - 1; // индекс последнего элемента в массиве
            int searchValue = 5; // искомое (ключевое) значение

            if (lastIndex == -1) Console.WriteLine("\narray is empty"); // массив пуст

            while (firstIndex < lastIndex)
            {
                averageIndex = firstIndex + (lastIndex - firstIndex)/2; // меняем индекс среднего значения
                if (searchValue <= a[averageIndex]) // найден ключевой элемент или нет
                    lastIndex = averageIndex;
                else
                    firstIndex = averageIndex + 1; 
            }
            if (a[lastIndex] == searchValue)
                    Console.WriteLine("\nvalue is found \nindex = {0}", lastIndex);
            else
                    Console.WriteLine("\nvalue is not found");
        }

        public static void SortArray(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (!(a[i] < a[j]))
                    {
                        int b = a[i];
                        a[i] = a[j];
                        a[j] = b;
                    }
                }
            }
        }

        public static void SetArray(int[] a)
        {
            var r = new Random();

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = r.Next(10);
            }
        }

        public static void Print(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("{0} ", a[i]);
            }
            Console.WriteLine();
        }
    }
}
