using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using DatabaseConections;

namespace DatabaseConnections
{
    public class DalEmployee
    {
        private EmployeesDataDataContext dataContext;

        public DalEmployee()
        {
            dataContext = new EmployeesDataDataContext();
        }

        public bool Insert(employees employee)
        {
            try
            {
                dataContext.employees.InsertOnSubmit(employee);
                dataContext.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<employees> GetAll()
        {
            try
            {
                return dataContext.employees.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public employees GetById(int employeeId)
        {
            try
            {
                return dataContext.employees.FirstOrDefault(e => e.employee_id == employeeId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(employees employee)
        {
            try
            {
                employees existingEmployee = dataContext.employees.FirstOrDefault(e => e.employee_id == employee.employee_id);
                if (existingEmployee != null)
                {
                    existingEmployee.first_name = employee.first_name;
                    existingEmployee.last_name = employee.last_name;
                    existingEmployee.email = employee.email;
                    existingEmployee.phone_number = employee.phone_number;
                    existingEmployee.hire_date = employee.hire_date;
                    existingEmployee.job_id = employee.job_id;
                    existingEmployee.salary = employee.salary;
                    existingEmployee.manager_id = employee.manager_id;
                    existingEmployee.department_id = employee.department_id;

                    dataContext.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
