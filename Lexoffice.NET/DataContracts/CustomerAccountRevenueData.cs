using Lexoffice.NET.DataContracts.Invoice;

namespace Lexoffice.NET.DataContracts;

public class CustomerAccountRevenueData
{
    public int Year { get; set; }
    public string Customer { get; set; }
    public int Account { get; set; }
    public decimal Revenue { get; set; }

    public static IEnumerable<CustomerAccountRevenueData> FromInvoiceItems(List<InvoiceItem> invoiceItems)
    {
        foreach (var item in invoiceItems)
        {
            var customerAccountRevenueData = new CustomerAccountRevenueData
            {
                Year = item.Date.Year,
                Account = item.Account,
                Customer = item.Customer,
                Revenue = item.Price
            };

            yield return customerAccountRevenueData;
        }
    }
}