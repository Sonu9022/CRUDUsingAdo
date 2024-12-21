using adoExmapleCRUD.Models;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace adoExmapleCRUD
{
    public class EmployeeDAL
    {
        string cs = ConnectionString.dbcs;

        public List<Employee> getAllEmployees()
        {
            List<Employee> Emplist = new List<Employee>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee emp = new Employee();
                    emp.Id = Convert.ToInt32(rdr["Id"]);
                    emp.name = rdr["name"].ToString() ?? "";
                    emp.gender = rdr["gender"].ToString() ?? "";
                    emp.age = Convert.ToInt32(rdr["age"]);
                    emp.designation = rdr["designation"].ToString() ?? "";
                    emp.city = rdr["city"].ToString() ?? "";
                    Emplist.Add(emp);
                }
            }
            return Emplist;
        }

        public void AddEmployee(Employee emp)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", emp.name);
                cmd.Parameters.AddWithValue("@gender", emp.gender);
                cmd.Parameters.AddWithValue("@age", emp.age);
                cmd.Parameters.AddWithValue("@designation", emp.designation);
                cmd.Parameters.AddWithValue("@city", emp.city);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Employee GetEmpByID(int? id)
        {
            Employee emp = new Employee();
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from Employee where Id = @Id",con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    
                    emp.Id = Convert.ToInt32(rdr["Id"]);
                    emp.name = rdr["name"].ToString() ?? "";
                    emp.gender = rdr["gender"].ToString() ?? "";
                    emp.age = Convert.ToInt32(rdr["age"]);
                    emp.designation = rdr["designation"].ToString() ?? "";
                    emp.city = rdr["city"].ToString() ?? "";
                    
                }
                return emp;
            }
        }

        public void EditEmployee(int? id,Employee emp)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", emp.Id);
                cmd.Parameters.AddWithValue("@name", emp.name);
                cmd.Parameters.AddWithValue("@gender", emp.gender);
                cmd.Parameters.AddWithValue("@age", emp.age);
                cmd.Parameters.AddWithValue("@designation", emp.designation);
                cmd.Parameters.AddWithValue("@city", emp.city);

                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
        public void DeleteEmployee(int? id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id",id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
