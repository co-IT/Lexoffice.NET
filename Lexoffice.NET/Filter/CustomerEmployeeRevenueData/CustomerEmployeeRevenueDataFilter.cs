namespace Lexoffice.NET.Filter.CustomerEmployeeRevenueData;

public static class CustomerEmployeeRevenueDataFilter
{
    public static IEnumerable<DataContracts.CustomerEmployeeRevenueData> ApplyAllFilters(
        this IEnumerable<DataContracts.CustomerEmployeeRevenueData> source,
        IEnumerable<IFilterCustomerEmployeeRevenueData> filters)
    {
        var filteredData = source;

        foreach (var filter in filters)
            filteredData = filter.Filter(filteredData);

        return filteredData;
    }
}