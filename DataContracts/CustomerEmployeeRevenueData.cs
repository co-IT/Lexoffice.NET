using Lexoffice.NET.DataContracts.Invoice;

namespace Lexoffice.NET.DataContracts;

public class CustomerEmployeeRevenueData
{
    public int Year { get; set; }
    public string Customer { get; set; }
    public string Employee { get; set; }
    public decimal Revenue { get; set; }

    public static IEnumerable<CustomerEmployeeRevenueData> FromInvoiceItems(List<InvoiceItem> invoiceItems)
    {
        foreach (var item in invoiceItems)
        {
            if (item.Employee.Number == 99999)
                continue;

            var customerAccountRevenueData = new CustomerEmployeeRevenueData
            {
                Year = item.Date.Year,
                Customer = item.Customer,
                Employee = item.Employee.Name,
                Revenue = item.Price
            };

            yield return customerAccountRevenueData;
        }
    }
}