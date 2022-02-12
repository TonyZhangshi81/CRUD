using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class InsertController : Controller
    {
        public IActionResult InsertSingle()
        {
            var dept = new Department()
            {
                Name = "Designing1"
            };

            using (var context = new CompanyContext())
            {
                context.Department.Add(dept);
                context.SaveChanges();
            }
            return View("Common");
        }

        public async Task<IActionResult> InsertSingleAsyn()
        {
            var dept = new Department()
            {
                Name = "Designing"
            };

            using (var context = new CompanyContext())
            {
                context.Add(dept);
                await context.SaveChangesAsync();
            }
            return View("Common");
        }

        public async Task<IActionResult> InsertMultiple()
        {
            var dept1 = new Department() { Name = "Development" };
            var dept2 = new Department() { Name = "HR" };
            var dept3 = new Department() { Name = "Marketing" };

            using (var context = new CompanyContext())
            {
                context.AddRange(dept1, dept2, dept3);
                await context.SaveChangesAsync();
            }

            return View("Common");
        }

        public async Task<IActionResult> InsertRelated()
        {
            var dept = new Department()
            {
                Name = "Admin"
            };

            var emp = new Employee()
            {
                Name = "Matt",
                Designation = "Head",
                Department = dept
            };

            using (var context = new CompanyContext())
            {
                context.Add(emp);
                await context.SaveChangesAsync();
            }

            return View("Common");
        }
    }
}