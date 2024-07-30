using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TaskByNBS.Models;

namespace TaskByNBS.Repository
{
    public class HomeRepository
    {
        // For Building Connection all time Start*
        private SqlConnection con;
        private void Connection_Builder()
        {
            string conStr = ConfigurationManager.ConnectionStrings["ConStr"].ToString();
            con = new SqlConnection(conStr);
        }
        // For Building Connection all time End*

        // For Insert Employee Records Start*
        public DataSet InsertEmployee_Repository(Registration reg)
        {
            try
            {
                Connection_Builder();
                SqlCommand com = new SqlCommand("proc_DataOperations", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ProcId", "InsertEmployeeRecord");
                com.Parameters.AddWithValue("@EmployeeName", reg.EmployeeName);
                com.Parameters.AddWithValue("@EmployeeSalary", reg.EmployeeSalary);
                com.Parameters.AddWithValue("@EmployeeDOJ", reg.EmployeeDOJ);
                com.Parameters.AddWithValue("@EmployeeGender", reg.EmployeeGender);
                com.Parameters.AddWithValue("@EmployeeProfile", reg.EmployeeProfile);
                con.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(com);
                sda.Fill(ds);
                con.Close();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // For Insert Employee Records End*

        // For Bind Employee Records Start*
        public List<Registration> BindEmployee_Repository()
        {
            try
            {
                Connection_Builder();
                SqlCommand com = new SqlCommand("proc_DataOperations", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ProcId", "BindEmployeeRecord");
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(com);
                DataTable dtb = new DataTable();
                sda.Fill(dtb);
                List<Registration> emplist = new List<Registration>();
                if (dtb.Rows.Count > 0)
                {
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        Registration reg = new Registration();
                        reg.EmployeeId = Convert.ToInt32(dtb.Rows[i]["EmployeeId"].ToString());
                        reg.EmployeeName = dtb.Rows[i]["EmployeeName"].ToString();
                        reg.EmployeeSalary = dtb.Rows[i]["EmployeeSalary"].ToString();
                        reg.EmployeeDOJ = dtb.Rows[i]["EmployeeDOJ"].ToString();
                        reg.EmployeeGender = dtb.Rows[i]["EmployeeGender"].ToString();
                        reg.EmployeeProfile = dtb.Rows[i]["EmployeeProfile"].ToString();
                        reg.IsActive = Convert.ToBoolean(dtb.Rows[i]["IsActive"].ToString());
                        reg.AddedDate = dtb.Rows[i]["AddedDate"].ToString();
                        emplist.Add(reg);
                    }
                }
                con.Close();
                return emplist;
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }
        // For Bind Employee Records End*

        // For Delete Employee Records Start*
        public bool DeleteEmployeeRecord_Repository(int EmployeeId)
        {
            try
            {
                Connection_Builder();
                SqlCommand com = new SqlCommand("proc_DataOperations", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ProcId", "DeleteData");
                com.Parameters.AddWithValue("@EmployeeId", EmployeeId);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // For Delete Employee Records End* 

        // For Bind Employee Updation Start*
        public List<Registration> BindSingleEmployee_Repository(int EmpID)
        {
            try
            {
                Connection_Builder();
                SqlCommand com = new SqlCommand("proc_DataOperations", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ProcId", "BindSingleEmployeeRecord");
                com.Parameters.AddWithValue("@EmployeeId", EmpID);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(com);
                DataTable dtb = new DataTable();
                sda.Fill(dtb);
                List<Registration> emplist = new List<Registration>();
                if (dtb.Rows.Count > 0)
                {
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        Registration reg = new Registration();
                        reg.EmployeeId = Convert.ToInt32(dtb.Rows[i]["EmployeeId"].ToString());
                        reg.EmployeeName = dtb.Rows[i]["EmployeeName"].ToString();
                        reg.EmployeeSalary = dtb.Rows[i]["EmployeeSalary"].ToString();
                        reg.EmployeeDOJ = dtb.Rows[i]["EmployeeDOJ"].ToString();
                        reg.EmployeeGender = dtb.Rows[i]["EmployeeGender"].ToString();
                        reg.EmployeeProfile = dtb.Rows[i]["EmployeeProfile"].ToString();
                        reg.IsActive = Convert.ToBoolean(dtb.Rows[i]["IsActive"].ToString());
                        reg.AddedDate = dtb.Rows[i]["AddedDate"].ToString();
                        emplist.Add(reg);
                    }
                }
                con.Close();
                return emplist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // For Bind Employee Updation End*

        // For Update Employee Records Start*
        public DataSet UpdateEmployee_Repository(Registration reg)
        {
            try
            {
                Connection_Builder();
                SqlCommand com = new SqlCommand("proc_DataOperations", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ProcId", "UpdateEmployeeRecord");
                com.Parameters.AddWithValue("@EmployeeId", reg.EmployeeId);
                com.Parameters.AddWithValue("@EmployeeName", reg.EmployeeName);
                com.Parameters.AddWithValue("@EmployeeSalary", reg.EmployeeSalary);
                com.Parameters.AddWithValue("@EmployeeDOJ", reg.EmployeeDOJ);
                com.Parameters.AddWithValue("@EmployeeGender", reg.EmployeeGender);
                if(reg.EmployeeProfile != null)
                {
                    com.Parameters.AddWithValue("@EmployeeProfile", reg.EmployeeProfile);
                }
                con.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(com);
                sda.Fill(ds);
                con.Close();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // For Update Employee Records End*
    }
}