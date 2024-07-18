using DatabaseConnections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConections
{
    internal class Servicios
    {
        private DalEmployee dalEmployee;
        private DalDepartment dalDepartment;
        private DalJob dalJob;

        public Servicios()
        {
            dalEmployee = new DalEmployee();
            dalDepartment = new DalDepartment();
            dalJob = new DalJob();
        }

        public List<employees> GetAllEmployees()
        {
            return  dalEmployee.GetAll();
        }

        public List <departments> GetAllDepartments()
        {
            return dalDepartment.GetAll();
        }
        public List<jobs> GetAllJobs()
        {
            return dalJob.GetAll();
        }
        public bool InsertEmployee(employees employee)
        {
            return dalEmployee.Insert(employee);
        }
        public employees GetEmployeeById(int employeeId)
        {
            return dalEmployee.GetById(employeeId);
        }

        public bool UpdateEmployee(employees employee)
        {
            return dalEmployee.Update(employee);
        }
    }
}
