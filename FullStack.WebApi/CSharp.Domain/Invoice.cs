using System;
using System.Collections.Generic;

namespace CSharp.Domain
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; }

        public Invoice(int id, string referenceNumber, List<InvoiceItem> invoiceItems)
        {
            this.Id = id;
            this.Date = GetDate();
            this.ReferenceNumber = referenceNumber;
            this.DueDate = GetDueDate();

            this.InvoiceItems = invoiceItems;

            this.TotalAmount = GetTotalAmount(); ;
        }
        private DateTime GetDate()
        {
            var dayInNextMonth = this.Date.AddMonths(1).AddDays(-6);
            var FiveDaysEndOfMonth = new DateTime(dayInNextMonth.Year, dayInNextMonth.Month, DateTime.DaysInMonth(dayInNextMonth.Year, dayInNextMonth.Month));
            return FiveDaysEndOfMonth;
        }

        private DateTime GetDueDate()
        {
            var dayInNextMonth = this.Date.AddMonths(1);
            var lastDayOfNextMonth = new DateTime(dayInNextMonth.Year, dayInNextMonth.Month, DateTime.DaysInMonth(dayInNextMonth.Year, dayInNextMonth.Month));
            return lastDayOfNextMonth;
        }

        private decimal GetTotalAmount()
        {
            var result = 0m;

            foreach (var invoiceItem in this.InvoiceItems)
            {
                var invItemTotal = invoiceItem.ItemTotalAmount;
                result = result + invItemTotal;
            }

            return result;
        }
    }

}
