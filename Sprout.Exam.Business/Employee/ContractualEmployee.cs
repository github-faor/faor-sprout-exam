using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Employee
{
    public class ContractualEmployee : Employee
    {
        public override decimal CalculatePay(decimal days)
        {
            decimal ratePerDay = 500.00m; //For Improvement: Move to Database
            return ratePerDay * days;
        }
    }
}
