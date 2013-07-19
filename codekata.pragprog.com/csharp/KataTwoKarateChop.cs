using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace codekata.katatwo
{
    /// <summary>
    /// Iterative
    /// </summary>
    public class MethodOne
    {
        internal static int Chop(int p, int[] source)
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == p) return i;
            }

            return -1;
        }
    }

    /// <summary>
    /// Binary search
    /// </summary>
    public class MethodTwo
    {
        internal static int Chop(int p, int[] source)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class MethodTestBase
    {
        protected Func<int, int[], int> _method;

        [Fact]
        public void ArrayIsEmpty_ReturnsMinusOne()
        {
            // Arrange
            int[] source = new int[] { };
            // Act
            int result = _method(3, source);
            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void ArrayContainsOneElementAndSearchMisses_ReturnsMinusOne()
        {
            // Arrange
            int[] source = new int[] { 1 };
            // Act
            int result = _method(3, source);
            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void ArrayContainsOneElementAndSearchHits_ReturnsZero()
        {
            // Arrange
            int[] source = new int[] { 1 };
            // Act
            int result = _method(1, source);
            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void ArrayContainsThreeElementsAndSearchHits_ReturnsCorrectIndex()
        {
            // Arrange
            int[] source = new int[] { 1, 3, 5 };
            // Act
            // Assert
            Assert.Equal(0, _method(1, source));
            Assert.Equal(1, _method(3, source));
            Assert.Equal(2, _method(5, source));
        }

        [Fact]
        public void ArrayContainsThreeElementsAndSearchMisses_ReturnsMinusOne()
        {
            // Arrange
            int[] source = new int[] { 1, 3, 5 };
            // Act
            // Assert
            Assert.Equal(-1, _method(0, source));
            Assert.Equal(-1, _method(2, source));
            Assert.Equal(-1, _method(4, source));
            Assert.Equal(-1, _method(6, source));
        }

        [Fact]
        public void ArrayContainsFourElementsAndSearchHits_ReturnsCorrectIndex()
        {
            // Arrange
            int[] source = new int[] { 1, 3, 5, 7 };
            // Act
            // Assert
            Assert.Equal(0, _method(1, source));
            Assert.Equal(1, _method(3, source));
            Assert.Equal(2, _method(5, source));
            Assert.Equal(3, _method(7, source));
        }

        [Fact]
        public void ArrayContainsFourElementsAndSearchMisses_ReturnsMinusOne()
        {
            // Arrange
            int[] source = new int[] { 1, 3, 5, 7 };
            // Act
            // Assert
            Assert.Equal(-1, _method(0, source));
            Assert.Equal(-1, _method(2, source));
            Assert.Equal(-1, _method(4, source));
            Assert.Equal(-1, _method(6, source));
            Assert.Equal(-1, _method(8, source));
        }
    }

    public class MethodOneTest : MethodTestBase
    {
        public MethodOneTest()
        {
            _method = new Func<int, int[], int>(MethodOne.Chop);
        }
    }

    public class MethodTwoTest : MethodTestBase
    {
        public MethodTwoTest()
        {
            _method = new Func<int, int[], int>(MethodTwo.Chop);
        }
    }
}
