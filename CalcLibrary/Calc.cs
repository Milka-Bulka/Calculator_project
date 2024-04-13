using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CalcLibrary
{
    public delegate T OperationDelegate<T>(T x, T y);
    public static class Calc
    {
        /// <summary>
        /// Получение результата бинарной операции
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string DoOperation(string s)
        {
            try
            { 
                //получение операции
                string operation = GetOperation(s);

                //если двоичная арифметика - вызов библиотеки Bcalc
                if (operation == "&" || operation == "^" || operation == "|")
                {
                    Assembly SampleAssembly = Assembly.LoadFrom("BinCalc.dll");
                    Type[] types = SampleAssembly.GetTypes();
                    MethodInfo method = types[0].GetMethods()[0];
                    object obj = Activator.CreateInstance(types[0]);
                    return (string)method.Invoke(obj, new object[] { s });
                }
                else
                {
                    //получение операндов
                    string[] operands = GetOperands(s);
                    //получение ответа
                    return DoubleOperation[operation](Convert.ToDouble(operands[0]), Convert.ToDouble(operands[1])).ToString();
                }
            }
            catch
            {
                return "0";
            }
        }

        /// <summary>
        /// получение операндов
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string[] GetOperands(string s)
        {
            //флаг первого отрицательного числа
            bool flag = false;
            if (s[0] == '-')
                flag = true;
            string pattern = @"[^\d,\.]";
            Regex rgx = new Regex(pattern);
            MatchCollection mc = rgx.Matches(s);
            List<string> lm = new List<string>();
            foreach (Match m in mc)
                lm.Add(m.Value);

            //парсим выражение
            string[] operands = s.Split(lm.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            if (flag)
                operands[0] = (Convert.ToDouble(operands[0]) * (-1)).ToString();
            return operands;
        }

        /// <summary>
        /// получение операции
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string GetOperation(string s)
        {
            //с конца строки идёт до операции и возвращаем её
            for (int i = s.Length - 1; i > 0; i--)
                if (s[i] == '-' || s[i] == '+' || s[i] == '*' || s[i] == '/' || s[i] == '%' || s[i] == '÷' || s[i] == '$' || s[i] == '&' || s[i] == '^' || s[i] == '|')
                    return s[i].ToString();
            return "";
        }

        /// <summary>
        /// Словарь
        /// </summary>
        public static Dictionary<string, OperationDelegate<double>> 
        DoubleOperation = new Dictionary<string, OperationDelegate<double>>
        {
            { "+", (x, y)=>x + y },
            { "-", (x, y)=>x - y },
            { "*", (x, y)=>x * y },
            { "/", (x, y)=>x / y },
            { "%", (x, y)=>x % y },
            { "÷", (x, y)=>(int)(x / y) },
            { "$", (x, y)=>Math.Pow(x,y) }
        };

        /// <summary>
        /// Нахождение факториала
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Factorial(string s)
        {
            try
            {
                long number = Convert.ToInt64(s);
                if (number < 0)
                    return "0";
                long sum = 1;
                for (long i = 2; i <= number; i++)
                    sum *= i;
                return sum.ToString();
            }
            catch
            {
                return "0";
            }
        }

        /// <summary>
        /// Нахождение +, -
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Negative(string s)
        {
            try
            {
                double number = Convert.ToDouble(s);
                number *= (-1);
                return number.ToString();
            }
            catch
            {
                return "0";
            }
        }

        /// <summary>
        /// Нахождение корня
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string SQRT(string s)
        {
            try
            {
                double number = Convert.ToDouble(s);
                if (number >= 0)
                    number = Math.Sqrt(number);
                else
                    number = 0;
                return number.ToString();
            }
            catch
            {
                return "0";
            }
        }

        /// <summary>
        /// Нахождение квадрата
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string SQR(string s)
        {
            try
            {
                double number = Convert.ToDouble(s);
                number *= number;
                return number.ToString();
            }
            catch
            {
                return "0";
            }
        }

        /// <summary>
        /// Нахождение cos
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Cos(string s)
        {
            try
            {
                double number = Convert.ToDouble(s);
                double cos = Math.Cos(number);
                return cos.ToString();
            }
            catch
            {
                return "0";
            }
        }

        /// <summary>
        /// Нахождение sin
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Sin(string s)
        {
            try
            {
                double number = Convert.ToDouble(s);
                double sin = Math.Sin(number);
                return sin.ToString();
            }
            catch
            {
                return "0";
            }
        }

        /// <summary>
        /// Нахождение tg
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Tg(string s)
        {
            try
            {
                double number = Convert.ToDouble(s);
                double tg = Math.Tan(number);
                return tg.ToString();
            }
            catch
            {
                return "0";
            }
        }

        /// <summary>
        /// Нахождение e в степени х
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Ex(string s)
        {
            try
            {
                double number = Convert.ToDouble(s);
                double ex = Math.Pow(Math.E, number);
                return ex.ToString();
            }
            catch
            {
                return "0";
            }
        }

        /// <summary>
        /// Нахождение 1/x
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string DelX (string s)
        {
            try
            {
                double number = Convert.ToDouble(s);
                number = 1/ number;
                return number.ToString();
            }
            catch
            {
                return "0";
            }
        }
    }
}
