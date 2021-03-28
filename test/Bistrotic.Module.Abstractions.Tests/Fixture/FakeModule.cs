namespace Bistrotic.Module.Abstractions.Tests.Fixture
{
    using Bistrotic.Infrastructure.Modules;
    using Bistrotic.Infrastructure.Modules.Definitions;

    using Microsoft.Extensions.Configuration;

    public class Fake1ServiceModule : ServiceModule
    {
        public Fake1ServiceModule(IConfiguration configuration) : base(configuration)
        {
        }
    }

    public class Fake2ServiceModule : ServiceModule
    {
        public Fake2ServiceModule(IConfiguration configuration) : base(configuration)
        {
        }
    }

    public class Fake3ServiceModule : ServiceModule
    {
        public Fake3ServiceModule(IConfiguration configuration) : base(configuration)
        {
        }
    }

    public class Fake4ServiceModule : ServiceModule
    {
        public Fake4ServiceModule(IConfiguration configuration) : base(configuration)
        {
        }
    }

    public class Fake5ServiceModule : ServiceModule
    {
        public Fake5ServiceModule(IConfiguration configuration) : base(configuration)
        {
        }
    }

    public class Fake6ServiceModule : ServiceModule
    {
        public Fake6ServiceModule(IConfiguration configuration) : base(configuration)
        {
        }
    }
}