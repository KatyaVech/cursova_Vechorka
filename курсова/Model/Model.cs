using System;
using static System.Math;

namespace курсова.Model
{
    static class Model
    {
        public static double rand()
        {
            // Генерація випадкового числа від 0 до 1
            Random rand = new Random();
            return (double)rand.Next(100) / 100;
        }
        public static double func1(double q, double x)
        {
            // Обчислення значення функції для q <= 0.5
            return Log(Cos(q / x));
        }
        public static double func2(double q, double x)
        {
            // Обчислення значення функції для q > 0.5
            return Sqrt(Log(q * x));
        }
        public static bool err_check1(double q, double x)
        {
            // Перевірка на помилки для q <= 0.5
            if (Cos(q / x) > 0) return false;
            else return true;
        }
        public static bool err_check2(double q, double x)
        {
            // Перевірка на помилки для q > 0.5
            if (q * x > 0 && Log(q * x) >= 0) return false;
            else return true;
        }

    }
}
