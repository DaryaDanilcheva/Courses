using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДЗ1
{
    class Program
    {
        static void Main()
        {
            Fill();
            string player = "X";
            string a = "";
            while ((a = Winner()) == stand)
            {
                PlayerAction(player);
                if (Winner() == stand)
                    player = player == "X" ? "O" : "X";

                //PlayerAction("O");
            }
            Console.WriteLine("Победил игрок, ходящий знаком" + a);

            Console.ReadKey();
        }

        static int n;
        static string[,] pole;
        static string stand = "z";

        static void Fill()
        {
            string x;
            Console.WriteLine("Введите размерность поля");
            x = Console.ReadLine();
            try
            {
                n = Convert.ToInt32(x);
                pole = new string[n,n];
                for (int i=0;i<n;i++)
                {
                    for (int j=0;j<n;j++)
                    {
                        pole[i, j] = stand;
                        Console.Write(pole[i,j]);
                    }
                    Console.Write("\n");
                }
            }
            catch
            {
                Console.WriteLine("Введено недопустимое значение");
                Fill();
            }
        }

        static void PlayerAction(string simb)
        {
            string x1;
            string y1;
            int x=n+1;
            int y=n+1;
            try
            {
                Console.WriteLine("Введите координату Х");
                x1 = Console.ReadLine();
                x = Convert.ToInt32(x1);
                Console.WriteLine("Введите координату У");
                y1 = Console.ReadLine();
                y = Convert.ToInt32(y1);
            }
            catch
            {
                Console.WriteLine("Введено недопустимое значение");
            }

            if (x < n && y < n)
            {
                if (pole[x, y] != "X" && pole[x, y] != "O")
                {
                    pole[x, y] = simb;

                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            Console.Write(pole[i, j]);
                        }
                        Console.WriteLine("\n");
                    }
                }
                else
                {
                    Console.WriteLine("Данная ячейка занята");
                    PlayerAction(simb);
                }
            }
            else
            {
                Console.WriteLine("Число должно быть в диапазоне от 0 до {0}", n - 1);
                PlayerAction(simb);
            }
        }

        static string Winner()
        {
            for (int i=0;i<n;i++)
            {
                if(pole[i,0]!=stand)
                {
                    for (int j=1;j<n;j++)
                    {
                        if (pole[i,0]==pole[i,j])
                        {
                            if (j == n - 1)
                                return pole[i, j];
                        }
                        else
                        {
                            break;
                        }  
                            
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (pole[0,i] != stand)
                {
                    for (int j = 1; j < n; j++)
                    {
                        if (pole[0,i] == pole[j,i])
                        {
                            if (j == n - 1)
                                return pole[j,i];
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            
                for (int i = 0; i < n - 1; i++)
                {
                    if (pole[0, 0] != stand)
                    {
                        if (pole[i, i] == pole[i + 1, i + 1])
                        {
                            if (i == n - 2)
                                return pole[i, i];
                        }
                        else
                        {
                            break;
                        }
                    }
                }

            for (int i = 0; i < n - 1; i++)
            {
                if (pole[0, n-1] != stand)
                {
                    if (pole[i, n-i-1] == pole[i+1, n-i-2])
                    {
                        if (i == n-2)
                            return pole[i, n-1-i];
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return stand;
        }
    }
}
            