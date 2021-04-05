﻿namespace Bistrotic.SalesHistory.Common.Application.States
{
    using System;

    public class SalesHistoryState
    {
        public string CustomerId { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public DateTimeOffset InvoiceDate { get; set; }
        public string InvoiceId { get; set; } = string.Empty;
        public string ItemId { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public string SalesId { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
    }
}