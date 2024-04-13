using CalcLibrary;
using System;
using System.Windows;
using System.Windows.Controls;

namespace WPFProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_ClickCCConvert(object sender, RoutedEventArgs e)
        {
            if (Double.TryParse(textLabel.Text, out double numValue))
            {
                tb2.Text = $"DEC: {textLabel.Text}";
                string text = textLabel.Text;
                double text1 = Convert.ToDouble(text);
                string zel;
                double text2;
                text2 = text1 - Math.Truncate(text1);
                double[] asd;
                string drob;
                try
                {
                    zel = Convert.ToString(Convert.ToInt32(Math.Truncate(text1)), 2);
                    if (text2 != 0)
                    {
                        asd = new double[10];
                        asd[0] = text2;
                        drob = "";
                        for (int k = 1; k < 10; k++)
                        {
                            asd[k] = (2 * asd[k - 1]) - Math.Truncate(asd[k - 1] * 2);
                            int bin = Convert.ToInt32(Math.Truncate(asd[k - 1] * 2));
                            drob += bin;
                        }
                        drob = drob.TrimEnd('0');
                        tb4.Text = $"BIN: {zel + "," + drob}";
                    }
                    else tb4.Text = $"BIN: {zel}";
                }
                catch
                {

                }
                try
                {
                    zel = Convert.ToString(Convert.ToInt32(Math.Truncate(text1)), 8);
                    if (text2 != 0)
                    {
                        asd = new double[10];
                        asd[0] = text2;
                        drob = "";
                        for (int k = 1; k < 10; k++)
                        {
                            asd[k] = (8 * asd[k - 1]) - Math.Truncate(asd[k - 1] * 8);
                            double oct = Math.Truncate(asd[k - 1] * 8);
                            drob += oct;
                        }
                        drob = drob.TrimEnd('0');
                        tb3.Text = $"OCT: {zel + "," + drob}";
                    }
                    else tb3.Text = $"OCT: {zel}";
                }
                catch
                {

                }
                try
                {
                    zel = Convert.ToString(Convert.ToInt32(Math.Truncate(text1)), 16);
                    if (text2 != 0)
                    {
                        asd = new double[10];
                        asd[0] = text2;
                        drob = "";
                        for (int k = 1; k < 10; k++)
                        {
                            asd[k] = (16 * asd[k - 1]) - Math.Truncate(asd[k - 1] * 16);
                            string hex = Convert.ToString(Math.Truncate(asd[k - 1] * 16));
                            int ze = Convert.ToInt32(hex);
                            hex = ze.ToString();
                            switch (ze)
                            {
                                case 10: hex = "A"; break;
                                case 11: hex = "B"; break;
                                case 12: hex = "C"; break;
                                case 13: hex = "D"; break;
                                case 14: hex = "E"; break;
                                case 15: hex = "F"; break;
                                default: break;
                            }
                            drob += hex;
                        }
                        drob = drob.TrimEnd('0');
                        tb1.Text = $"HEX: {zel.ToUpper() + "," + drob.ToUpper()}";
                    }
                    else tb1.Text = $"HEX: {zel.ToUpper()}";
                }
                catch
                {

                }
            }
        }

        //Нахождение e в степени х
        private void Button_ClickEX(object sender, RoutedEventArgs e)
        {
            textLabel.Text = Calc.Ex(textLabel.Text);
        }

        //Нахождение tg
        private void Button_ClickTG(object sender, RoutedEventArgs e)
        {
            textLabel.Text = Calc.Tg(textLabel.Text);
        }

        //Нахождение sin
        private void Button_ClickSIN(object sender, RoutedEventArgs e)
        {
            textLabel.Text = Calc.Sin(textLabel.Text);
        }

        //Нахождение cos
        private void Button_ClickCOS(object sender, RoutedEventArgs e)
        {
            textLabel.Text = Calc.Cos(textLabel.Text);
        }

        //Нахождение квадрата
        private void Button_ClickSQR(object sender, RoutedEventArgs e)
        {
            textLabel.Text = Calc.SQR(textLabel.Text);
        }

        //Нахождение корня
        private void Button_ClickSQRT(object sender, RoutedEventArgs e)
        {
            textLabel.Text = Calc.SQRT(textLabel.Text);
        }
        //Операция +, -
        private void Button_ClickNegative(object sender, RoutedEventArgs e)
        {
            textLabel.Text = Calc.Negative(textLabel.Text);
        }

        //Нахождение факториала числа
        private void Button_ClickFactorial(object sender, RoutedEventArgs e)
        {
            textLabel.Text = Calc.Factorial(textLabel.Text);
        }
        bool symbol = false;
        //Добавление символом в строке(0..9, +, -, *, /, e, ПИ, знак запятой)
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;
            if (textLabel.Text == "0")
            {
                if (str == "π")
                    textLabel.Text = Math.PI.ToString();
                else if (str == "e")
                    textLabel.Text = Math.E.ToString();
                else if (str == ",")
                    textLabel.Text += ",";
                else if (str == "0" || str == "1" || str == "2" || str == "3" || str == "4" || str == "5" || str == "6" || str == "7" || str == "8" || str == "9")
                {
                    textLabel.Text = str;
                    symbol = true;
                }
                else
                {
                    textLabel.Text = str;
                    symbol = false;
                }
            }
            else if (textLabel.Text.Length < 45)
            {
                if (str == "π")
                    textLabel.Text += Math.PI;
                else if (str == "e")
                    textLabel.Text += Math.E;
                else if (str == "0" || str == "1" || str == "2" || str == "3" || str == "4" || str == "5" || str == "6" || str == "7" || str == "8" || str == "9")
                {
                    textLabel.Text += str;
                    symbol = true;
                }
                else if (symbol)
                {
                    textLabel.Text += str;
                    symbol = false;
                }
            }
            
        }
        
        //Стереть всё с поля
        private void Button_ClickClear(object sender, RoutedEventArgs e)
        {
            textLabel.Text = "0";
            tb1.Text = "HEX: 0";
            tb2.Text = "DEC: 0";
            tb3.Text = "OCT: 0";
            tb4.Text = "BIN: 0";
        }

        //Удаление последнего символа
        private void Button_ClickCancel(object sender, RoutedEventArgs e)
        {
            if (textLabel.Text != "0")
            {
                string temp = "";
                for (int i = 0; i < textLabel.Text.Length - 1; i++)
                    temp += textLabel.Text[i];
                if (temp == "")
                    textLabel.Text = "0";
                else
                    textLabel.Text = temp;
            }
        }

        //подсчёт выражения
        private void Button_ClickGetRez(object sender, RoutedEventArgs e)
        {
            textLabel.Text = Calc.DoOperation(textLabel.Text);
        }

        //Нахождение выражения 1/x
        private void Button_Click1DELx(object sender, RoutedEventArgs e)
        {
            textLabel.Text = Calc.DelX(textLabel.Text);
        }
    }
}
