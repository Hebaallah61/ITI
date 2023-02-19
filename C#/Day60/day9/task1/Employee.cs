using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class Employee
    { 
        public int EmployeeID { get; set; }
        public DateTime BirthDate
        {
            get; set;
            
        }
        public int VacationStock
        {
            get; set;
           
        }
        public Employee(int Id,DateTime bdate,int _VacationStock) { 
            EmployeeID= Id;
            BirthDate= bdate;
            VacationStock= _VacationStock;
        }

        public virtual void Resign()
        {
            LayOffCause Cause = LayOffCause.Resign;
            OnEmployeeLayOff(new EmployeeLayOffEventArgs(Cause));
        }
        public event

        EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;

        protected virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            EmployeeLayOff?.Invoke(this, e);
        }
        

        
        public bool RequestVacation(DateTime From, DateTime To)
        {
            DateTime ptime = new DateTime(To.Year, To.Month, To.Day - From.Day);
            int ptime_days = ptime.Day;

            if (VacationStock - ptime_days >= 0)
            {
                VacationStock = VacationStock - ptime_days;
                return true;
            }
            else
            {
                LayOffCause Cause = LayOffCause.VacationOut;
                OnEmployeeLayOff(new EmployeeLayOffEventArgs(Cause));
                return false;
            }
        }
        public void EndOfYearOperation()
        {
            DateTime date = new DateTime(2040, 1, 1);

            if (date.Year - this.BirthDate.Year >= 60)
            {
                LayOffCause Cause = LayOffCause.Retire;
                OnEmployeeLayOff(new EmployeeLayOffEventArgs(Cause));
            }
        }

        public virtual int AchievedTarget { get; set; }

        public virtual bool CheckTarget(int Quota)
        {
            return true;
        }

        public override string ToString()
        {
            return EmployeeID.ToString();
        }
    }
    public enum LayOffCause
    {
         VacationOut = 0, Retire = 1, Resign = 2, Sales_Target=4
    }
    public class EmployeeLayOffEventArgs : EventArgs
    {
        public LayOffCause Cause { get; set; }
        public EmployeeLayOffEventArgs(LayOffCause _Cause)
        {
            Cause = _Cause;
        }
    }

    class SalesPerson : Employee
    {


        public SalesPerson(int _EmployeeID, DateTime _BirthDate, int _VacationStock, int _AchievedTarget) : base(_EmployeeID, _BirthDate, _VacationStock)
        {
            AchievedTarget = _AchievedTarget;
        }

        public override int AchievedTarget { get; set; }
        public override bool CheckTarget(int Quota)
        {
            if (AchievedTarget < Quota)
            {
                LayOffCause Cause = LayOffCause.Sales_Target;
                OnEmployeeLayOff(new EmployeeLayOffEventArgs(Cause));
                return false;
            }
            return true;
        }
    }
    class BoardMember : Employee
    {
        public new int VacationStock { get; }
        public BoardMember(int _EmployeeID, DateTime _BirthDate, int _VacationStock) : base(_EmployeeID, _BirthDate, _VacationStock)
        {
            VacationStock = int.MaxValue;
        }
        public override void Resign()
        {
            LayOffCause Cause = LayOffCause.Resign;
            OnEmployeeLayOff(new EmployeeLayOffEventArgs(Cause));
        }
    }



}
