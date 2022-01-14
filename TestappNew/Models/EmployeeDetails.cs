using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestappNew.Models
{
    public class EmployeeDetails
    {

        public String EmpType
        {
            get; set;
        }
        public string workingdays
        { get; set; }
        public string Vacationgdays
        { get; set; }

        public List<SelectListItem> EmployeeTypes
        { get; set; }



    }
}