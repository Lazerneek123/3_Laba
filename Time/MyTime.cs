using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time
{
    class MyTime
    {
        private int hour, minute, second;

        public MyTime(int h, int m, int s)
        {
            hour = h; minute = m; second = s;
        }        

        public int Hour
        {
            get
            {
                return hour;
            }
            set
            {
                if (value > 0 && value < 24)
                {
                    hour = value;
                    
                }
                else
                {
                    hour = value % 24;                    
                }
            }
        }
        

        public int Minute
        {
            get
            {
                return minute;
            }
            set
            {
                if (value > 0 && value < 60)
                {
                    minute = value;
                    
                }
                else
                {
                    Hour += value / 60;                    
                    minute = value % 60;                                       
                }
            }
        }

        public int Second
        {
            get
            {
                return second;
            }
            set
            {
                if (value > 0 && value < 60)
                {
                    second = value;                    
                }
                else
                {
                    Hour += value / 3600;                    
                    Minute += value / 60 % 60;
                    second = value % 60;
                }
            }
        }

        public override string ToString()
        {
            return string.Format("{0}:{1:00}:{2:00}", hour, minute, second);
        }


        public int TimeSinceMidnight(MyTime t)
        {
            return t.hour * 3600 + t.minute * 60 + t.second;
        }

        public MyTime TimeSinceMidnight(int t)
        {
            int secPerDay = 60 * 60 * 24;
            t = ((t % secPerDay) + secPerDay) % secPerDay;

            int h = t / 3600;
            int m = t / 60 % 60;
            int s = t % 60;
            return new MyTime(h, m, s);
        }

        public MyTime AddOneSecond(MyTime t)
        {
            return TimeSinceMidnight(TimeSinceMidnight(t) + 1);
        }

        public MyTime AddOneMinute(MyTime t)
        {
            return TimeSinceMidnight(TimeSinceMidnight(t) + 60);
        }

        public MyTime AddOneHour(MyTime t)
        {
            return TimeSinceMidnight(TimeSinceMidnight(t) + 3600);
        }

        public MyTime AddSeconds(MyTime t, int s)
        {
            return TimeSinceMidnight(TimeSinceMidnight(t) + s);
        }

        public int Difference(MyTime mt1, MyTime mt2)
        {
            return TimeSinceMidnight(mt1) - TimeSinceMidnight(mt2);
        }

        public string WhatLesson(MyTime mt)
        {
            MyTime timeX = new MyTime(8, 0, 0);
            if (Difference(mt, timeX) <= 0)
            {
                return "пари ще не почалися";
            }
            int[] breaksLenghtsMinutes = { 20, 20, 20, 20, 10 };
            
            for (int lessNumber = 0; lessNumber < breaksLenghtsMinutes.Length; lessNumber++)
            {
                timeX = AddSeconds(timeX, 80 * 60); // пара
                if (Difference(mt, timeX) < 0)
                {
                    return string.Format("{0}-а пара", lessNumber + 1);
                }

                if (lessNumber == breaksLenghtsMinutes.Length - 1)
                {
                    break;
                }

                timeX = AddSeconds(timeX, breaksLenghtsMinutes[lessNumber] * 60); // перерва
                if (Difference(mt, timeX) < 0)
                {
                    return string.Format("перерва між {0}-ю та {1}-ю парами", lessNumber + 1, lessNumber + 2);
                }
            }
            return "пари вже скінчилися";
        }

    }
}
