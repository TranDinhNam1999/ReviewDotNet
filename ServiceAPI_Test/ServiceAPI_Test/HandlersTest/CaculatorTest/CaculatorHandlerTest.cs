using ServiceAPI.v1.Handlers.Caculator;

namespace ServiceAPI_Test.Handlers.Caculator
{
    public class CaculatorHandlerTest
    {
        [Theory]
        [InlineData(1 ,2, 6)]
        [InlineData(1, 3, 8)]
        [InlineData(1, 4, 10)]
        [InlineData(1, 5, 12)]
        [InlineData(1, 6, 14)]
        public async Task SumShouldReturnValue(int a, int b, int expected)
        {
            // Arrange
            //int a = 6, b = 8, expected = 10;
            // Act
            int sum = CaculatorHandler.SumHandler(a, b);
            // Assert
            Assert.Equal(expected, sum);
        }
    }
}
