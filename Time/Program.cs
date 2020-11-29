using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTime t = new MyTime(0, 0, 0);        // час (головний)
            t.Hour = 12;     // години
            t.Minute = 40;   // хвилини
            t.Second = 1;    // секунди

            MyTime mt1 = new MyTime(0, 0, 0);       // перший момент часу
            mt1.Hour = 13;
            mt1.Minute = 45;
            mt1.Second = 43;

            MyTime mt2 = new MyTime(0, 0, 0);     // другий момент часу
            mt2.Hour = 9;
            mt2.Minute = 14;
            mt2.Second = 21;

            Console.WriteLine("{0} - час", t);

            Console.WriteLine("{0}(с) - перевод часу в секунди", t.TimeSinceMidnight(t));

            Console.WriteLine("{0} - додає до часу одну секунду", t.AddOneSecond(t));

            Console.WriteLine("{0} - додає до часу одну хвилину", t.AddOneMinute(t));

            Console.WriteLine("{0} - додає до часу одну годину", t.AddOneHour(t));

            Console.WriteLine("Скільки секунд ви б хотіли додати?", t.AddOneHour(t));

            int s = Int32.Parse(Console.ReadLine());

            Console.WriteLine("{0} - додає до часу {1}-кількість секунд", t.AddSeconds(t, s), s);

            Console.WriteLine("Перший момент часу {0} - другий момент часу {1}", mt1, mt2);

            Console.WriteLine("{0} - різниця між цими моментами", t.TimeSinceMidnight(t.Difference(mt1, mt2)));

            Console.WriteLine("Введіть спершу години, потім з нового рядка хвилини і так само секунди!");

            int[] array = new int[3];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Int32.Parse(Console.ReadLine());
            }

            MyTime mt = new MyTime(0, 0, 0);
            mt.Hour = array[0];
            mt.Minute = array[1];
            mt.Second = array[2];

            Console.WriteLine("{0} - зараз {1}", mt, t.WhatLesson(mt));
            Console.ReadKey();
        }        
    }
}