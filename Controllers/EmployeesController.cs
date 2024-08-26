using CRUD.Data;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace CRUD.Controllers
{
    public class EmployeesController : Controller
    {
        ApplicationDbContext context=new ApplicationDbContext();
        public IActionResult Index()
        {
            var employees = context.Employees.ToList();//to retreive All Employees
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
            context.Employees.Add(emp);
            context.SaveChanges();
            return RedirectToAction("Index"); // بتةوديني عالاكشن الي اسمه اندكس , موجود هيو هون فوق  
        }
    }
}
