namespace Bistrotic.SalesHistory.Repositories
{
    using Bistrotic.SalesHistory.Common.Application.States;

    public class EfSalesHistory : SalesHistoryState
    {
        public int Id { get; set; }
    }
}