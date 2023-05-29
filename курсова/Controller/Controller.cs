using System;
using static курсова.Model.Model;
    class Controller
    {
        private double x_min;
        private double x_max;
        private double dx;
        public int count;
        public double q;
        private double[,] res;
        bool error;
    public Controller()
    {
        this.x_min = 0;
        this.x_max = 0;
        this.dx = 0;
        this.q = 0;
        this.error = true;
    }
    public Controller(string x_min_str, string x_max_str, string dx_str)
    {
        error = false;
        if (
            Double.TryParse(x_min_str, out x_min) &&
            Double.TryParse(x_max_str, out x_max) &&
            Double.TryParse(dx_str, out dx)
            )
        {
            // Генерація випадкового числа q
            this.q = rand();
        }
        // Виникла помилка при парсингу введених даних
        else error = true;
    }


        public bool SyntaxErrors()
        {
        // Повертає статус синтаксичних помилок
        return error;
        }
        public bool LogicErrors()
        {
        // Перевірка на логічні помилки
            if (error == false)
            {
                if (x_max - x_min > 0 && x_max - x_min >= dx && dx > 0)
                {
                    return error;
                }
                else
                {
                    error = true;
                    return error;
                }
            }
            else return error;
        }
        public bool Errors()
        {
            if (error == false)
            {
                //перевірка на помилки для q <= 0.5
                if (q <= 0.5)
                {
                    for (double i = x_min; i <= x_max; i += dx)
                    {
                        if (error != err_check1(q, i)) return true;
                    }
                }
                // Перевірка на помилки для q > 0.5
                else
                {
                        for (double i = x_min; i <= x_max; i += dx)
                        {
                            if (error != err_check2(q, i)) return true;
                        }
                    }
                }
            else
            {
                return error;
            }
            return false;
        }
        public double[,] Calculate()
        {
            // Обчислення кількості рядків для масиву res
            count = Convert.ToInt32((x_max - x_min) / dx) + 1;
            // Ініціалізація масиву res
            res = new double[count, 2];
            if (q <= 0.5)
            {
                int j = 0;
                // Обчислення результатів для q <= 0.5
                for (double i = x_min; i <= x_max; i += dx, ++j)
                {
                    res[j, 0] = i;
                    res[j, 1] = func1(q, i);
                }
            }
            else
            {
                int j = 0;
                // Обчислення результатів для q > 0.5
                for (double i = x_min; i <= x_max; i += dx, ++j)
                {
                    res[j, 0] = i;
                    res[j, 1] = func2(q, i);
                }
            }
            // Повертає масив з результатами обчислень
            return res;
        }
    }
