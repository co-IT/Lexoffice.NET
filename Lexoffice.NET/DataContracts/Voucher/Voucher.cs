using Newtonsoft.Json;

namespace Lexoffice.NET.DataContracts.Voucher;

public class Voucher
{
    [JsonProperty("id")] public string Id { get; set; }

    [JsonProperty("voucherType")] public string VoucherType { get; set; }

    [JsonProperty("voucherStatus")] public string VoucherStatus { get; set; }

    [JsonProperty("voucherNumber")] public string VoucherNumber { get; set; }

    [JsonProperty("voucherDate")] public DateTime VoucherDate { get; set; }

    [JsonProperty("createdDate")] public DateTime CreatedDate { get; set; }

    [JsonProperty("updatedDate")] public DateTime UpdatedDate { get; set; }

    [JsonProperty("dueDate")] public DateTime DueDate { get; set; }

    [JsonProperty("contactId")] public string ContactId { get; set; }

    [JsonProperty("contactName")] public string ContactName { get; set; }

    [JsonProperty("totalAmount")] public double TotalAmount { get; set; }

    [JsonProperty("openAmount")] public double OpenAmount { get; set; }

    [JsonProperty("currency")] public string Currency { get; set; }

    [JsonProperty("archived")] public bool Archived { get; set; }
}