using System;
using UsersAPI;
using Xunit;

namespace UsersAPITests
{
    public class ExtensionsTests
    {
        [Fact]
        public void TestConvertDoubleToString()
        {
            // Arrange
            double number1 = 123.456;
            double number2 = 0;
            double number3 = -1;
            double number4 = -10;
            double number5 = 15.2;

            // Act
            string result1 = number1.ConvertDoubleToString();
            string result2 = number2.ConvertDoubleToString();
            string result3 = number3.ConvertDoubleToString();
            string result4 = number4.ConvertDoubleToString();
            string result5 = number5.ConvertDoubleToString();

            // Assert
            Assert.Equal("123", result1);
            Assert.Equal("00", result2);
            Assert.Equal("01", result3);
            Assert.Equal("10", result4);
            Assert.Equal("15", result5);
        }

        [Fact]
        public void TestSelectRandomNumber()
        {
            // Arrange
            int n = 10;

            // Act
            int result = n.SelectRandomNumber();

            // Assert
            Assert.InRange(result, 1, n);
        }
    }
}
