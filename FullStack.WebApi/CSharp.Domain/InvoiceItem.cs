using System;

namespace CSharp.Domain
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public decimal Hours { get; set; }
        public decimal ItemTotalAmount { get; }

        public InvoiceItem(string description, decimal rate, decimal hours)
        {
            this.Description = description;
            this.Rate = rate;
            this.Hours = hours;
            this.ItemTotalAmount = this.GetItemTotalAmount();
        }

        private decimal GetItemTotalAmount()
        {
            return Math.Round(this.Rate * this.Hours, 2);
        }



    }
}
