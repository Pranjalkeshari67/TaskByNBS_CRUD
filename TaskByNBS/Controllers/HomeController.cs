using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskByNBS.Models;
using TaskByNBS.Repository;

namespace TaskByNBS.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // Employee Registration **Start**
        #region
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(Registration reg)
        {
            if (!string.IsNullOrEmpty(Session["file_name"] as string))
            {
                reg.EmployeeProfile = Session["file_name"].ToString().Trim();
            }
            HomeRepository EmpRepos = new HomeRepository();
            DataSet ds = EmpRepos.InsertEmployee_Repository(reg);
            string status = ds.Tables[0].Rows[0]["IsExist"].ToString();

            if (status == "0")
            {
                ViewBag.Succmsg = "Employee Details added Successfully.";
            }
            else
            {
                ViewBag.Errormsg = "Unable to add Employee Details.";
            }
            return View();
        }
        #endregion
        // Employee Registration **End**

        // Employee Records **Start**
        #region
        [HttpGet]
        public ActionResult EmployeeRecords()
        {
            HomeRepository regRepos = new HomeRepository();
            List<Registration> lst_EmpList = regRepos.BindEmployee_Repository();
            ViewBag.empList = lst_EmpList;
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeRecords(Registration reg)
        {
            return View();
        }
        #endregion
        // Employee Records **End**

        // For Upload Files **Start**
        #region
        [HttpPost]
        public ActionResult UploadFiles()
        {
            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        string fname;
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = "Employee_Prof_" + DateTime.Now.Ticks + "_" + testfiles[testfiles.Length - 1];
                        }
                        else
                        {

                            fname = "Employee_Prof_" + DateTime.Now.Ticks + "_" + file.FileName;
                        }
                        fname = Path.Combine(Server.MapPath("~/Content/Uploaded_Images/"), fname);
                        string filePathName = Path.GetFileName(fname);
                        Session["file_name"] = filePathName;
                        file.SaveAs(fname);
                    }
                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }
        #endregion
        // For Upload Files **End**


        // For Data Deletion **Start**
        #region
        public JsonResult DeleteEmployee(int EmployeeId)
        {
            HomeRepository ebl = new HomeRepository();
            bool b = ebl.DeleteEmployeeRecord_Repository(EmployeeId);
            if (b)
            {
                return Json("ok", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("nok", JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
        // For Data Deletion **End**

        // Employee Updation **Start**
        #region
        [HttpGet]
        public ActionResult UpdateEmployeeDetails(int empid)
        {
            if(empid != 0)
            {
                HomeRepository regRepos = new HomeRepository();
                List<Registration> lst_EmpUpdList = regRepos.BindSingleEmployee_Repository(empid);
                ViewBag.empUpdList = lst_EmpUpdList;
            }
            return View();
        }
        [HttpPost]
        public ActionResult UpdateEmployeeDetails(Registration reg)
        {
            if (!string.IsNullOrEmpty(Session["file_name"] as string))
            {
                reg.EmployeeProfile = Session["file_name"].ToString().Trim();
            }
            else if(reg.EmployeeProfile != null)
            {
                reg.EmployeeProfile = reg.EmployeeProfile.ToString().Trim();
            }
            HomeRepository EmpRepos = new HomeRepository();
            DataSet ds = EmpRepos.UpdateEmployee_Repository(reg);
            string status = ds.Tables[0].Rows[0]["IsExist"].ToString();

            if (status == "0")
            {
                ViewBag.Succmsg = "Employee Details updated Successfully.";
            }
            else
            {
                ViewBag.Errormsg = "Unable to update Employee Details.";
            }
            return RedirectToAction("EmployeeRecords");
        }
        #endregion
        // Employee Updation **End**

        // Product
        #region
        [HttpGet]
        public ActionResult allProducts()
        {
            return View();
        }
        [HttpPost]
        public ActionResult allProducts(Registration reg)
        {
            return View();
        }
        #endregion
        // Product

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Registration reg)
        {
            return View();
        }
        [HttpGet]
        public ActionResult loginActivity()
        {
            return View();
        }
    }
}