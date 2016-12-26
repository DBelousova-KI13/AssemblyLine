using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyLine.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //вариант 7
            //int[] FirstManufacture = new[] { 1, 3, 2, 1, 3, 2, 2, 1 };
            //int[] SameManufacture  = new[] { 1, 3, 2, 1, 3, 2, 2, 1 };
            //int[] SecondMnufacture = new[] { 1, 2, 2, 3, 2, 1, 2, 2 };
            //int[] ThirdManufacture = new[] { 1, 1, 2, 2, 1, 3, 3, 1 };

            //вариант 2
            //int[] FirstManufacture = new[] { 1, 1, 2, 3, 3, 1, 1, 3 };
            //int[] SameManufacture  = new[] { 1, 1, 2, 3, 3, 1, 1, 3 };
            //int[] SecondMnufacture = new[] { 1, 2, 3, 3, 1, 2, 3, 1 };
            //int[] ThirdManufacture = new[] { 1, 2, 1, 2, 3, 3, 3, 1 };

            //вариант 4
            int[] FirstManufacture = new[] { 1, 2, 1, 2, 3, 3, 3, 1 };
            int[] SameManufacture  = new[] { 1, 2, 1, 2, 3, 3, 3, 1 };
            int[] SecondMnufacture = new[] { 1, 2, 3, 2, 3, 1, 1, 2 };
            int[] ThirdManufacture = new[] { 1, 2, 1, 2, 3, 3, 3, 1 }; // это не запускать

            //вариант 5
            //int[] FirstManufacture = new[] { 1, 2, 3, 2, 3, 1, 1, 2 };
            //int[] SameManufacture  = new[] { 1, 2, 3, 2, 3, 1, 1, 2 };
            //int[] SecondMnufacture = new[] { 1, 2, 1, 2, 3, 2, 2, 2 };
            //int[] ThirdManufacture = new[] { 1, 2, 1, 2, 3, 3, 3, 1 };


            System.Console.WriteLine("Первое изделие");
            for (int i = 0; i < FirstManufacture.Length; i++)
            {
                System.Console.WriteLine("Такт:{0} {1}й мастер работает над изделием", i, FirstManufacture[i]);
            }
            System.Console.WriteLine("Рассчитаем возможную стратегию для первого изделия");
            List<int> steps = new List<int>();
            List<int> strategy = new List<int>();
            for (int i = 0; i < FirstManufacture.Length; i++)
            {
                bool isImpact = true;
                for (int j = 0; j < SameManufacture.Length; j++)
                {
                    if ((i + j) < SameManufacture.Length)
                    {
                        if (FirstManufacture[((i + j) % 8)] != SameManufacture[j])
                        {
                            isImpact = false;
                        }
                        else
                        {
                            isImpact = true;
                            System.Console.WriteLine("В случае итерации {0} столкновение на {1} этапе", i, (i + j) % 8);
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }

                }
                if (!isImpact)
                {
                    int l = i;
                    if (steps.Count != 0)
                    {
                        l = i - steps.LastOrDefault();
                    }
                    steps.Add(i);
                    strategy.Add(l);
                    System.Console.WriteLine("на {0}-м такте можно начать работу со следующим изделием, латентность = {1}", i, l);

                }
            }
            if (strategy.Count == 0)
            {
                strategy.Add(0);
            }
            System.Console.WriteLine("Всего успехов {0}, минимальная латентность {1}", steps.Count, strategy.Min());

            System.Console.WriteLine("Рассчитаем возможную стратегию для первого и второго изделия");
            List<int> stepsDiff = new List<int>();
            List<int> strategy2 = new List<int>();
            for (int i = 0; i < FirstManufacture.Length; i++)
            {
                bool isImpact = true;
                for (int j = 0; j < SecondMnufacture.Length; j++)
                {
                    if ((i + j) < SecondMnufacture.Length)
                    {
                        if (FirstManufacture[((i + j) % 8)] != SecondMnufacture[j])
                        {
                            isImpact = false;
                        }
                        else
                        {
                            isImpact = true;
                            System.Console.WriteLine("В случае итерации {0} столкновение на {1} этапе", i, j);
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }


                }
                if (!isImpact)
                {
                    int l = i;
                    if (stepsDiff.Count != 0)
                    {
                        l = i - stepsDiff.LastOrDefault();
                    }
                    stepsDiff.Add(i);
                    strategy2.Add(l);
                    System.Console.WriteLine("на {0}-м такте можно начать работу со следующим изделием, латентность = {1}", i, l);
                }
            }
            if (strategy2.Count == 0)
            {
                strategy2.Add(0);
            }
            System.Console.WriteLine("Всего успехов {0}, минимальная латентность {1}", stepsDiff.Count, strategy2.Min());
            System.Console.ReadLine();
            System.Console.WriteLine("Рассчитаем возможную стратегию для первого и третьего изделия");
            List<int> stepsDiff3 = new List<int>();
            List<int> strategy3 = new List<int>();
            for (int i = 0; i < FirstManufacture.Length; i++)
            {
                bool isImpact = true;
                for (int j = 0; j < ThirdManufacture.Length; j++)
                {

                    if (FirstManufacture[((i + j) % 8)] != ThirdManufacture[j])
                    {
                        isImpact = false;
                    }
                    else
                    {
                        isImpact = true;
                        System.Console.WriteLine("В случае итерации {0} столкновение на {1} этапе", i, j);
                        break;
                    }


                }
                if (!isImpact)
                {
                    int l = i;
                    if (stepsDiff3.Count != 0)
                    {
                        l = i - stepsDiff3.LastOrDefault();
                    }
                    steps.Add(i);
                    strategy3.Add(l);
                    System.Console.WriteLine("на {0}-м такте можно начать работу со следующим изделием, латентность = {1}", i, l);
                }
            }
            System.Console.WriteLine("Всего успехов {0}, минимальная латентность {1}", stepsDiff3.Count, strategy3.Min());
            System.Console.ReadLine();
        }
    }
}
