using Lexoffice.NET.DataContracts;

namespace Lexoffice.NET.Filter;

public static class CustomerAccountRevenueDataGrouper
{
    public static IEnumerable<CustomerAccountRevenueData> GroupByCustomerAndAccount(
        this IEnumerable<CustomerAccountRevenueData> customerAccountRevenueDataList)
    {
        return customerAccountRevenueDataList.GroupBy(item => new
            {
                item.Year,
                item.Customer,
                item.Account
            })
            .Select(g => new CustomerAccountRevenueData
            {
                Year = g.Key.Year,
                Customer = g.Key.Customer,
                Account = g.Key.Account,
                Revenue = g.Sum(item => item.Revenue)
            })
            .OrderBy(item => item.Year)
            .ThenBy(item => item.Customer)
            .ThenBy(item => item.Account)
            .ToList();
    }
}