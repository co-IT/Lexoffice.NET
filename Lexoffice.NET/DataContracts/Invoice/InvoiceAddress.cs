using Newtonsoft.Json;

namespace Lexoffice.NET.DataContracts.Invoice;

public class InvoiceAddress
{
    [JsonProperty("contactId")] public string ContactId { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("supplement")] public string Supplement { get; set; }

    [JsonProperty("street")] public string Street { get; set; }

    [JsonProperty("city")] public string City { get; set; }

    [JsonProperty("zip")] public string Zip { get; set; }

    [JsonProperty("countryCode")] public string CountryCode { get; set; }
}