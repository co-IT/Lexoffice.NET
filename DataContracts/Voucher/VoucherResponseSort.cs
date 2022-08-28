using Newtonsoft.Json;

namespace Lexoffice.NET.DataContracts.Voucher;

public class VoucherResponseSort
{
    [JsonProperty("property")] public string Property { get; set; }

    [JsonProperty("direction")] public string Direction { get; set; }

    [JsonProperty("ignoreCase")] public bool IgnoreCase { get; set; }

    [JsonProperty("nullHandling")] public string NullHandling { get; set; }

    [JsonProperty("ascending")] public bool Ascending { get; set; }
}