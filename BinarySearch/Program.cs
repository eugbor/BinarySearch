using System;

namespace BinarySearch
{
    class Program
    {
        /// <summary>
        /// Алгоритм бинарного (двоичного) поиска (2 способа: рекурсивный и нерекурсивный).
        /// Вычесление времени решения задачи.
        /// Вывод Debug на консоль.
        /// Полиморфизм.
        /// </summary>
        static void Main(string[] args)
        {
            //var car = new Car();
            //car.Go();

            int n = int.Parse(Console.ReadLine());
            var Arr = new int[n];
            SetArray(Arr);
            Print(Arr);
            SortArray(Arr);
            Print(Arr);

            var A = SearchArray(Arr, 0, Arr.Length-1, 5);
            Console.WriteLine("{0}", A);

            Console.WriteLine("{0}", SearchValue(Arr));


            int countIteration = 1000;
            var start = DateTime.Now;
            for (int i = 0; i < countIteration; i++)
            {
                var index = SearchValue(Arr);
            }
            Console.WriteLine((DateTime.Now - start).TotalMilliseconds / 1000);

            var start1 = DateTime.Now;
            for (int i = 0; i < countIteration; i++)
            {
                var index = SearchArray(Arr, 0, Arr.Length - 1, 5);
            }
            Console.WriteLine((DateTime.Now - start1).TotalMilliseconds / 1000);


            Console.ReadKey();
        }

        public static int SearchArray(int[] array, int startIndex, int endIndex, int value) // рекурсивный
        {
            //Debug.WriteLine("{0} {1}", startIndex, endIndex);
            int average = startIndex + (endIndex - startIndex)/2;

            if (endIndex <= startIndex)
                return -1;

            if (array[average] > value)
                return SearchArray(array, startIndex, average, value);

            if (array[average] == value)
                return average;

            return SearchArray(array, average + 1, endIndex, value);
        }

        public static int SearchValue(int[] a) // нерекурсивный
        {
            int averageIndex = 0; // переменная для хранения индекса среднего элемента массива
            int firstIndex = 0; // индекс первого элемента в массиве
            int lastIndex = a.Length - 1; // индекс последнего элемента в массиве
            int searchValue = 5; // искомое (ключевое) значение

            for (int i = 0; i < a.Length; i++)
            {
                averageIndex = firstIndex + (lastIndex - firstIndex) / 2; // меняем индекс среднего значения
                if (searchValue <= a[averageIndex]) // найден ключевой элемент или нет
                    lastIndex = averageIndex;
                else
                    firstIndex = averageIndex + 1;
            }
            if (a[lastIndex] == searchValue)
                return lastIndex;
            return -1;
        }

        public static void SortArray(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] > a[j])
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
