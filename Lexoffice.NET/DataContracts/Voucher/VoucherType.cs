using Ardalis.SmartEnum;

namespace Lexoffice.NET.DataContracts.Voucher;

public class VoucherType : SmartFlagEnum<VoucherType>
{
    public static readonly VoucherType Invoice = new("invoice", 1);
    public static readonly VoucherType Creditnote = new("creditnote", 2);

    private VoucherType(string name, int value) : base(name, value)
    {
    }
}