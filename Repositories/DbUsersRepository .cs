using UsersAPI.Models;
using UsersAPI.Services;
using UsersAPI.Dtos;
using UsersAPI.Data;
using Name;
using Microsoft.AspNetCore.Mvc;
using UsersAPI.Tests.Controllers;

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
        public async Task<ApiResponseDto> SendOTP(UserOTP user)
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

            String code = t1.ConvertDoubleToString() + t2.ConvertDoubleToString() + t3.ConvertDoubleToString();

            EmailSender.SendEmail(user.Email, "Your verification code", "Your verification code is: " + code);


            db.UserVerificationCodes.Add(new UserVerificationCode
            {
                Email = user.Email,
                Code = code,
                CreationTime = DateTimeOffset.UtcNow
            });

            db.SaveChanges();

            return new ApiResponseDto { Status = "success" };
        }

        public Boolean UserHasRequestedOTPWithin5Minutes(string email)
        {
            DateTimeOffset now = DateTimeOffset.UtcNow;

            // Calculate the timestamp 5 minutes ago
            DateTimeOffset fiveMinutesAgo = now.AddMinutes(-5);

            // Check if there are any records within the last 5 minutes
            var count = db.UserVerificationCodes
                .Where(u => u.Email == email && u.CreationTime >= fiveMinutesAgo)
                .Count();

            // Return true if count is greater than 0, indicating a request within the last 5 minutes
            return count > 0;

        }
    }

}