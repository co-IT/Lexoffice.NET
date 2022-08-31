# Lexoffice.NET
.NET library for the accounting software [lexoffice](https://www.lexoffice.de/)

# Features
Lexoffice.NET does currently support the following lexoffice API endpoints:
- [Invoices Endpoint](https://developers.lexoffice.io/docs/#invoices-endpoint)
- [Vouchers Endpoint](https://developers.lexoffice.io/docs/#vouchers-endpoint)
- Filter and group functionality for invoices

# Getting Started
To use this library you have to generate an API Key for your lexoffice Account. 

You can generate an API Key [here](https://app.lexoffice.de/addons/public-api). If you have any problems getting the key you can follow the steps in [these instructions](https://app.lexoffice.de/addons/public-api) by lexoffice.

# Usage
First you have to create a new instance of LexofficeService with your API token like this:

```csharp
var token = "Your-Api-Token";
var lexofficeService = new LexofficeService(token);
```

## Getting all invoice vouchers
```csharp
var vouchers = await lexOfficeService.GetAllInvoiceVouchersAsync();
```

## Getting all invoices
To get all invoices all vouchers have to be loaded first. Then the invoice can be queried for each voucher like this:
```csharp
var vouchers = await lexOfficeService.GetAllInvoiceVouchersAsync();
var invoices = await lexOfficeService.GetInvoicesAsync(vouchers);
```
## Further Functions
Lexoffice.NET also provides filter and group functionality to allow for easy statistical analysis of invoices. The following code examples assume that you have already loaded all invoices.

### Getting and working with the revenue grouped by year, customer and employee

#### Grouping

The following code will sum the revenue for each employee for a given customer in a given year
```csharp
// Extract all the lines from each invoice
var invoiceItems = invoices.GetInvoiceItems();

// Group each line by year, customer and employee. Sum the revenue
var customerEmployeeRevenueData = CustomerEmployeeRevenueData.FromInvoiceItems(invoiceItems.ToList());
var groupedCustomerEmployeeRevenueData = customerEmployeeRevenueData.GroupByCustomerAndEmployee();
```

#### Filters

The library offers 3 filters to more easily work with CustomerEmployeeRevenueData:
- YearFilter
- EmployeeFilter
- CustomerFilter

You can use and combine these filters for detailed analyzations. In this example we want the revenue `John` made for `Example Ltd.` in `2020`:

```csharp
var filters = new List<IFilterCustomerEmployeeRevenueData>
{
    new EmployeeFilter("John"),
    new CustomerFilter("Example Ltd."),
    new YearFilter("2020")
};

var filteredData = groupedCustomerEmployeeRevenueData.ApplyAllFilters(filters);
```

