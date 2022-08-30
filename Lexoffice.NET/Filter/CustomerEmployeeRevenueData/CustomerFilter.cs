namespace Lexoffice.NET.Filter.CustomerEmployeeRevenueData;

public class CustomerFilter : IFilterCustomerEmployeeRevenueData
{
    private readonly string _customerName;

    public CustomerFilter(string customerName)
    {
        _customerName = customerName;
    }

    public IEnumerable<DataContracts.CustomerEmployeeRevenueData> Filter(
        IEnumerable<DataContracts.CustomerEmployeeRevenueData> source)
    {
        return source.Where(data => data.Customer.Equals(_customerName, StringComparison.OrdinalIgnoreCase));
    }
}