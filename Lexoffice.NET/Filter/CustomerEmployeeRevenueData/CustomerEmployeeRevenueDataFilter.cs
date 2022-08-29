namespace Lexoffice.NET.Filter.CustomerEmployeeRevenueData;

public static class CustomerEmployeeRevenueDataFilter
{
    public static IEnumerable<DataContracts.CustomerEmployeeRevenueData> ApplyAllFilters(
        this IEnumerable<DataContracts.CustomerEmployeeRevenueData> source,
        IEnumerable<IFilterCustomerEmployeeRevenueData> filters)
    {
        return filters.Aggregate(source, (current, filter) => filter.Filter(current));
    }
}