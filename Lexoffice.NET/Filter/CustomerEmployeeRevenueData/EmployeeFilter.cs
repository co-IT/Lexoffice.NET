namespace Lexoffice.NET.Filter.CustomerEmployeeRevenueData;

public class EmployeeFilter : IFilterCustomerEmployeeRevenueData
{
    private readonly string _employeeName;

    public EmployeeFilter(string employeeName)
    {
        _employeeName = employeeName;
    }

    public IEnumerable<DataContracts.CustomerEmployeeRevenueData> Filter(
        IEnumerable<DataContracts.CustomerEmployeeRevenueData> source)
    {
        return source.Where(data => data.Employee.Equals(_employeeName, StringComparison.OrdinalIgnoreCase));
    }
}