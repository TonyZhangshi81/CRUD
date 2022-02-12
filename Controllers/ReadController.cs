using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers
{
    public class ReadController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using (var context = new CompanyContext())
            {
                var emp = await context.Employee.ToListAsync();
                var dept = await context.Department.ToListAsync();

            }

            return View("Common");
        }

        public async Task<IActionResult> EagerRead()
        {
            Employee emp;
            using (var context = new CompanyContext())
            {
                emp = await context.Employee.Where(e => e.Name == "Matt")
                                        .Include(s => s.Department)
                                        .FirstOrDefaultAsync();
            }

            return View("Common");
        }

        public async Task<IActionResult> ExplicitRead()
        {
            Employee emp;
            using (var context = new CompanyContext())
            {
                emp = await context.Employee.Where(e => e.Name == "Matt").FirstOrDefaultAsync();
                await context.Entry(emp).Reference(s => s.Department).LoadAsync();
                //await context.Entry(emp).Reference(s => s.Department).Query().Where(s => s.Name == "Admin").LoadAsync();
            }

            return View("Common");
        }

        public async Task<IActionResult> LazyRead()
        {
            Employee emp;
            using (var context = new CompanyContext())
            {
                emp = await context.Employee.Where(e => e.Name == "Matt")
                                        .FirstOrDefaultAsync();
                string deptName = emp.Department.Name;
            }

            return View("Common");
        }
    }
}