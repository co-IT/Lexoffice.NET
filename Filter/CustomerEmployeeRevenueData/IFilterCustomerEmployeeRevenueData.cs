namespace Lexoffice.NET.Filter.CustomerEmployeeRevenueData;

public interface IFilterCustomerEmployeeRevenueData
{
    IEnumerable<DataContracts.CustomerEmployeeRevenueData> Filter(
        IEnumerable<DataContracts.CustomerEmployeeRevenueData> source);
}