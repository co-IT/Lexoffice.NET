using Newtonsoft.Json;

namespace Lexoffice.NET.DataContracts.Invoice;

public class InvoiceLineUnitPrice
{
    [JsonProperty("currency")] public string Currency { get; set; }

    [JsonProperty("netAmount")] public decimal NetAmount { get; set; }

    [JsonProperty("grossAmount")] public decimal GrossAmount { get; set; }

    [JsonProperty("taxRatePercentage")] public decimal TaxRatePercentage { get; set; }
}