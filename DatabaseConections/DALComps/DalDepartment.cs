using DatabaseConections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseConnections
{
    public class DalDepartment
    {
        private EmployeesDataDataContext dataContext;

        public DalDepartment()
        {
            dataContext = new EmployeesDataDataContext();
        }

        public List<departments> GetAll()
        {
            try
            {
                return dataContext.departments.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
