using VoucherManagement.Entities;

namespace VoucherManagement.Command.Interfaces
{
    public interface ICreateVoucher
    {
        Task<Voucher> AddAsync(Voucher voucher);
    }
}
