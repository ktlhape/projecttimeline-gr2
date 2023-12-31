﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjectLibrary
{
    public class Project
    {
        public string? Code { get; set; }
        private string? _projectName;

        public string? ProjectName
        {
            get { return _projectName; }
            set
            {
                if (value.Trim().Length < 3)
                {
                    throw new Exception("Project name should be at least 3 characters long");
                }
                else
                {
                    _projectName = value;
                }
            }
        }

        private DateTime _startDate;
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                if (_startDate > EndDate)
                {
                    throw new Exception($"Start date ({StartDate}) cannot be after the end date ({EndDate})");
                }
                else
                {
                    _startDate = value;
                }
            }
        }

        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public double EstimatedCost { get; set; }
        public static List<Project> prList = new List<Project>();

        public Project() { }
        public Project(string? code, string? projectName, DateTime startDate, DateTime endDate,double rate)
        {
            Code = code;
            ProjectName = projectName;
            StartDate = startDate;
            EndDate = endDate;
            //Duration = (EndDate - StartDate).Days;
            Duration = GetDuration(StartDate, EndDate);
            EstimatedCost = CalcEstCost(rate);
        }

        public Project(string? code, string? projectName, DateTime startDate, DateTime endDate, int duration, double estimatedCost)
        {
            Code = code;
            ProjectName = projectName;
            StartDate = startDate;
            EndDate = endDate;
            Duration = duration;
            EstimatedCost = estimatedCost;
        }

        public double CalcEstCost(double rate) =>
         (rate * 8) * Duration;

        public void AddProject()
        {
            string strInsert = $"INSERT INTO tblProject VALUES('{Code}','{ProjectName}'," +
                $"'{StartDate.ToString("yyyy-MM-dd")}','{EndDate.ToString("yyyy-MM-dd")}'," +
                $"{Duration},{EstimatedCost})";
            using (SqlConnection con = Connections.GetConnection())
            {
                SqlCommand cmdInsert = new SqlCommand(strInsert, con);
                con.Open();
                cmdInsert.ExecuteNonQuery();
            }
        }
        public static List<Project> AllProjects()
        {
            List<Project> ls = new();
            using (SqlConnection con = Connections.GetConnection())
            {
                string strSelect = "SELECT * FROM tblProject";
                SqlCommand cmdSelect = new SqlCommand(strSelect, con);
                con.Open();
                using (SqlDataReader reader = cmdSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ls.Add(new((string)reader[0], (string)reader["ProjectName"], 
                            Convert.ToDateTime(reader[2]), Convert.ToDateTime(reader[3]),
                            (int)reader[4], (double)reader.GetDouble(5)));
                    }
                }

            }
            return ls;
        }
        /// <summary>
        /// Get employee projects
        /// </summary>
        /// <param name="empNo">Employee number to be spcified</param>
        /// <returns></returns>
        public static List<Project> EmployeeProjects(string empNo)
        {
            List<Project> ls = new();
            using (SqlConnection con = Connections.GetConnection())
            {
                string strSelect = $"select * from tblProject where PrCode in (select Code from tblAssignment where EmployeeNo = '{empNo}')";
                SqlCommand cmdSelect = new SqlCommand(strSelect, con);
                con.Open();
                using (SqlDataReader reader = cmdSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ls.Add(new((string)reader[0], (string)reader["ProjectName"],
                            Convert.ToDateTime(reader[2]), Convert.ToDateTime(reader[3]),
                            (int)reader[4], (double)reader.GetDouble(5)));
                    }
                }

            }
            return ls;
        }


        //(PR123)  SISONKE - 14 days, EC: R22 400.00. 
        public override string ToString() =>
            $"({Code}) {ProjectName} - {Duration} days, EC: {EstimatedCost.ToString("C2")}";
        /// <summary>
        /// An indexer to get a project with the matching project code
        /// </summary>
        /// <param name="code">Project code to be provided</param>
        /// <returns>Project</returns>
        public Project this[string code]
        {
            get
            {
                foreach (Project p in prList)
                {
                    if (p.Code.Equals(code))
                    {
                        return p;
                    }
                }
                return new Project();
            }
        }
        /// <summary>
        /// An indexer to get all the projects that are over the specified esitimated cost
        /// </summary>
        /// <param name="cost">Esitimated cost to be provided</param>
        /// <returns>List of projects</returns>
        public List<Project> this[double cost]
        {
            get
            {
                return (from p in prList
                        where p.EstimatedCost > cost
                        select p).ToList();
            }
        }
        /// <summary>
        /// Get the list projects that have a duration of more than six weeks
        /// </summary>
        /// <returns>A list of projects</returns>
        public static List<Project> MoreThanSixWeeks()
        {
            List<Project> ls = new();
            using (SqlConnection con = Connections.GetConnection())
            {
                string strSelect = "SELECT * FROM tblProject"; //Complete the statemnet
                SqlCommand cmdSelect = new SqlCommand(strSelect, con);
                con.Open();
                using (SqlDataReader reader = cmdSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ls.Add(new((string)reader[0], (string)reader["ProjectName"],
                            Convert.ToDateTime(reader[2]), Convert.ToDateTime(reader[3]),
                            (int)reader[4], (double)reader.GetDouble(5)));
                    }
                }

            }
            return ls;

            //return (from p in prList
            //        where (p.Duration / 5) > 6
            //        select p).ToList();

        }
        /// <summary>
        /// Get the list of projects that started between two dates
        /// </summary>
        /// <param name="start">Start date to be provided</param>
        /// <param name="end">End date to be provided</param>
        /// <returns>A list of projects</returns>
        public static  List<Project> BetweenDates(DateTime start, DateTime end)
        {
            List<Project> ls = new();
            using (SqlConnection con = Connections.GetConnection())
            {
                string strSelect = $"SELECT * FROM tblProject WHERE StartDate >= {start} AND EndDate <= {end}";
                SqlCommand cmdSelect = new SqlCommand(strSelect, con);
                con.Open();
                using (SqlDataReader reader = cmdSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ls.Add(new((string)reader[0], (string)reader["ProjectName"],
                            Convert.ToDateTime(reader[2]), Convert.ToDateTime(reader[3]),
                            (int)reader[4], (double)reader.GetDouble(5)));
                    }
                }

            }
            return ls;

        }
           

        /// <summary>
        /// Get all the projects that have completed
        /// </summary>
        /// <returns>A List of completed projects</returns>
        public static List<Project> Completed() =>
            (from p in prList
             where p.EndDate < DateTime.Now.Date
             select p).ToList();

        public int GetDuration(DateTime start, DateTime end)
        {
            int totalDays = 0;
            while (start != end)
            {
                if (start.IsWorkingDay())
                {
                    totalDays++;
                }
                start = start.AddDays(1);
            }
            return totalDays;
        }


    }
}
