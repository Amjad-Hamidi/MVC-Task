using CRUD.Data;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext context;

        public UsersController(ApplicationDbContext context) 
        {
            this.context = context;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user) 
        {
            context.Users.Add(user);
            context.SaveChanges();

            return RedirectToAction(nameof(Login));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user) 
        { 
            var checkUser=context.Users.Where(x=>x.UserName==user.UserName && x.Password==user.Password).ToList();

            if (checkUser.Any())
            {
                return RedirectToAction("Index","Employees"); /*بتوديني على الاكشن اندكس في الكونترولر امبلوييز*/
            }
            ViewBag.Error = "invalid username / password";

            return View(user); /* اذا فشلت الاف , خذ معك بيانات اليوزر الي هو كتبها وفشلت*/

            
        }


        public IActionResult InactiveUsers()
        {
            // استرجاع جميع المستخدمين غير النشطين
            var inactiveUsers = context.Users.Where(u => u.IsActive == false).ToList();
            foreach (var a in inactiveUsers)
            {
                Console.WriteLine(a.UserName);
            }
            return View(inactiveUsers);
        }

        [HttpPost]
        public IActionResult ActivateUser(Guid userId)
        {
            var user = context.Users.Find(userId);
            if (user != null)
            {
                user.IsActive = true;
                context.SaveChanges();
            }
            return RedirectToAction(nameof(InactiveUsers));
        }


    }
}
