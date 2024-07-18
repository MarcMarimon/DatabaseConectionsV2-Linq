using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DatabaseConections
{
   
        public partial class employees
        {
            public override string ToString()
            {
                return $"{first_name} {last_name} -- {email}";
            }
        }


    public partial class jobs
    {
        public override string ToString()
        {
           return  $" {job_title} -- {min_salary} - {max_salary}";
        }
    }
    public partial class departments
    {
        public override string ToString()
        {
            return $"{department_name} -- {location_id}";
        }
    }

}
