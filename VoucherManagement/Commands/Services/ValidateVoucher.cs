using Microsoft.EntityFrameworkCore;
using System.Net;
using VoucherManagement.Command.Interfaces;
using VoucherManagement.DatabaseContext;
using VoucherManagement.Entities;
using VoucherManagement.Entities.Models;
using VoucherManagement.Enums;

namespace VoucherManagement.Command.Services
{
    public class ValidateVoucher : IValidateVoucher
    {
        private readonly VoucherContext _voucherContext;
        public ValidateVoucher(VoucherContext voucherContext)
        {
            _voucherContext = voucherContext;
        }
        public async Task<ValidateVoucherResponse> ValidateAsync(string code)
        {

            var voucher = await _voucherContext.Vouchers.FirstOrDefaultAsync(x => x.Code == code);

            if (voucher == null)
            {
                throw new ArgumentException("Voucher code does not exist.")
                {
                    Data = { ["StatusCode"] = HttpStatusCode.NotFound }
                };
            }

            Validate(voucher);

            await UpdateVoucherAsync(voucher);

            return new ValidateVoucherResponse()
            {
                DiscountType = voucher.DiscountType,
                Discount = voucher.Discount
            };
        }

        private Task UpdateVoucherAsync(Voucher voucher)
        {
            /*
              * Update voucher table based on reuirement and usages    
              * All logic here
              */
            return Task.CompletedTask;
        }

        private void Validate(Voucher voucher)
        {

            if (voucher.ExpirationDate < DateTime.UtcNow)
            {
                throw new InvalidOperationException("Voucher has expired.")
                {
                    Data = { ["StatusCode"] = HttpStatusCode.BadRequest }
                };
            }
            else if (!voucher.IsActive)
            {
                throw new InvalidOperationException("Voucher is not active.")
                {
                    Data = { ["StatusCode"] = HttpStatusCode.BadRequest }
                };
            }
            else if (voucher.MaxUsageCount <= voucher.UsageCount)
            {
                throw new InvalidOperationException("Voucher has reached its maximum usage count.")
                {
                    Data = { ["StatusCode"] = HttpStatusCode.BadRequest }
                };
            }

            /*
             * TO-DO: Add more validation here
             */
        }

    }
}
