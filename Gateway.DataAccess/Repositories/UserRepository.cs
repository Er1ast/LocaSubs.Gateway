﻿using Gateway.Models.Account;
using Microsoft.EntityFrameworkCore;

namespace Gateway.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly GatewayDbContext _dbContext;

    public UserRepository(GatewayDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task CreateUserAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> ExistAsync(string login)
    {
        return await _dbContext.Users.AnyAsync(user => user.Login == login);
    }

    public async Task<User> GetUserAsync(string login, string password)
    {
        var existingUser = await _dbContext.Users.FirstOrDefaultAsync(user => user.Login == login && user.Password == password);

        return existingUser!;
    }

    public async Task<IReadOnlyCollection<User>> GetUsers()
    {
        return await _dbContext.Users.ToListAsync();
    }
}