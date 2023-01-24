using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    internal class Duration
    {
        public int Hours { get; set; } = 0;
        public int Minutes { get; set; } = 0;
        public int Seconds { get; set; } = 0;

        public Duration(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public Duration() {
            Hours= 0;   
            Minutes= 0;
            Seconds= 0;
        }

        public Duration(int seconds)
        {
            Hours = seconds / 3600;
            Minutes = (seconds %3600) / 60;
            Seconds = (seconds % 3600) % 60;

        }



        public override string ToString()
        {
            if (Hours == 0)
            {
                return $"Minutes: {Minutes}, Seconds: {Seconds}";
            }
            return $"Hours: {Hours}, Minutes: {Minutes}, Seconds: {Seconds}";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            Duration d = (Duration)obj;
            if (this.Hours == d.Hours && this.Minutes == d.Minutes && this.Seconds == Seconds) return true;
            else return false;

            //return this.Hours==Hours && this.Minutes==Minutes && this.Seconds==Seconds;
        }

        public static Duration operator +(Duration d1, Duration d2)
        {
            return new Duration(d1.Hours+d2.Hours,d1.Minutes+d2.Minutes,d1.Seconds+d2.Seconds);
            
        }

        public static Duration operator +(Duration d1, int seconds)
        {
            return d1 + new Duration(seconds);
        }

        public static Duration operator +(int seconds, Duration d1)
        {
            return new Duration(seconds) + d1;
        }

        public static Duration operator ++(Duration d1)
        {
            return new Duration(d1.Hours, d1.Minutes + 1, d1.Seconds);
        }

        public static Duration operator --(Duration d1)
        {
            return new Duration(d1.Hours, d1.Minutes - 1, d1.Seconds);
        }

        public static Duration operator -(Duration d1)
        {
            return new Duration(d1.Hours * -1, d1.Minutes * -1, d1.Seconds * -1);
        }

        public static bool operator >(Duration d1, Duration d2)
        {
            return d1.Hours > d2.Hours && d1.Minutes > d2.Minutes && d1.Seconds > d2.Seconds;
        }

        public static bool operator <(Duration d1, Duration d2)
        {
            return d1.Hours < d2.Hours && d1.Minutes < d2.Minutes && d1.Seconds < d2.Seconds;
        }

        public static bool operator >=(Duration d1, Duration d2)
        {
            return d1.Equals(d2) || d1 > d2;
        }

        public static bool operator <=(Duration d1, Duration d2)
        {
            return d1.Equals(d2) || d1 < d2;
        }

        //public static explicit operator bool(Duration d)
        //{
        //    return d == null;
        //}

        public static bool operator true(Duration d)
        {
            return (d.Hours>=0)||(d.Minutes>=0)||(d.Seconds>=0);
        }


        public static bool operator false(Duration d)
        {
            return (d.Hours <= 0) && (d.Minutes <= 0) && (d.Seconds <= 0);
        }





        public static implicit operator DateTime(Duration d)
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, d.Hours, d.Minutes, d.Seconds);
        }



    }
}
