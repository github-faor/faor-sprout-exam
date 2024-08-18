using Sprout.Exam.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Employee
{
    public class EmployeeFactory : IEmployeeFactory
    {
        public Employee Build(EmployeeType empType)
        {
            switch (empType)
            {
                case EmployeeType.Regular:
                    return new RegularEmployee();
                case EmployeeType.Contractual:
                    return new ContractualEmployee();
                default:
                    return null;

            }
        }
    }
}
