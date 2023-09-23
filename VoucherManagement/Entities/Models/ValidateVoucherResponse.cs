using VoucherManagement.Enums;

namespace VoucherManagement.Entities.Models
{
    public class ValidateVoucherResponse
    {
        public decimal Discount { get; set; }
        public DiscountType DiscountType { get; set; }
    }
}
