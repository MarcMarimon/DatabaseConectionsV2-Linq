using DatabaseConections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseConnections
{
    public class DalJob
    {
        private EmployeesDataDataContext dataContext;

        public DalJob()
        {
            dataContext = new EmployeesDataDataContext();
        }

        public List<jobs> GetAll()
        {
            try
            {
                return dataContext.jobs.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
