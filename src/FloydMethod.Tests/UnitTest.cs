using System;
using Xunit;
using FloydMethod;

namespace FloydMethod.Tests
{
    public class UnitTest
    {
        [Fact]
        public void Test_01_FuelPositiveNumber()
        {
            string input = "8.5";
            double? result = Program.Test_FuelValue(input);
            Assert.NotNull(result);
            Assert.Equal(8.5, result.Value);
        }

        [Fact]
        public void Test_02_FuelNegatibeNumber()
        {
            string input = "-5";
            double? result = Program.Test_FuelValue(input);
            Assert.Null(result);
        }

        [Fact]
        public void Test_03_ShuyaPointValidInput()
        {
            string input = "3";
            int n = 10;
            int? result = Program.Test_ShuyaPoint(input, n);
            Assert.NotNull(result);
            Assert.Equal(3, result.Value);
        }

        [Fact]
        public void Test_04_ShuyaPointInvalidInput()
        {
            string input = "15"; 
            int n = 10;
            int? result = Program.Test_ShuyaPoint(input, n);
            Assert.Null(result);
        }
    }
}