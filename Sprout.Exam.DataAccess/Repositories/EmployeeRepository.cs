using Microsoft.EntityFrameworkCore;
using Sprout.Exam.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {
        private AppDbContext _empContext;

        public EmployeeRepository(AppDbContext empContext)
        {
            this._empContext = empContext;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _empContext.Employee.ToList();
        }

        public Employee GetEmployee(int employeeId)
        {
            return _empContext.Employee.Find(employeeId);
        }

        public void InsertEmployee(Employee employee)
        {
            _empContext.Employee.Add(employee);
        }

        public void DeleteEmployee(int employeeId)
        {
            Employee employee = _empContext.Employee.Find(employeeId);
            _empContext.Employee.Remove(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            _empContext.Entry(employee).State = EntityState.Modified;
        }

        public void Save()
        {
            _empContext.SaveChanges();
        }

        //Dispose
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _empContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
