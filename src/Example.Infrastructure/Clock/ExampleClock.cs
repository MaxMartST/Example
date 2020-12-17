using System;

namespace Example.Infrastructure.Clock
{
    public class ExampleClock : IClock
    {
        public DateTime Now()
        {
            return DateTime.UtcNow;
        }

        public DateTime Today()
        {
            return DateTime.UtcNow.Date;
        }
    }
}
