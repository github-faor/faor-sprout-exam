using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Business.Employee;
using Sprout.Exam.Common.Enums;
using Sprout.Exam.DataAccess;
using Sprout.Exam.DataAccess.Interfaces;
using Sprout.Exam.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Services
{
    public class EmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        //private Employee.Employee _employee;

        //public EmployeeService()
        //{
        //    _employeeRepository = new EmployeeRepository(new dbContext);
        //    _employee = null;
        //}

        //public EmployeeService(AppDbContext appDbContext, EmployeeType empType)
        //{
        //    _employeeRepository = new EmployeeRepository(appDbContext);
        //    IEmployeeFactory employeeFactory = new EmployeeFactory();
        //    _employee = employeeFactory.Build(empType);
        //}

        public EmployeeService(AppDbContext appDbContext)
        {
            _employeeRepository = new EmployeeRepository(appDbContext);
            //_employee = null;
        }

        public List<EmployeeDto> GetEmployees()
        {
            var employees = _employeeRepository.GetEmployees()
                .Select(x => new EmployeeDto {
                    Birthdate = x.BirthDate.ToString("yyyy-MM-dd"),
                    FullName = x.FullName,
                    Id = x.Id,
                    Tin = x.TIN,
                    TypeId = x.EmployeeTypeId
            });

            return employees.ToList();
        }

        public EmployeeDto GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetEmployee(id);

            return new EmployeeDto() {
                Birthdate = employee.BirthDate.ToString("yyyy-MM-dd"),
                FullName = employee.FullName,
                Id = employee.Id,
                Tin = employee.TIN,
                TypeId = employee.EmployeeTypeId
            };
        }

        public EditEmployeeDto UpdateEmployee(EditEmployeeDto employeeDto)
        {
            var employee = new DataAccess.Employee() 
            {
                BirthDate = Convert.ToDateTime(employeeDto.Birthdate),
                FullName = employeeDto.FullName,
                Id = employeeDto.Id,
                TIN = employeeDto.Tin,
                EmployeeTypeId = employeeDto.TypeId
            };

            _employeeRepository.UpdateEmployee(employee);
            _employeeRepository.Save();

            return employeeDto;
        }

        public CreateEmployeeDto CreateEmployee(CreateEmployeeDto employeeDto)
        {
            var employee = new DataAccess.Employee()
            {
                BirthDate = Convert.ToDateTime(employeeDto.Birthdate),
                FullName = employeeDto.FullName,
                TIN = employeeDto.Tin,
                EmployeeTypeId = employeeDto.TypeId
            };

            _employeeRepository.InsertEmployee(employee);
            _employeeRepository.Save();

            return employeeDto;
        }

        public List<EmployeeDto> DeleteEmployee(int empId)
        {
           _employeeRepository.DeleteEmployee(empId);
            _employeeRepository.Save();

            return GetEmployees();
        }

        //public void Build(EmployeeType empType)
        //{
        //    IEmployeeFactory employeeFactory = new EmployeeFactory();
        //    _employee = employeeFactory.Build(empType);
        //}

        public decimal CalculateEmployeePay(int empId, decimal absentDays, decimal workedDays)
        {
            var employee = GetEmployeeById(empId);
            var emplType = (EmployeeType)employee.TypeId;
            decimal employeePay = 0.00m;

            IEmployeeFactory employeeFactory = new EmployeeFactory();
            var employeeBuild = employeeFactory.Build(emplType);

            switch (emplType)
            {
                case EmployeeType.Regular:
                    employeePay = employeeBuild.CalculatePay(absentDays);
                    break;
                case EmployeeType.Contractual:
                    employeePay = employeeBuild.CalculatePay(workedDays);
                    break;
                default:
                    employeePay = 0.00m;
                    break;
            }

            return employeePay;
        }
    }
}
