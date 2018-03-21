using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO;
using BLL;
using Entity;
using DAL;
using EmployeeManagement.Models.ClassesEmp;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Kendo.Mvc;
using Kendo.Mvc.Infrastructure;
using System.Linq.Expressions;


namespace EmployeeManagement.Controllers.EmpControllers
{
    public class EmployeeController : Controller
    {
        public ActionResult MainPage()
        {
            return View();
        }
        public ActionResult OnPageLoad()
        {
            try
            {
                EmpModelList mainObj = new EmpModelList();
                mainObj.DesnList = new List<LookupData>();
                mainObj.DeptList = new List<LookupData>();
                mainObj.SupervisorList = new List<Employee>();
               
                DtoList list = new DtoList();
                list.DesnList = new List<LookupDTO>();
                list.DeptList = new List<LookupDTO>();
               // list.SupervisorList = new List<DTOClass>();

                BLLClass bllObj = new BLLClass();
                list = bllObj.GetDtoData();

                foreach (var data in list.DesnList)
                {
                    LookupData desgObj = new LookupData()
                    {
                        Id = data.Id,
                        Name = data.Name
                    };
                    mainObj.DesnList.Add(desgObj);

                }

                foreach (var data in list.DeptList)
                {
                    LookupData deptObj = new LookupData()
                    {
                        Id = data.Id,
                        Name = data.Name
                    };

                    mainObj.DeptList.Add(deptObj);

                }

               
                //foreach (var data in list.SupervisorList)
                //{
                //    Employee superObj = new Employee()
                //    {
                //        Id = data.Id,
                //        Supervisor = data.Supervisor
                //    };

                //    mainObj.SupervisorList.Add(superObj);

                //}
                ViewBag.dept = mainObj.DeptList;

                return View(mainObj);
            }
            catch (Exception exp)
            {
                ViewBag.Error = exp.Message;
                return View();
            }
        }
        public ActionResult GetSupervisors()
        {
            return View();
        }
      
        public JsonResult supervisorList(Int32 ID)
        {
            Console.WriteLine(ID);
            try
            {
                EmpModelList superviors = new EmpModelList();
                superviors.SupervisorList = new List<Employee>();
                BLLClass b = new BLLClass();
                DtoList list = new DtoList();
                list.SupervisorList = new List<DTOClass>();
                list = b.GetSupervisor(ID);

                foreach (var data in list.SupervisorList)
                {
                    superviors.SupervisorList.Add(
                        new Employee
                        {
                            Id = data.Id,
                            Supervisor = data.Supervisor
                        });
                }
                var json = new { isSuccess = true, data = superviors.SupervisorList };
                return Json(json, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                return Json(new { isSuccess = false, message = e.Message }, JsonRequestBehavior.AllowGet);
                // throw e;
            }

        }
        [HttpGet]
        public JsonResult GetAllEmpsDetails()
        {
            try
            {
                BLLClass bllObj = new BLLClass();
                //  listobj = orig.ConvertAll(x => new Employee{ SomeValue = x.SomeValue });  OR
                EmpModelList mainObj = new EmpModelList();
                List<DTOClass> list = new List<DTOClass>();
                list = bllObj.GetDtoEmps().Emplist;
                mainObj.Emplist = new List<Employee>();
                foreach (var data in list)
                {
                    Employee empObj = new Employee()
                    {
                        Id = data.Id,
                        Name = data.Name,
                        DesgnationId = data.DesgnationId,
                        Designation = data.Designation,
                        Gender = data.Gender,
                        DepartmentId = data.DepartmentId,
                        Department = data.Department,
                        Experience = data.Experience,
                        Skills = data.Skills,
                        EmailId = data.EmailId,
                        ContactNo = data.ContactNo,
                        SupervisorId = data.SupervisorId,
                        Supervisor = data.Supervisor,
                        DateOfBirth = data.DateOfBirth,
                        Address = data.Address,
                        InsertedBy = data.InsertedBy,
                        InsertedOn = data.InsertedOn,
                        UpdatedBy = data.UpdatedBy,
                        UpdatedOn = data.UpdatedOn
                    };
                    mainObj.Emplist.Add(empObj);
                }
              //  var json = new { isSuccess = true, data = mainObj.Emplist };
                return Json(new { isSuccess = true, data = mainObj.Emplist }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { isSuccess = false, message=ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }
        [HttpPost]
        [ActionName("Save")]
        public ActionResult Create(Employee empObj)
        {
            //if(ModelState.IsValid==true)
            //{
                try
                {
                    string result = null;
                    BLLClass b = new BLLClass();
                    DTOClass obj = new DTOClass
                    {
                        Id = empObj.Id,
                        Name = empObj.Name,
                        DesgnationId = empObj.DesgnationId,
                        Gender = empObj.Gender,
                        DepartmentId = empObj.DepartmentId,
                        Experience = empObj.Experience,
                        Skills = empObj.Skills,
                        EmailId = empObj.EmailId,
                        ContactNo = empObj.ContactNo,
                        SupervisorId = empObj.SupervisorId,
                        DateOfBirth = empObj.DateOfBirth,
                        Address = empObj.Address,
                        InsertedBy = empObj.InsertedBy,
                        InsertedOn = System.DateTime.Now,
                        UpdatedBy = empObj.UpdatedBy,
                        UpdatedOn = empObj.UpdatedOn
                    };
                    result = b.SaveDto(obj);
                    return Json(new { isSuccess = true, data = empObj }, JsonRequestBehavior.AllowGet);

                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);

                }
            //}
            //EmpModelList list = new EmpModelList();
            //list.Emp =
            //    new Employee
            //    {
            //        Name = empObj.Name,
            //        DepartmentId=empObj.DepartmentId,
            //        DesgnationId=empObj.DesgnationId,
            //        EmailId=empObj.EmailId,
            //        SupervisorId=empObj.SupervisorId,
            //        DateOfBirth=empObj.DateOfBirth,
            //        Skills=empObj.Skills,
            //        Experience=empObj.Experience,
            //        Gender=empObj.Gender,
            //        Address=empObj.Address,
            //        ContactNo=empObj.ContactNo
            //    };
         
            //return View(list);
           
        }

        [HttpPost]
        [ActionName("GetEmp")]
        public JsonResult Edit(Int32 ID)
        {
            EmpEntityList EMP = new EmpEntityList();
            try
            {
                BLLClass b = new BLLClass();
                DTOClass dalObj = b.GetDtoId(ID);

                EMP.emp = new EmployeeEntity()
                {
                    Id = dalObj.Id,
                    Name = dalObj.Name,
                    DepartmentId = dalObj.DepartmentId,
                    DesgnationId = dalObj.DesgnationId,
                    SupervisorId = dalObj.SupervisorId,
                    Department = dalObj.Department,
                    Designation = dalObj.Designation,
                    Supervisor = dalObj.Supervisor,
                    Address = dalObj.Address,
                    Gender = dalObj.Gender,
                    EmailId = dalObj.EmailId,
                    Skills = dalObj.Skills,
                    ContactNo = dalObj.ContactNo,
                    DateOfBirth = dalObj.DateOfBirth,
                    Experience = dalObj.Experience,
                    // InsertedBy = dalObj.InsertedBy,
                    // InsertedOn = dalObj.InsertedOn,
                    UpdatedBy = dalObj.UpdatedBy,
                    UpdatedOn = dalObj.UpdatedOn
                };
                return Json(new { isSuccess = true, data = EMP.emp }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        // GET: Employee/Delete/5
        [ActionName("DeleteGet")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try {
                string result = null;
                BLLClass b = new BLLClass();
                result = b.DeleteDtoEmp(id);

                return Json(new { isSuccess = true, data = "You Deleted Data" }, JsonRequestBehavior.AllowGet);

            } catch (Exception exp)
            { 
            return Json(new { isSuccess = false, message = exp.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee e)
        {
            try
            {
                return View();
               // return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ShowMap()
        {
            return View();
        }
    }
}
