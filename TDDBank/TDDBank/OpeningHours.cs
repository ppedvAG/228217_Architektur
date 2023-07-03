namespace TDDBank
{
    public class OpeningHours
    {
        public bool IsOpen(DateTime dt)
        {
            var openingTime = new TimeSpan(10, 30, 0);
            var closingTime = new TimeSpan(19, 00, 0);
            var saturdayClosingTime = new TimeSpan(14, 00, 0);

            if (dt.DayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }
            else if (dt.DayOfWeek == DayOfWeek.Saturday && dt.TimeOfDay >= openingTime && dt.TimeOfDay < saturdayClosingTime)
            {
                return true;
            }
            else if (dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday && dt.TimeOfDay >= openingTime && dt.TimeOfDay < closingTime)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool IsWeekend()
        {
            return DateTime.Now.DayOfWeek == DayOfWeek.Sunday ||
                   DateTime.Now.DayOfWeek == DayOfWeek.Saturday;
        }
    }
}
