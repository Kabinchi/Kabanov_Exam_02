using System;

namespace FloydMethod
{
    public class Program
    {
        static int n;

        static void Main()
        {
            double[,] Shuya = {
                { 0, 0.94, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, 1.88, double.MaxValue, double.MaxValue, double.MaxValue },
                { 0.94, 0, 0.66, double.MaxValue, double.MaxValue, double.MaxValue, 1.2, double.MaxValue, double.MaxValue, double.MaxValue },
                { double.MaxValue, 0.66, 0, 1.04, double.MaxValue, 1.7, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue },
                { double.MaxValue, double.MaxValue, 1.04, 0, double.MaxValue, 0.77, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue },
                { double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, 0, 1.92, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue },
                { double.MaxValue, double.MaxValue, 1.7, 0.77, 1.92, 0, double.MaxValue, double.MaxValue, double.MaxValue, 1.52 },
                { 1.88, 1.2, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, 0, 0.53, double.MaxValue, double.MaxValue },
                { double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, 0.53, 0, 1.54, double.MaxValue },
                { double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, 1.54, 0, 0.86 },
                { double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, 1.52, double.MaxValue, double.MaxValue, 0.86, 0 }
            };

            n = Shuya.GetLength(0);

            double fuelResource = FuelValue();
            int start = ShuyaPoint("Введите начальную точку (1-10): ", n);
            int end = ShuyaPoint("Введите конечную точку (1-10): ", n);

            double[,] Paths = Floyd(Shuya);
            double minDistance = Paths[start - 1, end - 1];

            if (minDistance == double.MaxValue)
            {
                Console.WriteLine("Нет пути между указанными точками.");
            }
            else
            {
                double fuelUsed = (minDistance / 100) * fuelResource;
                Console.WriteLine($"Минимальное расстояние: {minDistance:F2} км");
                Console.WriteLine($"Расход топлива: {fuelUsed:F2} л");
            }
        }

        public static double FuelValue()
        {
            Console.Write("Введите расход топлива (л/100 км): ");
            while (true)
            {
                string input = Console.ReadLine();
                if (double.TryParse(input, out double fuelResource) && fuelResource > 0)
                {
                    return fuelResource;
                }
                Console.WriteLine("Расход топлива должен быть положительным числом.");
            }
        }

        public static int ShuyaPoint(string prompt, int n)
        {
            Console.Write(prompt);
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int point) && point >= 1 && point <= n)
                {
                    return point;
                }
                Console.WriteLine($"Введите число от 1 до {n}.");
            }
        }

        public static double? Test_FuelValue(string input)
        {
            if (double.TryParse(input, out double fuelResource) && fuelResource > 0)
            {
                return fuelResource;
            }
            return null;
        }

        public static int? Test_ShuyaPoint(string input, int n)
        {
            if (int.TryParse(input, out int point) && point >= 1 && point <= n)
            {
                return point;
            }
            return null;
        }

        private static double[,] Floyd(double[,] a)
        {
            double[,] d = new double[n, n];
            d = (double[,])a.Clone();
            for (int i = 1; i <= n; i++)
                for (int j = 0; j <= n - 1; j++)
                    for (int k = 0; k <= n - 1; k++)
                        if (d[j, k] > d[j, i - 1] + d[i - 1, k])
                            d[j, k] = d[j, i - 1] + d[i - 1, k];
            return d;
        }
    }
}
