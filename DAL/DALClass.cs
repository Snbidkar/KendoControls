using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Entity ;
using System.Globalization;

namespace DAL
{
    public class DALClass
    {
        // public static List<EntityEmployee> listObj = new List<EntityEmployee>();
        static SqlConnection connStr = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        // static SqlDataReader rdr;
        public static string result = null;
        EmpEntityList listObject = new EmpEntityList();

        public EmpEntityList GetAllEmps()
        {
                try
                {
                    SqlCommand cmd = new SqlCommand("Proc_Employee_Details", connStr);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SQL_CMD_TYPE", "SELECTEmps");
                    if (connStr.State == ConnectionState.Closed)
                    {
                        connStr.Open();
                    }
                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    DataSet tab = new DataSet();
                    sd.Fill(tab);
                    // int count1= tab.Tables[0].Rows.Count;
                    listObject.Emplist = new List<EmployeeEntity>();
                    int table = tab.Tables.Count;
                    if (tab.Tables.Count > 0)
                    {
                        foreach (DataRow row in tab.Tables[0].Rows)
                        {
                            listObject.Emplist.Add(new EmployeeEntity
                            {
                                Id = Convert.ToInt32(row["ID"]),
                                Name = row["NAME"].ToString(),
                                DesgnationId = Convert.ToInt32(row["DESIGNATION_ID"]),
                                Designation = row["DESIGNATION_NAME"].ToString(),
                                Gender = row["GENDER"].ToString(),
                                DepartmentId = Convert.ToInt32(row["DEPARTMENT_ID"]),
                                Department = row["DEPARTMENT_NAME"].ToString(),
                                Experience = Convert.ToDouble(row["EXPERIENCE"]),
                                Skills = row["SKILLS"].ToString(),
                                EmailId = row["EMAIL_ID"].ToString(),
                                ContactNo = row["CONTACT_NUMBER"].ToString(),
                                SupervisorId = row["SUPERVISOR_ID"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["SUPERVISOR_ID"]),
                                Supervisor = row["SUPERVISOR"].ToString(),
                                DateOfBirth = Convert.ToDateTime(row["DATE_OF_BIRTH"].ToString()),
                                Address = row["ADDRESS"].ToString(),
                                InsertedBy = row["INSERTED_BY"] == DBNull.Value ? null : row["INSERTED_BY"].ToString(),
                                InsertedOn = row["INSERTED_ON"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["INSERTED_ON"].ToString()),
                                UpdatedBy = row["UPDATED_BY"] == DBNull.Value ? null : row["UPDATED_BY"].ToString(),
                                UpdatedOn = row["UPDATED_ON"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["UPDATED_ON"].ToString())
                            });

                        }
                    }
                    return listObject;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
            finally
            {
                if (connStr.State == ConnectionState.Open)
                {
                    connStr.Close();
                }
            }
        }

        public EmpEntityList GetAllDetails()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Proc_Employee_Details", connStr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SQL_CMD_TYPE", "SELECT");
               
                if (connStr.State == ConnectionState.Closed)
                {
                    connStr.Open();
                }
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataSet tab = new DataSet();
                sd.Fill(tab);
                // int count1= tab.Tables[0].Rows.Count;
                //  listObject.Emplist = new List<EmployeeEntity>();
                listObject.DesnList = new List<LookupEntity>();
                listObject.DeptList = new List<LookupEntity>();
              //  listObject.SupervisorList = new List<EmployeeEntity>();
                int table = tab.Tables.Count;
                if (tab.Tables.Count > 0)
                {
                    foreach (DataRow row in tab.Tables[0].Rows)
                    {
                        listObject.DesnList.Add(
                               new LookupEntity()
                               {
                                   Id = Convert.ToInt32(row["ID"]),
                                   Name = row["NAME"].ToString()
                               });
                    }

                    foreach (DataRow row in tab.Tables[1].Rows)
                    {
                        listObject.DeptList.Add(
                            new LookupEntity()
                            {
                                Id = Convert.ToInt32(row["ID"]),
                                Name = row["NAME"].ToString()
                            });
                    }
                    //foreach (DataRow row in tab.Tables[2].Rows)
                    //{
                    //    listObject.SupervisorList.Add(
                    //        new EmployeeEntity()
                    //        {
                    //            Id = Convert.ToInt32(row["ID"]),
                    //            Supervisor = row["SUPERVISOR"].ToString()
                    //        });
                    //}

                }
                    return listObject;
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
            finally
            {
                if (connStr.State == ConnectionState.Open)
                {
                    connStr.Close();
                }

            }
        }
        public EmpEntityList GetSuperVisor(Int32 id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Proc_Employee_Details", connStr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SQL_CMD_TYPE", "SELECTsuper");
                cmd.Parameters.AddWithValue("@ID", id);
              //  cmd.Parameters.AddWithValue("@DEPARTMENT_ID",)
                if (connStr.State == ConnectionState.Closed)
                {
                    connStr.Open();
                }
                listObject.SupervisorList = new List<EmployeeEntity>();
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataSet tab = new DataSet();
                sd.Fill(tab);
                int table = tab.Tables.Count;
                if (tab.Tables.Count >= 0)
                {
                    foreach (DataRow row in tab.Tables[0].Rows)
                    {
                        listObject.SupervisorList.Add(new EmployeeEntity
                        {
                            Id = Convert.ToInt32(row["ID"]),
                            Supervisor = row["SUPERVISOR"].ToString()
                        });
                    }
                }
                
                connStr.Close();
                return listObject;
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
            finally
            {
                if (connStr.State == ConnectionState.Open)
                {
                    connStr.Close();
                }
            }
        }
        public string SaveEmp(EmployeeEntity e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Proc_Employee_Details", connStr);
              
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", e.Id);
                cmd.Parameters.AddWithValue("@NAME", e.Name);
                cmd.Parameters.AddWithValue("@DESIGNATION_ID", e.DesgnationId);
                cmd.Parameters.AddWithValue("@GENDER", e.Gender);
                cmd.Parameters.AddWithValue("@DEPARTMENT_ID", e.DepartmentId);
                cmd.Parameters.AddWithValue("@EXPERIENCE", e.Experience);
                cmd.Parameters.AddWithValue("@SKILLS", e.Skills);
                cmd.Parameters.AddWithValue("@EMAIL_ID", e.EmailId);
                cmd.Parameters.AddWithValue("@CONTACT_NUMBER", e.ContactNo);
                cmd.Parameters.AddWithValue("@SUPERVISOR_ID", e.SupervisorId);
                cmd.Parameters.AddWithValue("@DATE_OF_BIRTH", e.DateOfBirth);
                cmd.Parameters.AddWithValue("@ADDRESS", e.Address);
                cmd.Parameters.AddWithValue("@INSERTED_BY", "Sneha");
                cmd.Parameters.AddWithValue("@INSERTED_ON", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@UPDATED_BY", "Sneha");
                cmd.Parameters.AddWithValue("@UPDATED_ON", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@SQL_CMD_TYPE", "Save");
                
                

                if (connStr.State == ConnectionState.Closed)
                {
                    connStr.Open();
                }
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                result = cmd.ExecuteNonQuery().ToString();
                return result;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
                throw exp;
            }

            finally
            {
                if (connStr.State == ConnectionState.Open)
                {
                    connStr.Close();
                }
            }
        }
            public EmployeeEntity GetId(Int32 ID)
            {
            try
            {
                SqlCommand cmd = new SqlCommand("Proc_Employee_Details", connStr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SQL_CMD_TYPE", "GETID");
                cmd.Parameters.AddWithValue("@ID", ID);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                if (connStr.State == ConnectionState.Closed)
                {
                    connStr.Open();
                }
                DataSet tab = new DataSet();
                sd.Fill(tab);

                foreach (DataRow row in tab.Tables[0].Rows)
                {
                    listObject.emp = new EmployeeEntity
                    {
                        Id = Convert.ToInt32(row["ID"]),
                        Name = row["NAME"].ToString(),
                        DesgnationId = Convert.ToInt32(row["DESIGNATION_ID"]),
                        Designation = row["DESIGNATION_NAME"].ToString(),
                        Gender = row["GENDER"].ToString(),
                        DepartmentId = Convert.ToInt32(row["DEPARTMENT_ID"]),
                        Department = row["DEPARTMENT_NAME"].ToString(),
                        Experience = Convert.ToDouble(row["EXPERIENCE"]),
                        Skills = row["SKILLS"].ToString(),
                        EmailId = row["EMAIL_ID"].ToString(),
                        ContactNo = row["CONTACT_NUMBER"].ToString(),
                        SupervisorId = row["SUPERVISOR_ID"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["SUPERVISOR_ID"]),
                        Supervisor = row["SUPERVISOR"].ToString(),
                        DateOfBirth = Convert.ToDateTime(row["DATE_OF_BIRTH"].ToString()),
                        Address = row["ADDRESS"].ToString(),
                        InsertedBy = row["INSERTED_BY"] == DBNull.Value ? null : row["INSERTED_BY"].ToString(),
                        InsertedOn = row["INSERTED_ON"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["INSERTED_ON"].ToString()),
                        UpdatedBy = row["UPDATED_BY"] == DBNull.Value ? null : row["UPDATED_BY"].ToString(),
                        UpdatedOn = row["UPDATED_ON"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["UPDATED_ON"].ToString())
                    };
                }

                return listObject.emp;
            }
            catch (Exception exp)
            {
                
                throw exp;
            }
            finally {
                if (connStr.State == ConnectionState.Open)
                {
                    connStr.Close();
                }
            }
            }

        public string DeleteEmp(int id)
        {
            string res;
            try
            {
                SqlCommand cmd = new SqlCommand("Proc_Employee_Details", connStr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SQL_CMD_TYPE", "DELETE");
                cmd.Parameters.AddWithValue("@ID", id);
                if (connStr.State == ConnectionState.Closed)
                {
                    connStr.Open();
                }
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                res = cmd.ExecuteNonQuery().ToString();
                return res;
            }
            catch(Exception exp) {
                Console.WriteLine(exp);
                throw exp;
            }
            finally
            {
                if (connStr.State == ConnectionState.Open)
                {
                    connStr.Close();
                }
            }
        } 
    }
}





















