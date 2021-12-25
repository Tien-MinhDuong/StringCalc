using Program;
using System;
using Xunit;

namespace TestProject
{
    public class UnitTest1
    {

        private void CalculateString(string numbers, int expectedResult)
        {
            var result = StringCalc.Add(numbers);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Given_Empty_String_Returns_Zero()
        {
            CalculateString("", 0);
        }

        [Fact]
        public void Given_String_1_Returns_1()
        {
            CalculateString("1", 1);
        }

        [Fact]
        public void Given_String_1_2_Returns_3()
        {
            CalculateString("1,2", 3);
        }

        [Fact]
        public void Given_String_1_2_3_4_5_6_7_Returns_28()
        {
            CalculateString("1,2,3,4,5,6,7", 28);
        }

        [Fact]
        public void Given_String_1_NewLine2_3_Returns_6()
        {
            CalculateString("1\n2,3", 6);
        }

        [Fact]
        public void Given_Input_With_Delimeter_1_2_Returns_3()
        {
            CalculateString("//;\n1;2", 3);
        }

        [Fact]
        public void Given_Negative_Number_Throw_Exception()
        {
            Assert.Throws<Exception>(() => { CalculateString("-1", 0); });
        }

        [Fact]
        public void Given_Negative_Number_Throw_Exception_With_Message()
        {
            try
            {
                CalculateString("-1", 0);
            }
            catch (Exception ex)
            {
                Assert.Contains("negatives not allowed", ex.Message);
                Assert.Contains("-1", ex.Message);
            }

        }

        [Fact]
        public void Given_Negative_Number_Throw_Exception_Specifying_Invalid_Numbers()
        {
            try
            {
                CalculateString("-1,-2", 0);
            }
            catch (Exception ex)
            {
                Assert.Contains("negatives not allowed", ex.Message);
                Assert.Contains("-1", ex.Message);
                Assert.Contains("-2", ex.Message);
            }
        }

        [Fact]
        public void Ignore_Number_Larger_Than_One_Thousand()
        {
            CalculateString("2,1001", 2);
        }

        [Fact]
        public void Delimiters_Of_Any_Lenght()
        {
            CalculateString("//[***]\n1***2***3", 6);
        }

        [Fact]
        public void Multiple_Delimiters_Of_Any_Lenght()
        {
            CalculateString("//[*][%]\n1*2%3", 6);
        }

        [Fact]
        public void Multiple_Delimiters_Of_Multiple_Lenght()
        {
            CalculateString("//[**][%%]\n1**2%%3", 6);
        }

        [Fact]
        public void Multiple_Delimiters()
        {
            var delimiters = StringCalc.GetMultipleDelimiters("//[*][%]\n1*2%3");
            Assert.Contains("*", delimiters);
            Assert.Contains("%", delimiters);
        }
    }
}
