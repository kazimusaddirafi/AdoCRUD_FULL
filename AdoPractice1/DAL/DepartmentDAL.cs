using AdoPractice1.Models;
using AdoPractice1.Utils;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AdoPractice1.DAL
{
    public class DepartmentDAL
    {
        public static string cs=ConnectionString.dbcs;

        public void CreateNewDepartment(Department deptInfo)
        {
            
            using(SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spCreateDepartment",conn);
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name",deptInfo.Name);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Department> GetAllDepartment()
        {
            List <Department> depts=new List<Department> ();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetDepartments", conn);
                cmd.CommandType = CommandType.StoredProcedure;
              
                conn.Open();
               SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Department dept = new Department ();
                    dept.Name = reader["Name"].ToString() ?? "";
                    dept.Id = Convert.ToInt32(reader["ID"]);   
                    
                    depts.Add (dept);
                }
            }

            return depts;
        }


        public List<DepartmentSummary> EmployeeCountByDepartment()
        {
            List<DepartmentSummary> summaries=new List<DepartmentSummary> ();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spEmployeeCountByDepartment", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DepartmentSummary summary = new DepartmentSummary();
                    summary.DepartmentName = reader["DepartmentName"].ToString() ?? "";
                    summary.EmployeeCount = Convert.ToInt32(reader["EmployeeCount"]);

                    summaries.Add(summary);
                }
            }
            return summaries;
        }
    }
}
