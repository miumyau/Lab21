using System;

namespace Lab21
{
    internal class Program
    {
        const int m = 3;
        const int n = 3;

        static int[,] garden = new int[m, n];

        static void Main(string[] args)
        {
            
            Random rnd = new Random();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    garden[i, j] = rnd.Next(0,25);
                    Console.Write(" {0:00} ", garden[i,j]);
                }
                Console.WriteLine();
            }

            

            ThreadStart threadStart=new ThreadStart(Gardener1);
            Thread thread = new Thread(threadStart);
            thread.Start();
            Gardener2();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    
                    Console.Write(" {0:00} ", garden[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void Gardener1() 
        {
            
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (garden[i, j] >= 0)
                    {
                        int delay = garden[i, j];
                        garden[i, j] = -1;
                        Thread.Sleep(delay);
                    }


                }
                

            }
        }

        static void Gardener2()
        {

            for (int j = n-1; j>=0; j--)
            {
                for (int i = m-1; i >= 0; i--)
                {

                    if (garden[i, j] >= 0)
                    {
                        int delay = garden[i, j];
                        garden[i, j] = -2;
                        Thread.Sleep(delay);
                    };


                }


            }
        }
    }
}
