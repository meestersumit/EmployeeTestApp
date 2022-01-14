using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestappNew.Models;

namespace TestappNew.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            EmployeeDetails employee = new EmployeeDetails();

            List<SelectListItem> ObjItem = new List<SelectListItem>()
            {
          new SelectListItem {Text="--Select--",Value="0",Selected=true },
          new SelectListItem {Text="Hourly",Value="1" },
          new SelectListItem {Text="Salaried",Value="2"},
          new SelectListItem {Text="Managers",Value="3"}
            };
            employee.EmployeeTypes = ObjItem;

            ViewBag.dt = BindEmployees();

            return View(employee);
        }
        [HttpPost]
        public ActionResult Index(EmployeeDetails employeeDetails)
        {
            if (employeeDetails.EmpType == "1")
            {
                if (!string.IsNullOrEmpty(employeeDetails.workingdays) && !string.IsNullOrEmpty(employeeDetails.Vacationgdays))
                {
                    HourlyEmployees hourlyEmployees = new HourlyEmployees();
                    int valDays = hourlyEmployees.Work(Convert.ToInt32(employeeDetails.workingdays));
                    double valVacation = hourlyEmployees.TakeVacation(Convert.ToDouble(employeeDetails.Vacationgdays));
                    if (valDays != -1 && valVacation != -1)
                    {
                        TempData["Message"] = "Working Days : " + employeeDetails.workingdays + " Days And" + Environment.NewLine + " Vacation Time : " + employeeDetails.Vacationgdays + " Days";
                    }
                    else
                        TempData["Message"] = "Invalid Data";
                }

            }

            else if (employeeDetails.EmpType == "2")
            {
                if (!string.IsNullOrEmpty(employeeDetails.workingdays) && !string.IsNullOrEmpty(employeeDetails.Vacationgdays))
                {
                    SalariedEmployees salariedEmployees = new SalariedEmployees();
                    int valDays = salariedEmployees.Work(Convert.ToInt32(employeeDetails.workingdays));
                    double valVacation = salariedEmployees.TakeVacation(Convert.ToDouble(employeeDetails.Vacationgdays));
                    if (valDays != -1 && valVacation != -1)
                    {
                        TempData["Message"] = "Working Days : " + employeeDetails.workingdays + " Days And" + Environment.NewLine + " Vacation Time : " + employeeDetails.Vacationgdays + " Days";
                    }
                    else
                        TempData["Message"] = "Invalid Data";
                }

            }
            else if (employeeDetails.EmpType == "3")
            {
                if (!string.IsNullOrEmpty(employeeDetails.workingdays) && !string.IsNullOrEmpty(employeeDetails.Vacationgdays))
                {
                    ManagerEmployees managerEmployees = new ManagerEmployees();
                    int valDays = managerEmployees.Work(Convert.ToInt32(employeeDetails.workingdays));
                    double valVacation = managerEmployees.TakeVacation(Convert.ToDouble(employeeDetails.Vacationgdays));
                    if (valDays != -1 && valVacation != -1)
                    {
                        TempData["Message"] = "Working Days : " + employeeDetails.workingdays + " Days And" + Environment.NewLine + " Vacation Time : " + employeeDetails.Vacationgdays + " Days";
                    }
                    else
                        TempData["Message"] = "Invalid Data";
                }

            }
            else
                TempData["Message"] = "Please select correct data";

            return RedirectToAction("Index");
        }

        

        private DataTable BindEmployees()
        {
            DataTable dgEmployees = new DataTable();
            dgEmployees.Columns.Add("Employee Id");
            dgEmployees.Columns.Add("Employee Type");
            dgEmployees.Columns.Add("Employee Name");
            dgEmployees.Columns.Add("Vacation Days");
            dgEmployees.Columns.Add("Working Days");

            HourlyEmployees he1 = new HourlyEmployees();
            dgEmployees.Rows.Add(new object[] { "Emp001", "Hourly", "Emp1", he1.Work(251), he1.TakeVacation(9) });
            dgEmployees.Rows.Add(new object[] { "Emp002", "Hourly", "Emp2", he1.Work(252), he1.TakeVacation(8) });
            dgEmployees.Rows.Add(new object[] { "Emp003", "Hourly", "Emp2", he1.Work(253), he1.TakeVacation(7) });
            dgEmployees.Rows.Add(new object[] { "Emp004", "Hourly", "Emp4", he1.Work(254), he1.TakeVacation(6) });
            dgEmployees.Rows.Add(new object[] { "Emp005", "Hourly", "Emp5", he1.Work(255), he1.TakeVacation(5) });
            dgEmployees.Rows.Add(new object[] { "Emp006", "Hourly", "Emp6", he1.Work(256), he1.TakeVacation(4) });
            dgEmployees.Rows.Add(new object[] { "Emp007", "Hourly", "Emp7", he1.Work(257), he1.TakeVacation(3) });
            dgEmployees.Rows.Add(new object[] { "Emp008", "Hourly", "Emp8", he1.Work(258), he1.TakeVacation(2) });
            dgEmployees.Rows.Add(new object[] { "Emp009", "Hourly", "Emp9", he1.Work(259), he1.TakeVacation(1) });
            dgEmployees.Rows.Add(new object[] { "Emp010", "Hourly", "Emp10", he1.Work(260), he1.TakeVacation(0) });


            SalariedEmployees se1 = new SalariedEmployees();
            dgEmployees.Rows.Add(new object[] { "Emp011", "Salaried", "Emp11", se1.Work(246), se1.TakeVacation(14) });
            dgEmployees.Rows.Add(new object[] { "Emp012", "Salaried", "Emp12", se1.Work(247), se1.TakeVacation(13) });
            dgEmployees.Rows.Add(new object[] { "Emp013", "Salaried", "Emp13", se1.Work(248), se1.TakeVacation(12) });
            dgEmployees.Rows.Add(new object[] { "Emp014", "Salaried", "Emp14", se1.Work(249), se1.TakeVacation(11) });
            dgEmployees.Rows.Add(new object[] { "Emp015", "Salaried", "Emp15", se1.Work(250), se1.TakeVacation(10) });
            dgEmployees.Rows.Add(new object[] { "Emp016", "Salaried", "Emp16", se1.Work(251), se1.TakeVacation(9) });
            dgEmployees.Rows.Add(new object[] { "Emp017", "Salaried", "Emp17", se1.Work(252), se1.TakeVacation(8) });
            dgEmployees.Rows.Add(new object[] { "Emp018", "Salaried", "Emp18", se1.Work(253), se1.TakeVacation(7) });
            dgEmployees.Rows.Add(new object[] { "Emp019", "Salaried", "Emp19", se1.Work(254), se1.TakeVacation(6) });
            dgEmployees.Rows.Add(new object[] { "Emp020", "Salaried", "Emp20", se1.Work(255), se1.TakeVacation(5) });

            ManagerEmployees me1 = new ManagerEmployees();
            dgEmployees.Rows.Add(new object[] { "Emp021", "Manager", "Emp21", se1.Work(231), me1.TakeVacation(29) });
            dgEmployees.Rows.Add(new object[] { "Emp022", "Manager", "Emp22", me1.Work(232), me1.TakeVacation(28) });
            dgEmployees.Rows.Add(new object[] { "Emp023", "Manager", "Emp23", me1.Work(233), me1.TakeVacation(27) });
            dgEmployees.Rows.Add(new object[] { "Emp024", "Manager", "Emp24", me1.Work(232), me1.TakeVacation(26) });
            dgEmployees.Rows.Add(new object[] { "Emp025", "Manager", "Emp25", me1.Work(231), me1.TakeVacation(25) });
            dgEmployees.Rows.Add(new object[] { "Emp026", "Manager", "Emp26", me1.Work(232), me1.TakeVacation(24) });
            dgEmployees.Rows.Add(new object[] { "Emp027", "Manager", "Emp27", me1.Work(233), me1.TakeVacation(23) });
            dgEmployees.Rows.Add(new object[] { "Emp028", "Manager", "Emp28", me1.Work(234), me1.TakeVacation(22) });
            dgEmployees.Rows.Add(new object[] { "Emp029", "Manager", "Emp29", me1.Work(235), me1.TakeVacation(21) });
            dgEmployees.Rows.Add(new object[] { "Emp030", "Manager", "Emp30", me1.Work(236), me1.TakeVacation(20) });
            return dgEmployees;

        }
    }
}
