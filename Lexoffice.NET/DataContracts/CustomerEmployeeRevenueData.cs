using Lexoffice.NET.DataContracts.Invoice;

namespace Lexoffice.NET.DataContracts;

public class CustomerEmployeeRevenueData
{
    public int Year { get; init; }
    public string Customer { get; init; } = null!;
    public string Employee { get; init; } = null!;
    public decimal Revenue { get; init; }

    public static IEnumerable<CustomerEmployeeRevenueData> FromInvoiceItems(IEnumerable<InvoiceItem> invoiceItems)
    {
        return invoiceItems
            .Where(item => item.Employee.Number != 99999)
            .Select(item => new CustomerEmployeeRevenueData
            {
                Year = item.Date.Year,
                Customer = item.Customer,
                Employee = item.Employee.Name,
                Revenue = item.Price
            });
    }
}