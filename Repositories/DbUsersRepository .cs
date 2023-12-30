using UsersAPI.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.Features;
using UsersAPI.Services;
using UsersAPI.Dtos;
using UsersAPI.Data;

namespace UsersAPI.Repositories
{
    public class DbUsersRepository : IUsersRepository
    {
        private readonly DatabaseConf db;

        public DbUsersRepository(DatabaseConf db)
        {
            this.db = db;
        }

        public IEnumerable<User> GetUsers()
        {
            return db.Users.ToList();
        }
        public User GetUser(int id)
        {
            return db.Users.Where(user => user.Id == id).SingleOrDefault();
        }

        public async Task<string> SendOTP(UserOTP user)
        {
            double t1 = await WeatherApi.GetTempOflocation("iceland");
            double t2 = await WeatherApi.GetTempOflocation("kiel");
            double t3 = await WeatherApi.GetTempOflocation("haifa");

            EmailSender.SendEmail(user.Email, "Your verification code", "Your verification code is: " + t1.ConvertDoubleToString() + t2.ConvertDoubleToString() + t3.ConvertDoubleToString());
            return "success";
        }

        // public void CreateUser(User user)
        // {
        //     users.Add(user);
        // }
    }

}