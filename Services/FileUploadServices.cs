namespace WebApplication_Slicone_Supplier.Services
{
    public class FileUploadServices : IFileUploadServices
    {
        private readonly IWebHostEnvironment _env;
        public FileUploadServices(IWebHostEnvironment env)
        {
            _env = env;
        }
        public async Task<string> UploadFileAsync(IFormFile file)
        {
            var filePath = Path.Combine(_env.WebRootPath,"images/PhoneModels/",file.FileName);
            using var fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return file.FileName;
        }
        

        public void DeleteFile(string fileName)
        {
            // Files to be deleted
            string authorsFile = fileName;

            try
            {
                // Check if file exists with its full path
                if (File.Exists(Path.Combine(_env.WebRootPath, "images/PhoneModels/", authorsFile)))
                {
                    // If file found, delete it
                    File.Delete(Path.Combine(_env.WebRootPath, "images/PhoneModels/", authorsFile));

                }

            }
            catch (IOException ioExp)
            {

            }
        }
    }
}
