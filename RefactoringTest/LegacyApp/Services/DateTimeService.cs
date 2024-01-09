namespace LegacyApp.Services
{
    using LegacyApp.Services.Contracts;
    using System;

    public class DateTimeService : IDateTimeService
    {
        public DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }
    }
}
