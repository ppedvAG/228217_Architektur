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
    }
}
