using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal struct hiredate
    {
        #region attributes/state
        int day;
        int month;
        int year;
        #endregion

        #region ctor
        public hiredate(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }
        #endregion

        #region getters

        public int get_day()
        {
            return day;
        }

        public int get_month()
        {
            return month;
        }

        public int get_year()
        {
            return year;
        }
        #endregion

        #region setters

        public void set_day(int _day)
        {
            day= _day;
        }

        public void set_month(int _month)
        {
            month= _month;
        }

        public void set_year(int _year)
        {
            year= _year;
        }

        #endregion



    }



}
