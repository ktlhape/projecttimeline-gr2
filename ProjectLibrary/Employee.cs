using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary
{
    public class Employee
    {
        public string EmployeeNo { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public double Salary { get; set; }
        public string EmpType { get; set; }

        public Employee(string employeeNo, string firstname, string lastname, string password, double salary, string empType)
        {
            EmployeeNo = employeeNo;
            Firstname = firstname;
            Lastname = lastname;
            Password = password;
            Salary = salary;
            EmpType = empType;
        }
        public static Employee GetEmployee(string empNo)
        {
            Employee em = new Employee("None","No name","No Lastname","None",0,"None");
            using (SqlConnection con = Connections.GetConnection())
            {
                string strSelect = $"SELECT * FROM tblEmployee WHERE EmployeeNo = '{empNo}'";
                SqlCommand cmdSelect = new SqlCommand(strSelect, con);
                con.Open();
                using (SqlDataReader rd = cmdSelect.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        em = new Employee(rd.GetString(0), rd.GetString(1), 
                            rd.GetString(2), rd.GetString(4), rd.GetDouble(3), 
                            rd.GetString(5));
                    }
                }
            }

            return em;
        }
    }
}
