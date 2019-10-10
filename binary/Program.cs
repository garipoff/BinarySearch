using System;

namespace binary
{
    class Program
    {
        public static int BinarySearch(int[] array, int a)
        {
            int left = array.GetLowerBound(0);//Определяем начальный индекс массива
            int right = array.GetUpperBound(0);//Определяем конечный индекс массива
            if (left == right)//Если массив состоит из одного значения
                return left;//Возвращаем 0
            while (true)
            {
                if (right - left == 1)//Если левый и правый элементы соседи
                {
                    if (array[left] == a)//Если левый элемент равняется числу
                        return left;//Возвращаем индекс найденного числа
                    if (array[right] == a)//Если правый элемент равняется числу
                        return right;//Возвращаем индекс найденного числа
                    else
                        return -1;//Возвращем -1, если элемент не найден
                }
                else
                {
                    var middle = left + ((right - left) / 2);//Вычисляем индекс середины отрезка массива
                    if (array[middle] == a)//Если середина отрезка массива равняется числу
                        return middle;//Возвращаем индекс найденного числа
                    if (array[middle] < a)//Если число больше середины отрезка массива
                        left = middle;//Передвигаем левый край массива вместо середины отрезка
                    if (array[middle] > a)//Если число меньше середины отрезка массива
                        right = middle;//Передвигаем правый край край массива вместо середины отрезка
                }
            }
        }
        static void Main(string[] args)
        {
            int[] arr = new int [20];//Создаём массив
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(0, 255);//Заполняем массив сгенерированными числами
            }
            Array.Sort(arr);//Сортируем массив по возрастанию

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0} ",arr[i]);//Выводим отсортированный массив
            }
            Console.Write("\nВведите число для поиска: ");//Запрашиваем число для поиска
            int a = Convert.ToInt32(Console.ReadLine());//Конвертируем введённое значение в число
            Console.WriteLine("index: {0}",BinarySearch(arr, a));//Передаём методу BinarySearh отсортированный массив и число для поиска. Выводим результат
        }
    }
}
