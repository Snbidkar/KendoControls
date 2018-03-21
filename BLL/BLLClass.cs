using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
using DTO;

namespace BLL
{
    public class BLLClass
    {
     // public static List<DTOClass> listDto; 

        public DtoList GetDtoData()
        {
            try
            {
                DALClass Obj = new DALClass();
                DtoList listDto = new DtoList();
               // listDto.Emplist = new List<DTOClass>();
                EmpEntityList emp = Obj.GetAllDetails();

                listDto.DesnList = new List<LookupDTO>();
                foreach (var data in emp.DesnList)
                {
                    LookupDTO desgObj = new LookupDTO()
                    {
                        Id = data.Id,
                        Name = data.Name
                    };
                    listDto.DesnList.Add(desgObj);
                }

                listDto.DeptList = new List<LookupDTO>();
                foreach (var data in emp.DeptList)
                {
                    LookupDTO deptObj = new LookupDTO()
                    {
                        Id = data.Id,
                        Name = data.Name
                    };

                    listDto.DeptList.Add(deptObj);
                }

                //listDto.SupervisorList = new List<DTOClass>();
                //int c = emp.SupervisorList.Count();

                //foreach (var data in emp.SupervisorList)
                //{
                //    DTOClass superObj = new DTOClass()
                //    {
                //        Id = data.Id,
                //        Supervisor = data.Supervisor
                //    };
                //    listDto.SupervisorList.Add(superObj);
                //}
                return listDto; 
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public DtoList GetSupervisor(Int32 id)
        {
            try
            {
                DtoList dtolist = new DtoList();
                dtolist.SupervisorList = new List<DTOClass>();
                DALClass dalObj = new DALClass();
                EmpEntityList list = dalObj.GetSuperVisor(id);
                foreach (var data in list.SupervisorList)
                {
                    dtolist.SupervisorList.Add(new DTOClass
                    {
                        Id = data.Id,
                        Supervisor = data.Supervisor
                    });
                }
                return dtolist;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public DtoList GetDtoEmps()
        {
            try
            {
                DALClass Obj = new DALClass();
                DtoList listDto = new DtoList();
                listDto.Emplist = new List<DTOClass>();
                EmpEntityList emp = Obj.GetAllEmps();
                foreach (var data in emp.Emplist)
                {
                    DTOClass dt = new DTOClass
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
                    listDto.Emplist.Add(dt);
                }
                return listDto;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string SaveDto(DTOClass e)
        {
            try
            {
                string res = null;
                DALClass dalObj = new DALClass();
                EmployeeEntity empObj = new EmployeeEntity
                {
                    Id=e.Id,
                    Name = e.Name,
                    DesgnationId = e.DesgnationId,
                    Gender = e.Gender,
                    DepartmentId = e.DepartmentId,
                    Experience = e.Experience,
                    Skills = e.Skills,
                    EmailId = e.EmailId,
                    ContactNo = e.ContactNo,
                    SupervisorId = e.SupervisorId,
                    DateOfBirth = e.DateOfBirth,
                    Address = e.Address,
                    InsertedBy = e.InsertedBy,
                    InsertedOn = e.InsertedOn
                };
                res = dalObj.SaveEmp(empObj);
                return res;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
                
        public DTOClass GetDtoId(Int32 ID)
        {
            try
            {

                DALClass dalObj = new DALClass();
                EmployeeEntity empObj = new EmployeeEntity();
                empObj = dalObj.GetId(ID);
                DTOClass Obj = new DTOClass()
                {
                    Id = empObj.Id,
                    Name = empObj.Name,
                    DepartmentId = empObj.DepartmentId,
                    Department = empObj.Department,
                    DesgnationId = empObj.DesgnationId,
                    Designation = empObj.Designation,
                    SupervisorId = empObj.SupervisorId,
                    Supervisor = empObj.Supervisor,
                    Gender = empObj.Gender,
                    DateOfBirth = empObj.DateOfBirth,
                    Skills = empObj.Skills,
                    Address = empObj.Address,
                    InsertedBy = empObj.InsertedBy,
                    InsertedOn = empObj.InsertedOn,
                    UpdatedBy = empObj.UpdatedBy,
                    UpdatedOn = empObj.UpdatedOn,
                    ContactNo = empObj.ContactNo,
                    EmailId = empObj.EmailId,
                    Experience = empObj.Experience

                };
                return Obj;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public string DeleteDtoEmp(Int32 id)
        {
            try
            {
                string res = null;
                DALClass del = new DALClass();
                res = del.DeleteEmp(id);
                return res;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
