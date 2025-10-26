using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BlazorAssiment.Models
{
    public class MeterQueryRequest
    {
        [Required(ErrorMessage = "رقم العداد مطلوب")]
        public string MeterNo { get; set; } = string.Empty;

        [Required(ErrorMessage = "المبلغ مطلوب")]
        [Range(20, 500, ErrorMessage = "المبلغ يجب أن يكون بين 20 و 500")]
        public decimal Amount { get; set; }
    }
}
