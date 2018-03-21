using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DTO
{
    public class DtoList
    {
        public List<DTOClass> Emplist { get; set; }
        public List<LookupDTO> DesnList { get; set; }
        public List<LookupDTO> DeptList { get; set; }
        public List<DTOClass> SupervisorList { get; set; }

    }
    public class LookupDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class DTOClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DesgnationId { get; set; }
        public string Designation { get; set; }
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
        public double Experience { get; set; }

        public string Skills { get; set; }

        public string EmailId { get; set; }

        public string ContactNo { get; set; }

        public int? SupervisorId { get; set; }
        public string Supervisor { get; set; }
        public Nullable<DateTime> DateOfBirth { get; set; }

        public string Address { get; set; }
        public string InsertedBy { get; set; }
        public Nullable<DateTime> InsertedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }
    }
}
