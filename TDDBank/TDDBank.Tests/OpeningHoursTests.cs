using Microsoft.QualityTools.Testing.Fakes;

namespace TDDBank.Tests
{
    public class OpeningHoursTest
    {
        [Theory]
        [InlineData(2023, 7, 03, 10, 29, false)]//mo
        [InlineData(2023, 7, 03, 10, 30, true)]//mo
        [InlineData(2023, 7, 03, 10, 31, true)] //mo
        [InlineData(2023, 7, 03, 18, 59, true)] //mo
        [InlineData(2023, 7, 03, 19, 00, false)] //mo
        [InlineData(2023, 7, 08, 13, 0, true)] //sa
        [InlineData(2023, 7, 08, 16, 0, false)] //sa
        [InlineData(2023, 7, 08, 13, 0, true)] //sa
        //[InlineData(2023, 7, 09, 20, 0, false)] //so
        public void OpeningHours_IsOpen(int y, int M, int d, int h, int m, bool result)
        {
            var dt = new DateTime(y, M, d, h, m, 0);
            var oh = new OpeningHours();

            Assert.Equal(result, oh.IsOpen(dt));
        }


        [Fact]
        public void OpeningHours_IsWeekend()
        {
            var oh = new OpeningHours();

            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 07, 03);
                Assert.False(oh.IsWeekend());//mo
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 07, 04);
                Assert.False(oh.IsWeekend());//di
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 07, 05);
                Assert.False(oh.IsWeekend());//mi
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 07, 06);
                Assert.False(oh.IsWeekend());//do
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 07, 07);
                Assert.False(oh.IsWeekend());//fr
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 07, 08);
                Assert.True(oh.IsWeekend());//sa
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 07, 09);
                Assert.True(oh.IsWeekend());//so
            }
        }

        [Fact]
        public void GetTimesFromFile_ShouldReturn12_WhenFileContainsEnte()
        {
            using (ShimsContext.Create())
            {
                // Arrange
                // Create a shim for File.ReadAllText to return a test value
                System.IO.Fakes.ShimFile.ReadAllTextString = (path) =>
                {
                    return "This is a test file containing ente";
                };

                var sut = new OpeningHours(); 

                // Act
                int result = sut.GetTimesFromFile();

                // Assert
                Assert.Equal(12, result);
            }
        }

        [Fact]
        public void GetTimesFromFile_ShouldReturn0_WhenFileDoesNotContainEnte()
        {
            using (ShimsContext.Create())
            {
                // Arrange
                System.IO.Fakes.ShimFile.ReadAllTextString = (path) =>
                {
                    return "This  is a test file without 🦆";
                };

                var sut = new OpeningHours();

                // Act
                int result = sut.GetTimesFromFile();

                // Assert
                Assert.Equal(0, result);
            }
        }
    }
}
