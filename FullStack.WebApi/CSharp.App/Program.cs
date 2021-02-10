
using CSharp.Domain;
using System;
using System.Collections.Generic;

namespace CSharp.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("App is running....press any key to exit");
            Console.ReadLine();

            Generate();
        }

        public static List<Invoice> Generate()
        {
            DateTime date = DateTime.Today;
            var DaysOfMonths = new DateTime(date.Year, date.Month, 1);

            List<Invoice> collectionOfInvoices = new List<Invoice>();

            InvoiceItem item1 = new InvoiceItem("Testing", 154.32m, 2.5m);
            InvoiceItem item2 = new InvoiceItem("Planning", 230.00m, 2.5m);
            InvoiceItem item3 = new InvoiceItem("Development", 450.95m, 4m);
            InvoiceItem item4 = new InvoiceItem("Hosting", 450.95m, 2.5m);
            InvoiceItem item5 = new InvoiceItem("App Deployment", 450.95m, 6.2m);
            InvoiceItem item6 = new InvoiceItem("Security Patches", 450.95m, 4.2m);
            InvoiceItem item7 = new InvoiceItem("Maintain of Website", 300.95m, 5m);
            InvoiceItem item8 = new InvoiceItem("Maintain of Website", 300.95m, 5m);
            InvoiceItem item9 = new InvoiceItem("Maintain of Website", 300.95m, 5m);
            InvoiceItem item10 = new InvoiceItem("Maintain of Website", 300.95m, 5m);
            InvoiceItem item11 = new InvoiceItem("Maintain of Website", 300.95m, 5m);
            InvoiceItem item12 = new InvoiceItem("Maintain of Website", 300.95m, 5m);

            var itemList = new List<InvoiceItem>();
            itemList.Add(item1);
            itemList.Add(item2);
            itemList.Add(item3);
            itemList.Add(item4);
            itemList.Add(item5);
            itemList.Add(item6);
            itemList.Add(item7);
            itemList.Add(item8);
            itemList.Add(item9);
            itemList.Add(item10);
            itemList.Add(item11);
            itemList.Add(item12);


            Invoice invoice1 = new Invoice(0, "IC001", itemList);
            Invoice invoice2 = new Invoice(1, "IC002", itemList);
            Invoice invoice3 = new Invoice(2, "IC003", itemList);
            Invoice invoice4 = new Invoice(3, "IC004", itemList);
            Invoice invoice5 = new Invoice(4, "IC005", itemList);
            Invoice invoice6 = new Invoice(5, "IC006", itemList);
            Invoice invoice7 = new Invoice(6, "IC007", itemList);
            Invoice invoice8 = new Invoice(7, "IC008", itemList);
            Invoice invoice9 = new Invoice(8, "IC009", itemList);
            Invoice invoice10 = new Invoice(9, "IC0010", itemList);
            Invoice invoice11 = new Invoice(10, "IC0011", itemList);
            Invoice invoice12 = new Invoice(11, "IC0012", itemList);
            collectionOfInvoices.Add(invoice1);
            collectionOfInvoices.Add(invoice2);
            collectionOfInvoices.Add(invoice3);
            collectionOfInvoices.Add(invoice4);
            collectionOfInvoices.Add(invoice5);
            collectionOfInvoices.Add(invoice6);
            collectionOfInvoices.Add(invoice7);
            collectionOfInvoices.Add(invoice8);
            collectionOfInvoices.Add(invoice9);
            collectionOfInvoices.Add(invoice10);
            collectionOfInvoices.Add(invoice11);
            collectionOfInvoices.Add(invoice12);

            foreach (var invoice in collectionOfInvoices)
            {
                Console.WriteLine(invoice.ReferenceNumber + "\n"
                    + invoice.Date.ToShortDateString() + invoice.DueDate.ToShortDateString());

                foreach (var item in invoice.InvoiceItems)
                {
                    Console.WriteLine(item.Description);
                    Console.WriteLine("R " + item.ItemTotalAmount);

                }
            }

            return collectionOfInvoices;
        }
    }
}
