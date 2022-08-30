using Newtonsoft.Json;

namespace Lexoffice.NET.DataContracts.Invoice;

public class InvoiceLineItem
{
    [JsonProperty("type")] public string Type { get; set; }
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("description")] public string Description { get; set; }
    [JsonProperty("quantity")] public decimal Quantity { get; set; }
    [JsonProperty("unitName")] public string UnitName { get; set; }
    [JsonProperty("unitPrice")] public InvoiceLineUnitPrice UnitPrice { get; set; }
    [JsonProperty("discountPercentage")] public decimal DiscountPercentage { get; set; }
    [JsonProperty("lineItemAmount")] public decimal LineItemAmount { get; set; }
}