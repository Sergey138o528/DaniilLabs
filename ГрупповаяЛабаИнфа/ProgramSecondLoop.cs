using System;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ГрупповаяЛабаИнфа.Logic;

namespace Laba
{
    #region Моя реализациия

    #endregion

    class ProgramSecondLoop
    {
        static void Main(string[] args)
        {
            #region Новая реализация

            var container = new Container(80);
            bool NeedNextStep = true;
            while (NeedNextStep)
            {
                container.ExecuteNextStep();

                Console.WriteLine("Нажми любую клавишу для продолжения");
                Console.ReadKey();
            }

            #endregion

            Console.ReadKey();

            #region Старая реализация

            char EmptiSimbol = '_';

            //Создание массива и его ининциализация "свободным местом":
            char[] Memory = new char[100];
            for (int i = 0; i < Memory.Length; i++)
            {
                Memory[i] = EmptiSimbol;
            }

            Random Rand = new Random();

            int OperationLength;
            int[] OperationsTimes = new int[0];
            char[] OperationsNames = new char[0];
            int Index;

            int MaxTime = 10;
            for (int Time = 0; Time < MaxTime; Time++)
            {
                //Нахождение начал и концов свободных мест в памяти:
                int[] FirstsFreeSpots = new int[1] { 0 };
                int[] LastsFreeSpots = new int[1] { 100 };

                for (int s = 0; s < LastsFreeSpots.Length; s++)
                {
                    int a = 0;
                    while ((Memory[a] != EmptiSimbol) && (a < Memory.Length))
                    {
                        a++;
                    }
                    {
                        FirstsFreeSpots[s] = a;
                        while ((Memory[a] != EmptiSimbol) && (a < Memory.Length))
                        {
                            LastsFreeSpots[s] = a;
                        }
                        {
                            a++;
                        }
                    }
                }

                Array.Resize(ref OperationsTimes, OperationsTimes.Length + 1);
                Array.Resize(ref OperationsNames, OperationsNames.Length + 1);

                //Создание параметров текущей "задачи":
                OperationLength = Rand.Next(1, 31);

                OperationsTimes[OperationsTimes.Length - 1] = Rand.Next(1, 6);
                Array.Sort(OperationsTimes);
                Index = Array.FindIndex(OperationsTimes, i => i == OperationsTimes[OperationsTimes.Length - 1]);

                OperationsNames[OperationsNames.Length - 1] = (Char)(Time + 65);
                for (int i = OperationsNames.Length - 1; i > Index; i--)
                {
                    OperationsNames[i] = OperationsNames[i - 1];
                }
                OperationsNames[Index] = OperationsNames[OperationsNames.Length - 1];


                //Размещение текущей "задачи":
                for (int s = 0; s < FirstsFreeSpots.Length; s++)
                {
                    if ((OperationLength) < (LastsFreeSpots[s] - FirstsFreeSpots[s]))
                    {
                        for (int b = FirstsFreeSpots[s]; b < FirstsFreeSpots[s] + OperationLength; b++)
                        {
                            Memory[b] = OperationsNames[OperationsNames.Length - 1];
                        }
                    }
                    else
                    {
                        Console.WriteLine("Программа" + "'" + OperationsNames[OperationsNames.Length - 1] + "'" + "слишком велика :( ");

                    }
                }

                for (int s = 0; s < LastsFreeSpots.Length; s++)
                {
                    if (OperationsTimes[s] == 0)
                    {
                        int a = 0;
                        while ((Memory[a] != OperationsNames[s]) && (a < Memory.Length))
                        {
                            a++;
                        }
                        {
                            while ((Memory[a] != OperationsNames[s]) && (a < Memory.Length))
                            {
                                Memory[a] = (Char)3;
                            }
                            {
                                a++;
                            }
                        }
                        //Удаление нуля и задачи в связанных массиах; уменьшение массиввов.
                        for (int i = 0; i > OperationsNames.Length; i++)
                        {
                            OperationsNames[i] = OperationsNames[i + 1];
                            OperationsTimes[i] = OperationsTimes[i + 1];
                        }

                        Array.Resize(ref OperationsNames, OperationsNames.Length - 1);
                        Array.Resize(ref OperationsTimes, OperationsTimes.Length - 1);
                    }
                }

                Console.WriteLine("OperationsTimes.Length: " + OperationsTimes.Length);
                for (int i = 0; i < OperationsTimes.Length; i++)
                {
                    Console.WriteLine(OperationsNames[i] + ": " + OperationsTimes[i]);
                }

                //Уменьшение времени задач:
                for (int i = 0; i < OperationsTimes.Length; i++)
                {
                    OperationsTimes[i]--;
                }

                //Console.WriteLine("FirstFreeSpot    " + FirstsFreeSpots);
                //Console.WriteLine("LastFreeSpot     " + LastsFreeSpots);
                Console.WriteLine("OperationLength " + OperationLength);
                Console.WriteLine(Memory);




                //НУЖНО СДЕЛАТЬ:
                //Сделать       Удаление отработавшей "задачи":
                //Расширить     Нахождение начала и конца для 1--n-ного свободного места. мб через вектор или массив
                //Сделать       Уплотнение памяти



                //Если время равно значению n-нного элемента масива "отработачных времен", n-нную задачу удаляю, удаляю и n-ый элемент
                //Путем цикла:


                //int [] FirstsFreeSpots = new int
                //int [] LastsFreeSpots = new int


                //while ((Memory[a] != *удаялемая буква*) && (a < Memory.Length))
                //{
                //    a++;
                //}
                //{
                //    for ()
                //    
                //    while ((Memory[a] != (Char)3) && (a < Memory.Length))
                //    {
                //        LastsFreeSpots = a;
                //    }
                //    {
                //        a++;
                //    }
                //}

                //n= пока *буква*; Memory[n]=(Char)3))
                //Сдвигаю все последующие элементы масива "отработачных времен" на 1 влево
                //Добавляю 1 к значению в таблицы символов, начиная с n-ного элемента            

                #endregion
            }
        }
    }
}