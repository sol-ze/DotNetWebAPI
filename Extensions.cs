using UsersAPI.Dtos;
using UsersAPI.Models;

namespace UsersAPI
{
    public static class Extensions
    {
        public static UserDto AsDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                CreationDate = user.CreationDate
            };
        }
        //This method converts double to strings and remove all digits after the dot 
        public static String ConvertDoubleToString(this double number)
        {
            //if number is negative convert it to positive
            if (number < 0)
            {
                number *= -1;
            }
            String str = number + "";

            if (number < 10)
            {
                str = "0" + str;
            }

            int dotIndex = str.IndexOf('.');
            if (dotIndex > 0)
            {
                str = str[..dotIndex];
            }
            return str;

        }
        public static int SelectRandomNumber(this int n)
        {
            Random random = new();
            // Generate a random number between 1 and n
            return random.Next(1, n + 1);

        }
    }

}