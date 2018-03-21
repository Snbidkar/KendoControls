using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeManagement.Models.ClassesEmp;
using System.Collections;

namespace EmployeeManagement.Controllers.EmpControllers
{
    public class CascadeListController : Controller
    {
        CountryList list = new CountryList();
        public ActionResult getCounty() {
           
            list.countryList = new List<CountryCity>();
            list.countryList.Add(new CountryCity { countryId = 1, CountryName = "India" });
            list.countryList.Add(new CountryCity { countryId = 2, CountryName = "Taiwan" });
            list.countryList.Add(new CountryCity { countryId = 3, CountryName = "USA" });
            ViewBag.country = list.countryList;
            var json = new { data = list.countryList };
            return Json(list.countryList,JsonRequestBehavior.AllowGet);
        }
       
        public JsonResult GetStates(int id)
        {
            list.stateList = new List<CountryCity>();
            list.stateList.Add(new CountryCity { stateId = 1, stateName = "Goa", countryId = 1 });
            list.stateList.Add(new CountryCity { stateId = 2, stateName = "Maharashtra", countryId = 1 });
            list.stateList.Add(new CountryCity { stateId = 3, stateName = "Mp", countryId = 1 });
            list.stateList.Add(new CountryCity { stateId = 4, stateName = "Kerala", countryId = 1 });
            list.stateList.Add(new CountryCity { stateId = 5, stateName = "Tamil Nadu", countryId = 1 });
            list.stateList.Add(new CountryCity { stateId = 6, stateName = "Karnataka", countryId = 1 });
            list.stateList.Add(new CountryCity { stateId = 7, stateName = "Taipi", countryId = 2 });
            list.stateList.Add(new CountryCity { stateId = 8, stateName = "Chiayi", countryId = 2 });
            list.stateList.Add(new CountryCity { stateId = 9, stateName = "Yilan", countryId = 2 });
            list.stateList.Add(new CountryCity { stateId = 10, stateName = "Hsinchu", countryId = 2 });

            var statesData = list.stateList.Where(e=>e.countryId==id).Select(x => new CountryCity { stateId = x.stateId, stateName = x.stateName });
            var json = new { data = statesData, JsonRequestBehavior.AllowGet };
                           return Json(json);
        }

        public JsonResult GetCity(int id)
        {
            list.cityList = new List<CountryCity>();
            list.cityList.Add(new CountryCity { cityId = 1, cityName = "Kurundwad", stateId = 2});
            list.cityList.Add(new CountryCity { cityId = 2, cityName = "Shirol", stateId = 2 });
            list.cityList.Add(new CountryCity { cityId = 3, cityName = "Kakkanad", stateId = 4 });
            list.cityList.Add(new CountryCity { cityId = 4, cityName = "Ernakulam", stateId = 4 });
            list.cityList.Add(new CountryCity { cityId = 5, cityName = "VishkhaPattanam", stateId = 5 });
            list.cityList.Add(new CountryCity { cityId = 6, cityName = "Tainan", stateId = 7 });
            var cityData = list.cityList.Where(e => e.stateId == id).Select(x => new CountryCity { cityId = x.cityId, cityName = x.cityName });
            var json = new { data = cityData, JsonRequestBehavior.AllowGet };
            return Json(json);
        }
 
    }
}
