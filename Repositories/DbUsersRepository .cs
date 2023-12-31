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
            IEnumerable<City> cities = db.City.ToList();
            int size = cities.Count();

            //select random number between 1 and list size
            int randIndex1 = size.SelectRandomNumber();
            int randIndex2 = size.SelectRandomNumber();
            int randIndex3 = size.SelectRandomNumber();

            //get city with index
            string city1 = cities.FirstOrDefault(city => city.Id == randIndex1).CityName;
            string city2 = cities.FirstOrDefault(city => city.Id == randIndex2).CityName;
            string city3 = cities.FirstOrDefault(city => city.Id == randIndex3).CityName;

            //get city temperature - call weatherAPI
            double t1 = await WeatherApi.GetTempOflocation(city1);
            double t2 = await WeatherApi.GetTempOflocation(city2);
            double t3 = await WeatherApi.GetTempOflocation(city3);


            EmailSender.SendEmail(user.Email, "Your verification code", "Your verification code is: " + t1.ConvertDoubleToString() + t2.ConvertDoubleToString() + t3.ConvertDoubleToString());
            return "success";
        }
    }

}