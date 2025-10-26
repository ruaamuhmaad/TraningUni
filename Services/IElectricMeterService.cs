using BlazorAssiment.Models;

namespace BlazorAssiment.Services
{
    public interface IElectricMeterService
    {
        Task<MeterQueryResponse> QueryMeterAsync(MeterQueryRequest request);
        Task<PaymentResponse> ProcessPaymentAsync(MeterQueryRequest request);
    }
}
