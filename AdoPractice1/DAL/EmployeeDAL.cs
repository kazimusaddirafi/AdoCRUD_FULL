using AdoPractice1.Models;
using AdoPractice1.Utils;
using System.Data;
using System.Data.SqlClient;

namespace AdoPractice1.DAL
{
    public class EmployeeDAL
    {
        public static string cs=ConnectionString.dbcs;

        public void CreateNewEmployee(Employee emp)
        {
            using(SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spCreateEmployee",conn);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Pin", emp.Pin);
                cmd.Parameters.AddWithValue("@IsActive", emp.IsActive);
                cmd.Parameters.AddWithValue("@DeptId", emp.DeptId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using(SqlConnection conn=new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployee",conn) ;
                conn.Open() ;
                SqlDataReader   reader = cmd.ExecuteReader();
                while(reader.Read()) { 
                    Employee emp=new Employee();
                    emp.Id = Convert.ToInt32(reader["Id"]);
                    emp.Name = reader["Name"].ToString() ?? "";
                    emp.Pin = reader["Pin"].ToString() ?? "";
                    emp.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                    emp.Department = new Department
                    {
                        Name = reader["DepartmentName"].ToString() ?? "",

                    };

                    employees.Add(emp); 

                }

            }

            return  employees ;
        }

        public Employee GetEmployeeDetails(int id)
        {
            Employee emp = new Employee();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spEmployeeDetails", conn);
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {                   
                    emp.Id = Convert.ToInt32(reader["Id"]);
                    emp.Name = reader["Name"].ToString() ?? "";
                    emp.Pin = reader["Pin"].ToString() ?? "";
                    emp.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                    emp.Department = new Department
                    {
                        Name = reader["DepartmentName"].ToString() ?? "",
                        Id= Convert.ToInt32(reader["DeptId"]),

                };
                }
            }
            return emp;
        }

        public void DeleteEmployee(int id)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateEmployee(Employee emp)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", emp.Id);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Pin", emp.Pin);
                cmd.Parameters.AddWithValue("@IsActive", emp.IsActive);
                cmd.Parameters.AddWithValue("@DeptId", emp.DeptId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
