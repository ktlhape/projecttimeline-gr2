using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
        public static List<Project> prList = new List<Project>() { 
        new("P100","SONY",Convert.ToDateTime("06-05-2023"),Convert.ToDateTime("16-06-2023"),150),
        new("P101","Xbox",Convert.ToDateTime("09-05-2023"),Convert.ToDateTime("16-07-2023"),230),
        new("P102","Microsoft",Convert.ToDateTime("02-04-2023"),Convert.ToDateTime("16-06-2023"),180),
        new("P103","Nokia",Convert.ToDateTime("21-06-2023"),Convert.ToDateTime("16-09-2023"),155),
        new("P104","Panasonic",Convert.ToDateTime("25-07-2023"),Convert.ToDateTime("22-10-2023"),125),
        new("P105","Anglo",Convert.ToDateTime("11-11-2023"),Convert.ToDateTime("16-01-2024"),250),
        new("P106","Implats",Convert.ToDateTime("07-05-2023"),Convert.ToDateTime("19-08-2023"),230)
        };

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

        public double CalcEstCost(double rate) =>
         (rate * 8) * Duration;

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
            return (from p in prList
                    where (p.Duration / 5) > 6
                    select p).ToList();

        }
        /// <summary>
        /// Get the list of projects that started between two dates
        /// </summary>
        /// <param name="start">Start date to be provided</param>
        /// <param name="end">End date to be provided</param>
        /// <returns>A list of projects</returns>
        public static List<Project> BetweenDates(DateTime start, DateTime end) =>
           (from p in prList
            where p.StartDate >= start &&
            p.EndDate <= end
            select p).ToList();

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
