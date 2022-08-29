using Lexoffice.NET.DataContracts.Invoice;

namespace Lexoffice.NET.DataContracts;

public class CustomerAccountRevenueData
{
    public int Year { get; init; }
    public string Customer { get; init; } = null!;
    public int Account { get; init; }
    public decimal Revenue { get; init; }

    public static IEnumerable<CustomerAccountRevenueData> FromInvoiceItems(IEnumerable<InvoiceItem> invoiceItems)
    {
        return invoiceItems.Select(item => new CustomerAccountRevenueData
        {
            Year = item.Date.Year,
            Account = item.Account,
            Customer = item.Customer,
            Revenue = item.Price
        });
    }
}