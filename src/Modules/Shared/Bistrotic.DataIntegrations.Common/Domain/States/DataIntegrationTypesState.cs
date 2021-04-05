namespace Bistrotic.DataIntegrations.Common.Domain.States
{
    using System;
    using System.Collections.Generic;

    using Bistrotic.DataIntegrations.Common.Domain.ValueTypes;

    public class DataIntegrationTypesState
    {
        private IEnumerable<DataIntegrationField> Fields = Array.Empty<DataIntegrationField>();
        public string Name { get; set; } = string.Empty;
    }
}