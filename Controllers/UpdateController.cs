using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CRUD.Controllers
{
    public class UpdateController : Controller
    {
        public async Task<IActionResult> UpdateSingle1()
        {
            var dept = new Department()
            {
                Id = 5,
                Name = "Designing01",
            };

            using (var context = new CompanyContext())
            {
                context.Update(dept);

                try
                {
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    this.DisplayResult(new { message = ex.Message });
                    return View("Common");
                }

                this.DisplayResult(context.Department.Single(d => d.Id == 2));
            }

            return View("Common");
        }

        private void DisplayResult<T>(T info)
        {
            ViewBag.Result = JsonConvert.SerializeObject(info);
        }

        public async Task<IActionResult> UpdateSingle2()
        {
            using (var context = new CompanyContext())
            {
                var dept = context.Department.Single(d => d.Id == 3);
                dept.Name = "Designing02";

                context.Update(dept);
                await context.SaveChangesAsync();

                this.DisplayResult(context.Department.Single(d => d.Id == 3));
            }

            return View("Common");
        }

        public async Task<IActionResult> UpdateSingle3()
        {
            using (var context = new CompanyContext())
            {
                var query = from a in context.Department.AsNoTracking()
                            where a.Id == 3
                            select a;

                var dept = query.Single();
                dept.Name = "test";

                context.Update(dept);
                await context.SaveChangesAsync();

                this.DisplayResult(context.Department.Single(d => d.Id == 3));
            }

            return View("Common");
        }

        public async Task<IActionResult> UpdateMultiple()
        {
            var dept1 = new Department()
            {
                Id = 1,
                Name = "New Designing"
            };

            var dept2 = new Department()
            {
                Id = 2,
                Name = "New Research"
            };

            var dept3 = new Department()
            {
                Id = 3,
                Name = "New HR"
            };

            List<Department> modifiedDept = new List<Department>() { dept1, dept2, dept3 };

            using (var context = new CompanyContext())
            {
                context.UpdateRange(modifiedDept);
                await context.SaveChangesAsync();
            }

            return View("Common");
        }

        public async Task<IActionResult> UpdateRelated()
        {
            var dept = new Department()
            {
                Id = 8,
                Name = "Admin_1"
            };

            var emp = new Employee()
            {
                Id = 1,
                Name = "Matt_1",
                Designation = "Head_1",
                Department = dept
            };

            using (var context = new CompanyContext())
            {
                context.Update(emp);
                await context.SaveChangesAsync();
            }

            return View("Common");
        }
    }
}