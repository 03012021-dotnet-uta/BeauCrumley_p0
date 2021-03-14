using Pizzabox.Domain.IO;
using Xunit;

namespace Pizzabox.Testing.Tests
{
    public class InputTests
    {
        [Fact]
        public void TestIfInputWereValid()
        {
            int[] testRange = {1, 5};
            string testInput = "3";

            var expected = 3;

            var actual = InputReader.ValidateInput(testInput, testRange);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestIfInputWereInvalidInt()
        {
            int[] testRange = {1, 5};
            string testInput = "44";

            var actual = InputReader.ValidateInput(testInput, testRange);

            Assert.True(actual <= testRange[1] && actual >= testRange[0]);
        }
    }
}