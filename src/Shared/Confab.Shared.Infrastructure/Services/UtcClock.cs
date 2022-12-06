using Confab.Shared.Abstractions;
using System;

namespace Confab.Shared.Infrastructure
{
    internal class UtcClock : IClock
    {
        public DateTime CurrentDate() => DateTime.UtcNow;
    }
}
