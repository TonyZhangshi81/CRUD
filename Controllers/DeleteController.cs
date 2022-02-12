using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers
{
    public class DeleteController : Controller
    {
        public async Task<IActionResult> DeleteSingle()
        {
            var dept = new Department()
            {
                Id = 1
            };

            using (var context = new CompanyContext())
            {
                context.Remove(dept);
                await context.SaveChangesAsync();
            }

            return View("Common");
        }

        public async Task<IActionResult> DeleteMultiple()
        {
            List<Department> dept = new List<Department>()
            {
                new Department(){Id=1},
                new Department(){Id=2},
                new Department(){Id=3}
            };

            using (var context = new CompanyContext())
            {
                context.RemoveRange(dept);
                await context.SaveChangesAsync();
            }

            return View("Common");
        }

        public async Task<IActionResult> DeleteRelated()
        {
            using (var context = new CompanyContext())
            {
                Department dept = context.Department.Where(a => a.Id == 1008).Include(x => x.Employee).FirstOrDefault();
                context.Remove(dept);
                await context.SaveChangesAsync();
            }

            return View("Common");
        }
    }
}