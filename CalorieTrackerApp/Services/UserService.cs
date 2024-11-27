using CalorieTrackerCookBookApp.Services.Interfaces;
using CalorieTrackerCookBookApp.Models;
using CalorieTrackerCookBookApp.Data;
using System.Collections.Generic;
using System.Linq;

namespace CalorieTrackerCookBookApp.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context; // Reference to your database context
        private readonly List<UserCreateViewModel> _users = new List<UserCreateViewModel>();
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Method to get all users
        public IEnumerable<UserViewModel> GetAllUsers()
        {
            // Assuming you have a `User` entity and a `UserViewModel` model
            return _context.Users
                           .Select(user => new UserViewModel
                           {
                               Id = user.Id,
                               CurrentUsername = user.CurrentUsername,
                               UserEmail = user.UserEmail
                           })
                           .ToList();
        }

        // Method to get a user by ID
        public UserViewModel GetUserById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            return new UserViewModel
            {
                Id = user.Id,
                CurrentUsername = user.CurrentUsername,
                UserEmail = user.UserEmail
            };
        }

        // Method to get user data for editing
        public UserCreateViewModel GetUserForEdit(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.FullId == userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            return new UserCreateViewModel
            {
                Id = user.FullId,
                CurrentUsername = user.CurrentUsername,
                UserEmail = user.UserEmail
            };
        }

        // Method to create a new user
        public void CreateUser(UserCreateViewModel model)
        {
            var newUser = new ApplicationUser
            {
                CurrentUsername = model.CurrentUsername,
                UserEmail = model.UserEmail,
                Password = model.Password // Make sure to hash the password before saving!
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        // Method to update user information
        public void UpdateUser(UserCreateViewModel userViewModel)
        {
            var user = _context.Users.Find(userViewModel);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.CurrentUsername = user.CurrentUsername;
            user.UserEmail = user.UserEmail;
            // Update other fields as needed

            _context.Users.Update(user);
            _context.SaveChanges();
        }

        // Method to delete a user
        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
