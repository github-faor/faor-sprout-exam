using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Employee
{
    public class RegularEmployee : Employee
    {
        public override decimal CalculatePay(decimal days)
        {
            decimal monthlySalary = 20000.00m; //For Improvement: Move to Database
            decimal finalMonthlySalary = monthlySalary - ((monthlySalary / 22.00m) * days) - (monthlySalary * .12m);
            //decimal finalMonthlySalary = payDeduction - (payDeduction * .12m);

            return finalMonthlySalary;
        }
    }
}
