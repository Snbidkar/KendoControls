using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models.ClassesEmp
{
    public class CountryList {
        public List<CountryCity> countryList { get; set; }
        public List<CountryCity> stateList { get; set; }
        public List<CountryCity> cityList { get; set; }
    }
    public class CountryCity
    {
       public int countryId { get; set; }
       public string CountryName { get; set; }
       public int stateId { get; set; }
       public string stateName { get; set; }
       public int cityId { get; set; }
       public string cityName { get; set; }
    }
}