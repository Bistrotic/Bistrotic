﻿namespace Fiveforty.Infrastructure.Tests.Fixture
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ITestInterface
    {
    }

    public interface ITestInterface<T> : ITestInterface
    {
    }

    public interface ITestInterfaceNoClass
    {
    }

    public class TestConcrete1 : ITestInterface
    {
    }

    public class TestConcrete2 : ITestInterface
    {
    }

    public class TestConcrete3 : ITestInterface
    {
    }

    public class TestConcrete4 : ITestInterface<int>
    {
    }

    public class TestConcrete5 : ITestInterface<string>
    {
    }
}