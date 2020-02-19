using EO.Pdf;
using FluentValidation.Results;
using GenRepositoryPattern.DAL.Repository;
using GenRepositoryPattern.Models;
using GenRepositoryPattern.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenRepositoryPattern.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public ActionResult Index()
        {
            var employees = _employeeRepository.GetAll();
            return View(employees);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee obj)
        {
            EmployeeValidation validation = new EmployeeValidation();
            ValidationResult model = validation.Validate(obj);
            if (model.IsValid)
            {
                _employeeRepository.Add(obj);
                _employeeRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                foreach(ValidationFailure _error in model.Errors)
                {
                    ModelState.AddModelError(_error.PropertyName, _error.ErrorMessage);
                }
            }
            return View(obj);
        }

        public ActionResult Update(int id)
        {
            var emp = _employeeRepository.FindBy(id);
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Update(emp);
                _employeeRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(emp);
        }

        public ActionResult Delete(int id)
        {
            var emp = _employeeRepository.FindBy(id);
            return View(emp);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _employeeRepository.Delete(id);
            _employeeRepository.Save();
            return RedirectToAction("Index");
        }

        public ActionResult ConvertToPdf()
        {
            HtmlToPdf.ConvertUrl(@"C:\Users\ith\Downloads\Launch-master\index.html", @"C:\Users\ith\Downloads\Launch-master\result.html");
            return RedirectToAction("Index", "Home");
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