namespace Lexoffice.NET.DataContracts.Invoice;

public record InvoiceItem
{
    internal InvoiceItem(string invoiceId, string customer, DateTime date, Employee employee, int account,
        string description, decimal amountHours, decimal price)
    {
        InvoiceId = invoiceId;
        Customer = customer;
        Date = date;
        Employee = employee;
        Account = account;
        Description = description;
        AmountHours = amountHours;
        Price = price;
    }

    public string InvoiceId { get; }
    public string Customer { get; }
    public DateTime Date { get; }
    public Employee Employee { get; }
    public int Account { get; }
    public string Description { get; }
    public decimal AmountHours { get; }
    public decimal Price { get; }
}