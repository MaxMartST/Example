using System;

namespace Example.Infrastructure.Clock
{
    public interface IClock
    {
        DateTime Now();

        DateTime Today();
    }
}
