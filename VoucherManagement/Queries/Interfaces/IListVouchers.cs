namespace VoucherManagement.Queries.Interfaces
{
    public interface IListVouchers
    {
        Task<List<string>> ListAsync();
    }   
}
