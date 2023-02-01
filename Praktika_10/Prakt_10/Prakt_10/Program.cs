using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Prakt_10
{
    class Program
    {
        static string[,] info()
        {
            int n = 0;
            int m = 0;
            while (n <= 0)
            {
                Console.WriteLine("Введите количество работников");
                n = int.Parse(Console.ReadLine());
                if (n <= 0) Console.WriteLine("Такого не может быть");
            }
            while (m <= 0)
            {
                Console.WriteLine("Введите количество месяцев");
                m = int.Parse(Console.ReadLine());
                if (m <= 0) Console.WriteLine("Такого не может быть");
            }
            string[,] rab = new string[n + 1, m + 2];
            return rab;
        }

        static string[,] tabl(string[,] rab)
        {
            for (int i = 0; i < rab.GetLength(0); i++)
            {
                for (int j = 0; j < rab.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        if (j == 0) rab[i, j] = "            ";
                        else if (j == 1) rab[i, j] = "Дата рождения  ";
                        else rab[i, j] = $"{j - 1} месяц     ";

                    }
                    if (i > 0 && j == 0) rab[i, j] = $"{i} работник  ";
                    if (j == 1 && i > 0)
                    {
                            try
                            {
                                DateTime dt;
                                Console.WriteLine($"Введите дату рождения {i} работника");
                                dt = DateTime.Parse(Console.ReadLine());
                                rab[i, j] = dt.ToString("dd MMM yyyy") + "      ";
                            }
                            catch
                            {
                                Console.WriteLine("Введено неверно");
                                DateTime dt;
                                Console.WriteLine($"Введите дату рождения {i} работника");
                                dt = DateTime.Parse(Console.ReadLine());
                                rab[i, j] = dt.ToString("dd MMM yyyy") + "      ";
                            }
                    }
                    if (j > 1 && i > 0)
                    {
                         try
                         {
                             Console.WriteLine($"Введите заработную плату {i} работника за {j - 1} месяц");
                             double zarp = double.Parse(Console.ReadLine());
                             rab[i, j] = Convert.ToString(zarp + "       ");
                                
                         }
                         catch
                         {
                             Console.WriteLine("Введите правильно");
                         }
                    }
                }

            }
            return rab;
        }
        static void maxx(string[,] rab)
        {
            try
            {
                Console.WriteLine("Введите номер работника");
                int num = int.Parse(Console.ReadLine());
                double max = int.MinValue;

                for (int n = num; n < num + 1; n++)
                {
                    for (int m = 2; m < rab.GetLength(1); m++)
                    {
                        if (max < Convert.ToDouble(rab[n, m])) max = Convert.ToDouble(rab[n, m]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine($"Наибольшя зарплата {num} работника - {max}");
            }
            catch
            {
                Console.WriteLine("Введено неверное значение");
            }
        }
        static void vivod(string[,] rab)
        {
            for (int i = 0; i < rab.GetLength(0); i++)
            {
                for (int m = 0; m < rab.GetLength(1); m++)
                {
                    Console.Write(rab[i, m]);
                }
                Console.WriteLine();
            }
        }

        static void graf(string[,] rab)
        {
            try
            {
                int a = 0;
                int gr = 0;
                int[] rcount = new int[rab.GetLength(0)];
                int[] vcount = new int[rab.GetLength(0)];
                int month = 0;
                int vrem = 0;

                int year = DateTime.Now.Year;
                for (int i = 0; i < rab.GetLength(0); i++)
                {
                    a = 0;
                    gr = 0;
                    month = 0;
                    while (gr != 1 && gr != 2)
                    {
                        Console.WriteLine($"Введите график работы {i + 1} работника (1 - если 2/2, 2 - если 5/2)");
                        gr = int.Parse(Console.ReadLine());
                        if (gr != 1 && gr != 2) Console.WriteLine("Введено неверное значение");
                    }
                    if (gr == 1)
                    {
                        while (month < 1 || month > 12)
                        {
                            Console.WriteLine("Введите номер месяца для вывода календаря");
                            month = int.Parse(Console.ReadLine());
                            if (month < 1 || month > 12) Console.WriteLine("Такого месяца не существует");
                        }
                        DateTime dt = new DateTime(year, month, 1);
                        while (a == 0)
                        {
                            vrem++;
                            if (vrem == 1 || vrem == 2) rcount[i]++;
                            else vcount[i]++;
                            if (vrem == 4) vrem = 0;
                            dt = dt.AddDays(1.0);
                            if (dt.Month != month)
                            {
                                vrem = 0;
                                a = 1;
                            }
                        }
                    }
                    if (gr == 2)
                    {
                        while (month < 1 || month > 12)
                        {
                            Console.WriteLine("Введите номер месяца для вывода календаря");
                            month = int.Parse(Console.ReadLine());
                            if (month < 1 || month > 12) Console.WriteLine("Такого месяца не существует");
                        }
                        DateTime dt = new DateTime(year, month, 1);
                        while (a == 0)
                        {
                            if (dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday) vcount[i]++;
                            else rcount[i]++;
                            dt = dt.AddDays(1.0);
                            if (dt.Month != month)
                            {
                                a = 1;
                            }
                        }
                    }
                }
                Console.WriteLine("                         Рабочих дней            Выходных дней");
                for (int i = 0; i < rab.GetLength(0) - 1; i++)
                {
                    Console.WriteLine($"{i + 1} работник                  {rcount[i]}                      {vcount[i]}");
                }
            }
            catch
            {
                Console.WriteLine("Введено неверное значение");
            }
        }

        static void Age()
        {
            try
            {
                int age = 0;
                while (age < 1 || age > 99)
                {
                    Console.WriteLine("Введите возраст");
                    age = int.Parse(Console.ReadLine());
                    if (age < 1 || age > 99) Console.WriteLine("Ошибка");
                }
                Console.WriteLine();
                int ost = age % 10;
                if (age >= 11 && age <= 15) Console.WriteLine($"{age} лет");
                else
                {
                    if (ost == 1) Console.WriteLine($"{age} год");
                    if (ost >= 2 && ost <= 4) Console.WriteLine($"{age} года");
                    if (ost >= 5 && ost <= 9 || ost == 0) Console.WriteLine($"{age} лет");
                }
                Console.WriteLine();
                int day = 0;
                int month = 0;
                while (true)
                {
                    Console.WriteLine("Введите день");
                    day = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите месяц");
                    month = int.Parse(Console.ReadLine());
                    if (day >= 32 || day <= 0 || month <= 0 || month >= 13) Console.WriteLine("Неверно введены данные");
                    else if (DateTime.DaysInMonth(2023, month) < day) Console.WriteLine("Неверно введены данные");
                    else break;
                }
                Console.WriteLine();
                DateTime dt = new DateTime(2023, month, day);
                string data = dt.ToString("dd MMMM");
                Console.WriteLine(data);
            }
            catch
            {
                Console.WriteLine("Введено неверное значение");
            }
        }

        static void study()
        {
            try
            {
                Random rnd = new Random();
                int sum = 0;
                int n = 0;
                int[,] mas = new int[5, 8];
                Console.WriteLine("Количество студентов в каждой группе");
                for (int i = 0; i < mas.GetLength(0); i++)
                {
                    Console.Write($"{i + 1} курс:  ");
                    for (int j = 0; j < mas.GetLength(1); j++)
                    {
                        mas[i, j] = rnd.Next(15, 30);
                        Console.Write($"{mas[i, j]} ");
                    }
                    Console.WriteLine();
                }
                while (n <= 0 || n >= 6)
                {
                    Console.Write("Введите курс, для нахождения общего кол-ва студентов");
                    n = int.Parse(Console.ReadLine());
                    if (n <= 0 || n >= 6) Console.WriteLine("Такого курса нет");
                }
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    sum += mas[n - 1, j];
                }
                Console.WriteLine($"Количество студентов на {n} курсе - {sum}");
            }
            catch
            {
                Console.WriteLine("Введено неверное значение");
            }
        }

        static void train()
        {
            try
            {
                Random rnd = new Random();
                int vagon = 0;
                int[] notsell = new int[10];
                int[,] mas = new int[10, 36];
                for (int i = 0; i < mas.GetLength(0); i++)
                {
                    if (i == 9) Console.Write($"{i + 1} вагон ");
                    else
                        Console.Write($"{i + 1} вагон  ");
                    for (int j = 0; j < mas.GetLength(1); j++)
                    {
                        mas[i, j] = rnd.Next(0, 2);
                        Console.Write($"{mas[i, j]} ");
                        if (mas[i, j] == 0) notsell[i]++;
                    }
                    Console.WriteLine();
                    if (i == 9)
                    {
                        while (vagon <= 0 || vagon >= 11)
                        {
                            Console.WriteLine("Введите вагон, для определения кол-ва свободных мест");
                            vagon = int.Parse(Console.ReadLine());
                            if (vagon <= 0 || vagon >= 11) Console.WriteLine("Такого вагона нет");
                        }
                        Console.WriteLine($"Свободных мест в {vagon} вагоне - {notsell[vagon-1]}");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Введено неверное значение");
            }
        }

        static void Main(string[] args)
        {
            //Задания 1-3
            string[,] inform = info();
            inform = tabl(inform);
            vivod(inform);
            maxx(inform);
            //Задание 4
            graf(inform);
            //Задание 5
            Age();
            //Задание 12
            study();
            //Задание 14
            train();
































            Console.ReadKey();
        }
    }
}












