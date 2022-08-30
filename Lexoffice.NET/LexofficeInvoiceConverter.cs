using System.Collections.Immutable;
using Lexoffice.NET.DataContracts.Invoice;

namespace Lexoffice.NET;

public static class LexofficeInvoiceConverter
{
    public static IImmutableList<InvoiceItem> GetInvoiceItems(this IImmutableList<Invoice> invoices)
    {
        return invoices.SelectMany(ConvertInvoice).ToImmutableList();
    }

    private static IImmutableList<InvoiceItem> ConvertInvoice(Invoice invoice)
    {
        var id = invoice.Id;
        var customer = invoice.Address.Name;
        var date = DateTime.Parse(invoice.VoucherDate);

        return invoice
            .LineItems
            .Select(line => ConvertInvoice(id, customer, date, line))
            .ToImmutableList();
    }

    private static InvoiceItem ConvertInvoice(string id, string customer, DateTime date, InvoiceLineItem item)
    {
        var employeeAccountString = item.Name;
        var employeeAccountStringSplit = employeeAccountString.Split("-");
        var employeeInfo = employeeAccountStringSplit[1].Split(":");
        var employeeNumber = int.Parse(employeeInfo[0].Replace(" ", ""));
        var employeeName = employeeInfo[1];
        var trimmedEmployeeName = employeeName.Trim(' ');
        var employee = new Employee(trimmedEmployeeName, employeeNumber);

        var account = int.Parse(employeeAccountStringSplit[0].Replace(" ", ""));
        
        return new InvoiceItem(id, customer, date, employee, account, item.Description,
            item.Quantity, item.LineItemAmount);
    }
}