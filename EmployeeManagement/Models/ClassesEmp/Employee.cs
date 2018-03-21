using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models.ClassesEmp
{

    //main class to pass view 
    public class EmpModelList
    {
        public List<CountryCity> countryList { get; set; }
        public List<CountryCity> stateList { get; set; }
        public List<CountryCity> cityList { get; set; }

        public List<Employee> Emplist { get; set; }
        public List<LookupData> DesnList { get; set; }
        public List<LookupData> DeptList { get; set; }
        public List<Employee> SupervisorList { get; set; }
       
        public Employee Emp { get; set; }
        public LookupData LData;

        public EmpModelList()
        {
            Emp = new Employee();
            LData = new LookupData();
        }

    }
    public class LookupData
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Employee
    {
      
        public int Id { get; set; }

        [Required (ErrorMessage ="Please Enter a Name.....")]
        [RegularExpression("^[a-zA-Z ]*$",ErrorMessage="only characters.")]
        public string Name { get; set; }
        public int DesgnationId { get; set; }

        [Required(ErrorMessage = "Designation required")]
        public string Designation { get; set; }
      
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Select Department")]
        public string Department { get; set; }
        [Required(ErrorMessage = "Select Gender")]
        public string Gender { get; set; }
        [Required (ErrorMessage = "Please Enter a experience.....")]
        public double Experience { get; set; }
        [Required(ErrorMessage = "Experience required")]
        public string Skills { get; set; }
        [Required(ErrorMessage = "Email Id required")]
        [RegularExpression("[A-Za-z0-9_%#$]+@[A-Za-z0-9]+.[A-Za-z]{2,3}", ErrorMessage = "Invalid Email Id")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Phone No required")]
        [MaxLength(10)]
        [MinLength(10)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Number Must Be 10 Digit")]
        public string ContactNo { get; set; }
      
        public int? SupervisorId { get; set; }
        [Required(ErrorMessage = "Select Supervisor..")]
        public string Supervisor { get; set; }
        [Required(ErrorMessage = "select Date Of Birth..")]
        public Nullable<DateTime> DateOfBirth { get; set; }
        [Required(ErrorMessage = "Address is required.....")]
        public string Address { get; set; }
        public string InsertedBy { get; set; }
        public Nullable<DateTime> InsertedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }

    }
}

     