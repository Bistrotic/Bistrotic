﻿namespace Fiveforty.Module
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IModuleFactory
    {
        Task<IEnumerable<IModule>> GetModules();
    }
}