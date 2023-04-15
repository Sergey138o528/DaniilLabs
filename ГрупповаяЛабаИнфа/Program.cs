using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba
{
    class Program
    {
        static void function(string[] args)
        {

            //Создание массива и его ининциализация: new char[100];
            char[] Memory = new char[100];
            for (int i = 0; i < Memory.Length; i++)
            {
                Memory[i] = (Char)3;
            }


            int MaxTime = 10;
            for (int Time = 0; Time < MaxTime; Time++)
            {
                //Нахождение начала и конца первого свободного места в памяти:
                int[] FirstsFreeSpots = new int[1] { 0 };
                int[] LastsFreeSpots = new int[1] { 100 };

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

                //Создание параметров текущей "задачи":
                Random rand = new Random();
                int Operation_Length = rand.Next(1, 31);
                int Operation_Time = rand.Next(1, 6);

                //Размещение текущей "задачи":
                for (int s = 0; s < FirstsFreeSpots.Length; s++)
                {
                    if ((Operation_Length) < (LastsFreeSpots[s] - FirstsFreeSpots[s]))
                    {
                        for (int b = FirstsFreeSpots[s]; b < FirstsFreeSpots[s] + Operation_Length; b++)
                        {
                            Memory[b] = (Char)(Time + 65);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Программа" + "'" + (Char)(Time + 65) + "'" + "слишком велика :( ");

                    }
                }
                Console.WriteLine("FirstFreeSpot    " + FirstsFreeSpots);
                Console.WriteLine("LastFreeSpot     " + LastsFreeSpots);
                Console.WriteLine("Operation_Length " + Operation_Length);
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
            }
        }
    }
}