namespace Bistrotic.DataIntegrations.Common.Domain.ValueTypes
{
    public class DataIntegrationField
    {
        public FieldType FieldType { get; set; }
        public bool Mandatory { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}