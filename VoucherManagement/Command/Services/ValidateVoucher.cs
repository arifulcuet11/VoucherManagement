using VoucherManagement.Command.Interfaces;
using VoucherManagement.Entities.Models;
using VoucherManagement.Enums;

namespace VoucherManagement.Command.Services
{
    public class ValidateVoucher : IValidateVoucher
    {
        public ValidateVoucher() { }
        public async Task<ValidateVoucherResponse> ValidateAsync(string code)
        {
            /*
             * TO-D0: Implement this method
             * All logic here
             */

            return new ValidateVoucherResponse()
            {
               DiscountType = DiscountType.Percentage,
               Discount = 10
            };
        }
    }
}
