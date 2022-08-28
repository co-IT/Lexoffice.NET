namespace Lexoffice.NET.Filter.CustomerEmployeeRevenueData;

public class YearFilter : IFilterCustomerEmployeeRevenueData
{
    private readonly string _year;

    public YearFilter(string year)
    {
        _year = year;
    }

    public IEnumerable<DataContracts.CustomerEmployeeRevenueData> Filter(
        IEnumerable<DataContracts.CustomerEmployeeRevenueData> source)
    {
        return source.Where(data => data.Year.ToString() == _year);
    }
}