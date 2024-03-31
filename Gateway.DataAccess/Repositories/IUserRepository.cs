﻿using Gateway.Models.Account;

namespace Gateway.DataAccess.Repositories;

public interface IUserRepository
{
    Task<IReadOnlyCollection<User>> GetUsers();
    Task<User> GetUserAsync(string login, string password);
    Task CreateUserAsync(User user);
    Task<bool> ExistAsync(string login);
}