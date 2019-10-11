using System;

namespace binary
{
    class Program
    {
        public static int BinarySearch(int[] array, int a)
        {
            int left = array.GetLowerBound(0);//Определяем начальный индекс массива
            int right = array.GetUpperBound(0);//Определяем конечный индекс массива
            if (left == right && array[left] == a)//Если массив состоит из одного значения и оно равно числу
                return left;//Возвращаем 0 
            if (left == right && array[left] != a)//Если массив состоит из одного значения и оно не равно числу
                return -1;//Возвращем -1
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

        public static int[] Arr()
        {
            int[] arr = new int[20];//Создаём массив
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(0, 255);//Заполняем массив сгенерированными числами
            }
            Array.Sort(arr);//Сортируем массив по возрастанию
            return arr;
        }

        public static void Type()
        {
            int[] arr = Arr();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0} ", arr[i]);//Выводим отсортированный массив
            }

            while (true)
            {
                Console.Write("\nВведите число для поиска: ");//Запрашиваем число для поиска
                try
                {
                    int a = Convert.ToInt32(Console.ReadLine());
                    int result = BinarySearch(arr, a);//Передаём методу BinarySearh отсортированный массив и число для поиска

                    switch (result)
                    {
                        case -1:
                            Console.WriteLine("{0} не найден", a); //Выводим результат, если число не найдено
                            break;
                        default:
                            Console.WriteLine("{0} найден. Индекс: {1}", a, result);//Выводим результат, если число найдено
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Неверный формат входных данных");//Выходим из цикла в случае ошибки
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            Type();
        }
    }
}
