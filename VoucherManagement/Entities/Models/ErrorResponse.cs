namespace VoucherManagement.Entities.Models
{
    public class ErrorResponse
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public Error Error { get; set; }
    }

    public class Error
    {
        public string Message { get; set; }
        public string Details { get; set; }
    }
}
