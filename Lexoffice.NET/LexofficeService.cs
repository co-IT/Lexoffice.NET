using System.Collections.Immutable;
using Lexoffice.NET.DataContracts.Invoice;
using Lexoffice.NET.DataContracts.Voucher;
using Newtonsoft.Json;
using Polly;

namespace Lexoffice.NET;

public class LexofficeService : IInvoiceService
{
    private readonly HttpClient _client;
    private readonly Random _random = new();

    public LexofficeService(string accessToken)
    {
        _client = new HttpClient
        {
            DefaultRequestHeaders =
            {
                { "Authorization", $"Bearer {accessToken}" },
                { "Accept", "application/json" }
            }
        };
    }

    public async Task<IImmutableList<Voucher>> GetAllInvoiceVouchersAsync()
    {
        var vouchers = new List<Voucher>();

        var type = VoucherType.Invoice;
        var status = VoucherStatus.Paid | VoucherStatus.Paidoff | VoucherStatus.Open | VoucherStatus.Voided;

        var wrapper = await GetVouchersAsync(type, status).ConfigureAwait(false);
        vouchers.AddRange(wrapper.Content);

        for (var page = 1; page < wrapper.TotalPages; page++)
        {
            var pageWrapper = await GetVouchersAsync(type, status, page).ConfigureAwait(false);
            vouchers.AddRange(pageWrapper.Content);
        }

        return vouchers.ToImmutableList();
    }

    public async Task<IImmutableList<Invoice>> GetInvoicesAsync(IImmutableList<Voucher> vouchers)
    {
        var tasks = new List<Task<Invoice>>();
        var throttler = new SemaphoreSlim(3);

        foreach (var voucher in vouchers)
        {
            await throttler.WaitAsync().ConfigureAwait(false);

            tasks.Add(Task.Run(async () =>
            {
                try
                {
                    var retryPolicy = Policy
                        .Handle<HttpRequestException>()
                        .WaitAndRetryAsync(10, retryAttempt =>
                            TimeSpan.FromMilliseconds(Math.Pow(2, retryAttempt) + _random.Next(-1000, 1000))
                        );

                    return await retryPolicy.ExecuteAsync(async () => await GetInvoiceAsync(voucher.Id).ConfigureAwait(false));
                }
                finally
                {
                    throttler.Release();
                }
            }));
        }

        var invoices = await Task.WhenAll(tasks.ToArray()).ConfigureAwait(false);
        
        return invoices.ToImmutableList();
    }

    private async Task<VoucherResponseWrapper> GetVouchersAsync(int type, int status, int page = 0, int size = 250)
    {
        var voucherTypeString = VoucherType.FromValueToString(type).Replace(" ", "");
        var statusTypeString = VoucherStatus.FromValueToString(status).Replace(" ", "");

        var uri = LexofficeApiAddressesBuilder.AllVouchersUri(voucherTypeString, statusTypeString, page, size);

        var response = await _client.GetAsync(uri).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        
        var contents = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        return JsonConvert.DeserializeObject<VoucherResponseWrapper>(contents);
    }

    private async Task<Invoice> GetInvoiceAsync(string id)
    {
        var uri = LexofficeApiAddressesBuilder.InvoiceUri(id);

        var response = await _client.GetAsync(uri).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        
        var contents = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        var jsonSerializerSettings = new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Ignore
        };

        return JsonConvert.DeserializeObject<Invoice>(contents, jsonSerializerSettings);
    }
}