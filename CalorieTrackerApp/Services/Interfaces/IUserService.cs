using CalorieTrackerCookBookApp.Models;

namespace CalorieTrackerCookBookApp.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserViewModel> GetAllUsers();
        UserViewModel GetUserById(int id);
        UserCreateViewModel GetUserForEdit(int userId);
        void CreateUser(UserCreateViewModel model);
        void UpdateUser(UserCreateViewModel userViewModel);
        void DeleteUser(int id);
    }
}