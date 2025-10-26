using BlazorAssiment.Models;

namespace BlazorAssiment.Services
{
    public class ElectricMeterService : IElectricMeterService
    {
        public async Task<MeterQueryResponse> QueryMeterAsync(MeterQueryRequest request)
        {
            await Task.Delay(1000);

            return new MeterQueryResponse
            {
                Success = true,
                AccountNumber = "100166299",
                AccountUsed = "2522",
                Adjustments = 19.6m,
                AdjustmentsDetails = new List<AdjustmentDetail>
                {
                    new AdjustmentDetail
                    {
                        AdjustmentName = "رسوم جباية نفايات",
                        AdjustmentRemains = "0.0",
                        AdjustmentValue = "19.6"
                    }
                },
                CustomerName = "صالح محمد",
                MeterNumber = request.MeterNo,
                QueryRef = $"28{DateTime.Now.Ticks % 1000000}",
                RechargeAmount = request.Amount - 19.6m,
                Timestamp = DateTime.Now
            };
        }

        public async Task<PaymentResponse> ProcessPaymentAsync(MeterQueryRequest request)
        {
            await Task.Delay(1500);

            decimal effectiveAmount = request.Amount - 19.6m;
            decimal units = Math.Round(effectiveAmount / 3.5m, 2);

            var token = $"{GenerateRandomDigits(4)}-{GenerateRandomDigits(4)}-{GenerateRandomDigits(4)}-{GenerateRandomDigits(4)}-{GenerateRandomDigits(4)}";

            return new PaymentResponse
            {
                Success = true,
                MeterNumber = request.MeterNo,
                CustomerName = "صالح محمد",
                AccountNumber = "100166299",
                AmountPaid = request.Amount,
                UnitsAdded = units,
                Token = token,
                ReferenceNumber = $"rtr_{DateTime.Now:yyyyMMdd}_{DateTime.Now.Ticks % 1000}",
                AccountUsed = "2522",
                Timestamp = DateTime.Now
            };
        }

        private string GenerateRandomDigits(int length)
        {
            var random = new Random();
            return string.Join("", Enumerable.Range(0, length).Select(_ => random.Next(0, 10)));
        }
    }
}
