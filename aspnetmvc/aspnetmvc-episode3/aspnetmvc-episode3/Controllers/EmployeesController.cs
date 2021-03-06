﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspnetmvc_episode3.Controllers
{
    public class EmployeesController : Controller
    {
        readonly Data.SampleEntities _context = new Data.SampleEntities();

        public JsonResult Index(int? id)
        {
            // get all employees who have a manager with the passed id
            var employees = _context.Employees
                .Where(e => id.HasValue ? e.ReportsTo == id : e.ReportsTo == null)
                .Select(e => new {
                    id = e.EmployeeID,
                    Name = e.FirstName + " " + e.LastName,
                    hasChildren = e.Employees1.Any()
                });

            // return as JSON
            return this.Json(employees, JsonRequestBehavior.AllowGet);
        }

    }
}
