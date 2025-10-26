using BlazorAssiment.Models;

namespace BlazorAssiment.Services
{
    public class MeterStateService
    {
        public MeterQueryRequest? CurrentRequest { get; set; }
        public MeterQueryResponse? CurrentResponse { get; set; }
        public PaymentResponse? CurrentPayment { get; set; }
    }
}
