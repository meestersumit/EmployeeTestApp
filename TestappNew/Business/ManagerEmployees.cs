using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestappNew
{
    public class ManagerEmployees
    {
        int noofWorkingDays = 260;
        double noofvacationDays = 30;

        public int Work(int days)
        {
            if (days > 0 && days <= noofWorkingDays)
            {
                if ((noofWorkingDays - days) > noofvacationDays)
                    return -1;
                else
                    return (noofWorkingDays - days);

            }
            return -1;

        }
        public double TakeVacation(double vacationdays)
        {
            if (vacationdays >= 0 && vacationdays <= noofvacationDays)
            {
                if ((noofWorkingDays - vacationdays) > noofWorkingDays)
                    return -1;
                else
                    return (noofWorkingDays - vacationdays);
            }
            return -1;

        }
    }
}
