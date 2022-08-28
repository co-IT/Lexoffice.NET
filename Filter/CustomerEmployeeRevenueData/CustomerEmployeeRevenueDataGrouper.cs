namespace Lexoffice.NET.Filter.CustomerEmployeeRevenueData;

public static class CustomerEmployeeRevenueDataGrouper
{
    public static IEnumerable<DataContracts.CustomerEmployeeRevenueData> GroupByCustomerAndEmployee(
        this IEnumerable<DataContracts.CustomerEmployeeRevenueData> customerAccountRevenueDataList)
    {
        return customerAccountRevenueDataList.GroupBy(item => new
            {
                item.Year,
                item.Customer,
                item.Employee
            })
            .Select(g => new DataContracts.CustomerEmployeeRevenueData
            {
                Year = g.Key.Year,
                Customer = g.Key.Customer,
                Employee = g.Key.Employee,
                Revenue = g.Sum(item => item.Revenue)
            })
            .OrderBy(item => item.Year)
            .ThenBy(item => item.Customer)
            .ThenBy(item => item.Employee);
    }
}