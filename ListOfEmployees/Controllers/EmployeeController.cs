using ListOfEmployees.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListOfEmployees.Controllers
{
    public class EmployeeController : Controller
    {
        static List<EmployeeViewModel> Employees = new List<EmployeeViewModel>()
        {
            new EmployeeViewModel(){ PersonnelNumber=53122, FullName="Иванов Иван Иванович", Department="ОСТ", EmployeesPosition="Инженер-конструктор" },
            new EmployeeViewModel(){ PersonnelNumber=43168, FullName="Петров Петр Петрович", Department="ОТММ", EmployeesPosition="Начальник бюро" },
            new EmployeeViewModel(){ PersonnelNumber=74235, FullName="Семенов Семен Семенович", Department="ОМТ", EmployeesPosition="Инженер-конструктор" },
        };

        // GET: EmployeeController
        public ActionResult Index()
        {
            return View(Employees);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeViewModel employee)
        {
            try
            {
                Employees.Add(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            EmployeeViewModel employee = Employees.FirstOrDefault(x => x.PersonnelNumber == id);
            return View(employee);

        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeViewModel employee)
        {
            try
            {
  
                Employees[GetIndexFromEmployees(employee)] = employee;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            EmployeeViewModel employee = Employees.FirstOrDefault(x => x.PersonnelNumber == id);
            return View(employee);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EmployeeViewModel employee)
        {
            try
            {
                Employees.Remove(Employees[GetIndexFromEmployees(employee)]);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private int GetIndexFromEmployees(EmployeeViewModel employee)
        { 
            int id = Employees.IndexOf(Employees.Where(x => x.PersonnelNumber == employee.PersonnelNumber).FirstOrDefault());
            return id;

        }
    }
}
