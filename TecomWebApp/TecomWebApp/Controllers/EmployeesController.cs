using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using TecomWebApp.Models;
using log4net;
using System.Reflection;

namespace TecomWebApp.Controllers
{
    public class EmployeesController : ODataController
    {
        private readonly TecomTestContext _context;
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public EmployeesController(TecomTestContext context)
        {
            _context = context;
        }

        public ActionResult Get()
        {
            var employees = _context.Employees;
            log.Info("Got a list of employees.");
            return Ok(employees);
        }

        public ActionResult Get(int key)
        {
            var employee = _context.Employees.Where(x => x.Id == key).FirstOrDefault();
            if (employee == null)
            {
                log.Warn("There is no an employee with key = " + key);
                return NotFound();
            }
            log.Info("Got an employee with key = " +  key);
            return Ok(employee);
        }

        public ActionResult Post([FromBody] Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            log.Info("New employee was created.");
            return Created(employee);
        }

        public ActionResult Patch([FromRoute] int key, [FromBody] Delta<Employee> delta)
        {
            var employee = _context.Employees.Where(x => x.Id == key).FirstOrDefault();
            if (employee == null)
            {
                log.Warn("There is no an employee with key = " + key);
                return NotFound();
            }

            delta.Patch(employee);

            _context.SaveChanges();
            log.Info("The employee with key = " + key + " was updated.");
            return Updated(employee);
        }

        public ActionResult Delete([FromRoute] int key)
        {
            var employee = _context.Employees.Where(x => x.Id == key).FirstOrDefault();

            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }

            _context.SaveChanges();
            log.Info("The employee with key = " + key + " was deleted.");
            return NoContent();
        }
    }
}
