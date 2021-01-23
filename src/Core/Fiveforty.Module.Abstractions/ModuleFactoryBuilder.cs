namespace Fiveforty.Module
{
    using System;
    using System.Collections.Generic;

    public class ModuleFactoryBuilder
    {
        private List<Func<IModuleDefinitionLoader>> _definitionLoaders = new List<Func<IModuleDefinitionLoader>>();

        public ModuleFactoryBuilder AddDefinitionLoader(Func<IModuleDefinitionLoader> loader)
        {
            _definitionLoaders.Add(loader);
            return this;
        }

        public IModuleFactory Build()
        {
            return new ModuleLoader(_definitionLoaders);
        }
    }
}