using Microsoft.EntityFrameworkCore;
using System.Net;
using VoucherManagement.Command.Interfaces;
using VoucherManagement.DatabaseContext;
using VoucherManagement.Entities;

namespace VoucherManagement.Command.Services
{
    public class CreateVoucher : ICreateVoucher
    {
        private readonly VoucherContext _voucherContext;
        public CreateVoucher(VoucherContext voucherContext)
        {
            _voucherContext = voucherContext;
        }
        public async Task<Voucher> AddAsync(Voucher voucher)
        {
            ValidateVoucherAsync(voucher);

            var code = await _voucherContext.Vouchers.FirstOrDefaultAsync(x => x.Code == voucher.Code);

            if (code != null)
            {
                throw new ArgumentException("Voucher code already exists.")
                {
                    Data = { ["StatusCode"] = HttpStatusCode.Conflict }
                };
            }

            var result = await _voucherContext.AddAsync(voucher);

            await _voucherContext.SaveChangesAsync();

            return result.Entity;
        }

        private void ValidateVoucherAsync(Voucher voucher)
        {
            if (voucher.DiscountType == Enums.DiscountType.NotDefined)
            {
                throw new InvalidOperationException("Voucher discount type is required.")
                {
                    Data = { ["StatusCode"] = HttpStatusCode.BadRequest }
                };
            }

            /*
             * TO-D0: Add more validation here
             */
        }

    }
}
