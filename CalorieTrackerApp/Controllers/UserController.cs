using CalorieTrackerCookBookApp.Models;
using CalorieTrackerCookBookApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTrackerCookBookApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var users = _userService.GetAllUsers();
            return View(users);
        }

        public IActionResult Details(string id)
        {
            int userId = int.Parse(id);
            var user = _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _userService.CreateUser(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            int userId = int.Parse(id);
            var user = _userService.GetUserForEdit(userId);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(UserCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _userService.UpdateUser(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(string id)
        {
            int userId = int.Parse(id);
            _userService.DeleteUser(userId);
            return RedirectToAction("Index");
        }
    }
    
}
