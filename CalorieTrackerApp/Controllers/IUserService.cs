﻿using CalorieTrackerCookBookApp.Models;

namespace CalorieTrackerCookBookApp.Controllers
{
    public interface IUserService
    {
        IEnumerable<UserViewModel> GetAllUsers();
        UserViewModel GetUserById(int id);
        UserCreateViewModel GetUserForEdit(int id);
        void CreateUser(UserCreateViewModel model);
        void UpdateUser(UserCreateViewModel model);
        void DeleteUser(int id);
    }
}