using CalorieTrackerCookBookApp.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CalorieTrackerCookBookApp.Controllers
{
    public class BaseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BaseController(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); // Fix potential null assignment
        }

        // Example method with nullable return type
        public User? GetCurrentUser()
        {
            // Get the user's ID from the current user's claims
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // If userId is null, return null to fix the nullable warning
            if (userId == null)
            {
                return null; // Fix nullable return warning
            }

            // Return the user from the database whose Id matches the userId
            return _context.Users.FirstOrDefault(u => u.Id.ToString() == userId);
        }

        // Example method accessing potential null safely
        public string? GetUserEmail()
        {
            var currentUser = GetCurrentUser();
            return currentUser?.Email; // Use null-conditional to avoid potential null issues
        }
    }
}
