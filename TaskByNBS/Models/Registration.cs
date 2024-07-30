using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskByNBS.Models
{
    public class Registration
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSalary { get; set; }
        public string EmployeeDOJ { get; set; }
        public string EmployeeGender { get; set; }
        public string EmployeeProfile { get; set; }
        public bool IsActive { get; set; }
        public string AddedDate { get; set; }

        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}