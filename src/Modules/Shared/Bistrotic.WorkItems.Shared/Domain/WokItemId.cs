namespace Bistrotic.WorkItems.Domain
{
    using Bistrotic.Domain.ValueTypes;

    public class WokItemId : BusinessId
    {
        public WokItemId()
        {
        }

        public WokItemId(string value) : base(value)
        {
        }

        public WokItemId(BusinessId value) : base(value)
        {
        }
    }
}