using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjectLibrary
{
    public class Assignment
    {
        public int Id { get; set; }
        public string ProjectCode { get; set; }
        public string EmpNo { get; set; }
        public DateTime AssignmentDate { get; set; }

        public Assignment(int id, string projectCode, string empNo, DateTime assignmentDate)
        {
            Id = id;
            ProjectCode = projectCode;
            EmpNo = empNo;
            AssignmentDate = assignmentDate;
        }

        public void AssignProject()
        {
            using (SqlConnection con = Connections.GetConnection())
            {
                string strInsert = $"INSERT INTO tblAssignment VALUES({Id},'" +
                    $"{ProjectCode}','{EmpNo}','" +
                    $"{AssignmentDate.ToString("yyyy-MM-dd")}')";

                SqlCommand cmdInsert = new SqlCommand(strInsert, con);
                con.Open();
                cmdInsert.ExecuteNonQuery();
            }
        }
    }
}
