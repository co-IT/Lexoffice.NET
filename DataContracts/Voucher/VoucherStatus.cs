using Ardalis.SmartEnum;

namespace Lexoffice.NET.DataContracts.Voucher;

public class VoucherStatus : SmartFlagEnum<VoucherStatus>
{
    public static readonly VoucherStatus Open = new("open", 1);
    public static readonly VoucherStatus Draft = new("draft", 2);
    public static readonly VoucherStatus Paid = new("paid", 4);
    public static readonly VoucherStatus Paidoff = new("paidoff", 8);
    public static readonly VoucherStatus Voided = new("voided", 16);

    private VoucherStatus(string name, int value) : base(name, value)
    {
    }
}