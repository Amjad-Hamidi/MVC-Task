using CRUD.Data;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers
{
    public class EmployeesController : Controller
    {
        //ApplicationDbContext context=new ApplicationDbContext();


        
        private readonly ApplicationDbContext _context; // object وليس field البرنامج الان الي رح يعمل الاوبجكت وليس انا , يسمى 

        public EmployeesController(ApplicationDbContext context)
        {
            this._context = context;
        }


        public IActionResult Index()
        {
            var employees = _context.Employees.AsNoTracking().ToList();//to retreive All Employees without tracking => just for display not to modify
            foreach(var employee in employees)
            {
                Console.WriteLine(employee.Name);
            }
            return View("Index",employees);//or : return View(employees) => it's the same here , cuz it's the smae name of controller
        }


        [HttpGet] // by default تعني اني بعرض داتا, وهي غير ضرورية 
        public IActionResult Create() // يعمل على عرض الداتا
        {
            return View(); // Create الي اسمها  view بوديني لل 
        }

		/*
         Select => don't need to write :  [HttpGet]

         Add =>  need to write :  [HttpPost]
         Modify =>  need to write :  [HttpPost]
         Delete =>  need to write :  [HttpPost]
         */

		[HttpPost] // تعني اني بضيف داتا, وهي ضرورية هنا عشان بحملو نفس الاسم ولانها بتضيف مش بتعرض
        public IActionResult Create(Employee emp) //يعمل على اضافة الداتا // Create الي اسمها view هاد بوصله من خلال ال
		{
            // اضافة داتا على الداتا بيس مباشرة

            List<int> ages = new List<int>() { 1,2,3,4 };
            _context.Employees.Add(emp);
            _context.SaveChanges();
            return RedirectToAction("Index"); // بتوديني عالاكشن الي اسمه اندكس , موجود هيو هون فوق  
        }

        public IActionResult Edit(int id) // Model الباراميتير هنا للايديت يطلق عليه 
        {
			var employee = _context.Employees.Find(id);

			return View(employee);
        }

        public IActionResult Update(Employee emp) // Model الباراميتير هنا للابديت يطلق عليه 
        {
			//emp => الجديد
			//employee => القديم
			var employee = _context.Employees.Find(emp.Id);//id: is hidden => review form to notice that
			employee.Name=emp.Name;
            employee.Email=emp.Email;
			employee.Password=emp.Password;

            _context.SaveChanges();
            return RedirectToAction("Index");

			//return Content($"{emp.Name} .... {emp.Email} .... {emp.Password}"); // هاي الداتا ليست في الداتا بيس وانما الداتا الي جاي من الفورم وهي الداتا الجديدة
		}
        public IActionResult Delete(int id)
        {    
            var employee = _context.Employees.Find(id); // find is better => cuz it search via P.K (id)
            // OR : var employee = context.Employees.FirstOrDefault(emp => emp.Id == id);

            _context.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("Index"); // بتوديني عالاكشن الي اسمه اندكس , موجود هيو هون فوق 
            //return Content($"{id}"); // بس اكبس على الاي دي الي رقمه 1 رح يرجعلي 1
        }
    }
}
