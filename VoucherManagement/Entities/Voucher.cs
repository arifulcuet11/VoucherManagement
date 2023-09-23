using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using VoucherManagement.CustomValidators;
using VoucherManagement.Enums;

namespace VoucherManagement.Entities
{
    [Index(nameof(Code), IsUnique = true)]
    public class Voucher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Code { get; set; }
        [Required]
        public DiscountType DiscountType { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "The discount value must be greater than or equal to 0.")]
        public decimal Discount { get; set; }
        public bool IsUsed { get; set; }
        [Required]
        [FutureDate]
        public DateTime ExpirationDate { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "The discount value must be greater than or equal to 1.")]
        public int MaxUsageCount { get; set; }
        public int UsageCount { get; set; }
        public bool IsSingleUse { get; set; }

        public Voucher()
        {
            this.IsUsed = false;
            this.IsActive = true;
            this.UsageCount = 0;
            this.IsSingleUse = false;
        }

    }
}
