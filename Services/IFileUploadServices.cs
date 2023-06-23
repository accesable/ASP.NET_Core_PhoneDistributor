namespace WebApplication_Slicone_Supplier.Services
{
    public interface IFileUploadServices
    {
        void DeleteFile(string fileName);
        Task<string> UploadFileAsync(IFormFile file);
    }
}
