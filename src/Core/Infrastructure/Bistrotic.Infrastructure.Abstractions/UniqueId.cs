namespace Fiveforty.Infrastructure
{
    using System;

    public class UniqueId
    {
        public static string Create() =>
            Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 22);
    }
}