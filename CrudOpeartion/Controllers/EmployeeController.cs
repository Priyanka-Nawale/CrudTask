using CrudOpeartion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudOpeartion.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmploeedataAccess employeeDataAccess;

        public EmployeeController()
        {
            string filepath = "C:\\Users\\user\\source\\repos\\Task\\CrudOpeartion\\Data\\TextFile1.txt";
            employeeDataAccess = new EmploeedataAccess(filepath);
        }
        public ActionResult Index()
        {
            List<Employee> employees = employeeDataAccess.GetAllEmployees();

            return View(employees);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            employeeDataAccess.Create(employee);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            List<Employee> employees = employeeDataAccess.GetAllEmployees();
            Employee existingEmployee = employees.FirstOrDefault(e => e.Id == id);
            return View(existingEmployee);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            employeeDataAccess.Update(employee);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            List<Employee> employees = employeeDataAccess.GetAllEmployees();
            Employee existingEmployee = employees.FirstOrDefault(e => e.Id == id);
            return View(existingEmployee);
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            List<Employee> employees = employeeDataAccess.GetAllEmployees();
            Employee existingEmployee = employees.FirstOrDefault(e => e.Id == id);
            return View(existingEmployee);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            employeeDataAccess.Delete(id);
            return RedirectToAction("Index");


        }

    }









    }