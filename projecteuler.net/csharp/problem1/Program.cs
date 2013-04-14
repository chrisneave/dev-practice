using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace problem1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The sum of all numbers from 1 to 1000 that are divisible by 3 and 5 is:");
            Console.WriteLine(SumMultiples(3, 5, 1000).ToString());
            Console.ReadLine();
        }

        protected static int SumMultiples(int multiple1, int multiple2, int maxValue)
        {
            if (multiple1 <= 0 || multiple1 >= maxValue)
                throw new ArgumentException("multiple1 must be between 0 and " + maxValue.ToString(), "multiple");

            if (multiple2 <= 0 || multiple2 >= maxValue)
                throw new ArgumentException("multiple2 must be between 0 and " + maxValue.ToString(), "multiple");

            int sum = 0;

            for (int i = multiple1; i < maxValue; i++)
            {
                if (i % multiple1 == 0 || i % multiple2 == 0)
                    sum += i;
            }

            return sum;
        }

        public class Tests
        {
            [Fact]
            public void SumMultiples_ValidInputs_SumsAllMultiples()
            {
                // Arrange
                // Act
                // Assert
                Assert.Equal<int>(233168, Program.SumMultiples(3, 5, 1000));
                Assert.Equal<int>(23, Program.SumMultiples(3, 5, 10));
            }
        }
    }
}
