using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba
{
    class ProgramTest
    {
        static void function(string[] args)
        {

            //Создание массива и его ининциализация "свободным местом":
            char[] Memory = new char[100];
            for (int i = 0; i < Memory.Length; i++)
            {
                Memory[i] = (Char)3;
            }

            int[] FirstsFreeSpots = new int[1] { 0 };
            int[] LastsFreeSpots = new int[1] { 100 };

            Random rand = new Random();
            int OperationLength;
            int OperationTime;
            Char OperationName;

            int[] CountingArray = new int[0];
            int Index;
            Char[] NamingArray = new Char[0];


            int MaxTime = 15;
            for (int Time = 0; Time < MaxTime; Time++)
            {
                //Нахождение начал и концов свободных мест в памяти:

                for (int s = 0; s < LastsFreeSpots.Length; s++)
                {
                    int a = 0;
                    while ((Memory[a] != (Char)3) && (a < Memory.Length))
                    {
                        a++;
                    }
                    {
                        FirstsFreeSpots[s] = a;
                        while ((Memory[a] != (Char)3) && (a < Memory.Length))
                        {
                            LastsFreeSpots[s] = a;
                        }
                        {
                            a++;
                        }
                    }
                }

                //Создание текущей "задачи":
                //1.Для размещения в памяти
                OperationLength = rand.Next(1, 30);
                OperationTime = rand.Next(1, 6);
                OperationName = (Char)(Time + 65);

                //2.Для удаления из памяти
                Array.Resize(ref CountingArray, CountingArray.Length + 1);
                CountingArray[CountingArray.Length - 1] = OperationTime;
                Array.Sort(CountingArray);
                Index = Array.FindIndex(CountingArray, i => i == OperationTime);

                Array.Resize(ref NamingArray, NamingArray.Length + 1);
                for (int i = NamingArray.Length - 1; i > Index; i--)
                {
                    NamingArray[i] = NamingArray[i - 1];
                }
                NamingArray[Index] = OperationName;


                //Размещение текущей "задачи":
                for (int s = 0; s < FirstsFreeSpots.Length; s++)
                {
                    if ((OperationLength) < (LastsFreeSpots[s] - FirstsFreeSpots[s]))
                    {
                        for (int b = FirstsFreeSpots[s]; b < FirstsFreeSpots[s] + OperationLength; b++)
                        {
                            Memory[b] = OperationName;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Программа" + "'" + (Char)(Time + 65) + "'" + "слишком велика :( ");

                    }
                }

                //Удаление отрабатовшей задачи
                for (int s = 0; s < LastsFreeSpots.Length; s++)
                {
                    if (CountingArray[s] == 0)
                    {
                        int a = 0;
                        while ((Memory[a] != NamingArray[s]) && (a < Memory.Length))
                        {
                            a++;
                        }
                        {
                            while ((Memory[a] != NamingArray[s]) && (a < Memory.Length))
                            {
                                Memory[a] = (Char)3;
                            }
                            {
                                a++;
                            }
                        }
                        //Удаление нуля и задачи в связанных массиах; уменьшение массиввов.
                        for (int i = 0; i > NamingArray.Length; i++)
                        {
                            NamingArray[i] = NamingArray[i + 1];
                            CountingArray[i] = CountingArray[i + 1];
                        }

                        Array.Resize(ref NamingArray, NamingArray.Length - 1);
                        Array.Resize(ref CountingArray, CountingArray.Length - 1);
                    }
                }

                Console.WriteLine("CountingArray.Length: " + CountingArray.Length);
                for (int i = 0; i < CountingArray.Length; i++)
                {
                    Console.WriteLine("CountingArray: " + CountingArray[i]);
                }

                //Уменьшение времени задач:
                for (int i = 0; i < CountingArray.Length; i++)
                {
                    CountingArray[i]--;
                }


                //Console.Write("FirstFreeSpot    "); for (int FS = 0; FS < FirstsFreeSpots.Length; FS++) { Console.WriteLine(FirstsFreeSpots[FS] + ", "); }
                //Console.Write("LastFreeSpot     "); for (int FS = 0; FS < LastsFreeSpots.Length; FS++) { Console.WriteLine(LastsFreeSpots[FS] + ", "); }
                //Console.WriteLine("Operation_Length " + OperationLength);
                Console.WriteLine(Memory);




            }




        }
    }
    //НУЖНО СДЕЛАТЬ:
    //Сделать           Удаление отработавшей "задачи": увеличиваю длину массивов FFS и LFS:{ Array.Resize(ref FirstsFreeSpots, FirstsFreeSpots.Length + 1) }, когда удаляю объект.
    //Расширить [++-]   Нахождение начала и конца для 1--n-ного свободного места. мб через вектор или массив
    //Сделать           Уплотнение памяти



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
    //Добавляю 1 к значению в таблицы символов, начиная с n-ного элемента   }


    //Добавялть в массив значение, сортировать массив, находить индекс, добавленного значения
    //Если последний не пустой, то увеличить. Если предпоследний пустой, то уменьшить [для связанной пары массивов]
}