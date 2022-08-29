using System.Collections.Immutable;
using Lexoffice.NET.DataContracts.Invoice;
using Lexoffice.NET.DataContracts.Voucher;

namespace Lexoffice.NET;

public interface IInvoiceService
{
    Task<IImmutableList<Voucher>> GetAllInvoiceVouchersAsync();

    Task<IImmutableList<Invoice>> GetInvoicesAsync(IImmutableList<Voucher> vouchers);
}