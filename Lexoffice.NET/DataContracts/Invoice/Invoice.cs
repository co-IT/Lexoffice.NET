using Newtonsoft.Json;

namespace Lexoffice.NET.DataContracts.Invoice;

public class Invoice
{
    [JsonProperty("id")] public string Id { get; set; }
    [JsonProperty("organizationId")] public string OrganizationId { get; set; }
    [JsonProperty("createdDate")] public string CreatedDate { get; set; }
    [JsonProperty("updatedDate")] public string UpdatedDate { get; set; }
    [JsonProperty("version")] public decimal Version { get; set; }
    [JsonProperty("language")] public string Language { get; set; }
    [JsonProperty("archived")] public bool Archived { get; set; }
    [JsonProperty("voucherStatus")] public string VoucherStatus { get; set; }
    [JsonProperty("voucherNumber")] public string VoucherNumber { get; set; }
    [JsonProperty("voucherDate")] public string VoucherDate { get; set; }
    [JsonProperty("dueDate")] public string DueDate { get; set; }
    [JsonProperty("address")] public InvoiceAddress Address { get; set; }
    [JsonProperty("lineItems")] public List<InvoiceLineItem> LineItems { get; set; }
}