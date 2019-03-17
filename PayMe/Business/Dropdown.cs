using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Dropdown
    {
        public int ID { get; set; }

        public string Name { get; set; }
    }

    public class ManagerDropdown
    {
        public int fkManagerId { get; set; }

        public string Name { get; set; }

    }
    public class LocationDropdown
    {
        public int fkEmploymentLocationID { get; set; }

        public string Name { get; set; }

    }
    public class DepartmentDropdown
    {
        public int fkDepartmentID { get; set; }

        public string Name { get; set; }


    }
}
