using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace task1
{

    internal struct Employee
    {
        #region attributes/state
        int id;
        hiredate date;
        double salary;
        securitylevel seclevel;
        gender gender;
        #endregion

        #region ctor of employee
        public Employee(int _id, double _salary,hiredate d,securitylevel s,gender g)

        {
            id = _id;
            salary = _salary;
            date = d;
            seclevel = s;
            gender = g;
        }
        #endregion

        #region getters
        public int get_id()
        {
            return id;
        }

        public hiredate get_date()
        {
            return date;
        }

        public double get_salary()
        {
            return  salary;
        }

        public gender get_gender()
        {
            return gender;
        }

        public securitylevel get_securitylevel()
        {
            return seclevel;
        }

        #endregion

        #region setters
        public void set_id(int _id)
        {
            id = _id;
        }

        public void set_date(hiredate _d)
        {
            date = _d;
        }

        public void set_salary(double _salary)
        {
            salary = _salary;
        }

        public void set_gender(gender _g)
        {
            gender = _g;
        }

        public void set_seclevel(securitylevel _sec)
        {
            seclevel = _sec;
        }
        #endregion

        #region  methods
        public override string ToString()
        {
            return $"(id: {id},gender:{gender},hiredata: {date.get_day()}-{date.get_month()}-{date.get_year()},salary:{salary:c},securitylevel:{seclevel})";
        }

        #endregion


    }

}
