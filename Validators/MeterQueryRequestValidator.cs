using BlazorAssiment.Models;
using System.Text.RegularExpressions;

namespace BlazorAssiment.Validators
{
    public class MeterQueryRequestValidator
    {
        public (bool isValid, List<string> errors) Validate(MeterQueryRequest request)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(request.MeterNo))
            {
                errors.Add("رقم العداد مطلوب");
            }
            else if (!Regex.IsMatch(request.MeterNo, @"^\d+$"))
            {
                errors.Add("رقم العداد يجب أن يحتوي على أرقام فقط");
            }
            else if (request.MeterNo.Length != 11 && request.MeterNo.Length != 13)
            {
                errors.Add("رقم العداد يجب أن يكون 11 أو 13 رقم");
            }

            if (request.Amount < 20 || request.Amount > 500)
            {
                errors.Add("المبلغ يجب أن يكون بين 20 و 500");
            }

            return (errors.Count == 0, errors);
        }
    }
}
