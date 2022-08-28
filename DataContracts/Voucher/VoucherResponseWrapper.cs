using Newtonsoft.Json;

namespace Lexoffice.NET.DataContracts.Voucher;

public class VoucherResponseWrapper
{
    [JsonProperty("content")] public List<Voucher> Content { get; set; }

    [JsonProperty("first")] public bool First { get; set; }

    [JsonProperty("last")] public bool Last { get; set; }

    [JsonProperty("totalPages")] public int TotalPages { get; set; }

    [JsonProperty("totalElements")] public int TotalElements { get; set; }

    [JsonProperty("numberOfElements")] public int NumberOfElements { get; set; }

    [JsonProperty("size")] public int Size { get; set; }

    [JsonProperty("number")] public int Number { get; set; }

    [JsonProperty("sort")] public List<VoucherResponseSort> Sort { get; set; }
}