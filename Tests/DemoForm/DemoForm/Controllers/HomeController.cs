using DemoForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DemoForm.Controllers
{
    public enum Status
    {
        Manager,
        [Display(Name="Department Manager")]
        DepartmentManager,
        Employee
    }
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult Index(EmployeeModel employee)
        {
            int PID = 0;
            if(string.IsNullOrEmpty(employee.PersonId.ToString()))
            {
                PID = 0;
                ModelState.AddModelError("PersonId", "PersonId is required.");
            }
            else
            {
                if(int.TryParse(employee.PersonId.ToString(), out int personId))
                {
                    PID = personId;
                }
                
              
            }
           

            switch(employee.PersonId)
            {
                case 100:
                    employee.Status = Status.Manager.ToString();
                    break;
                case 200:
                    employee.Status = Status.DepartmentManager.ToString();
                    break;
                default:
                    employee.Status = Status.Employee.ToString();
                    break;
            }

            string name = employee.Name;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}