using Microsoft.AspNetCore.Http;
using Sign.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sign.Services
{
    public class FileManagerService: IFileManagerService
    {

        public async Task<ResponseBase> UploadFiles(IFormFile file)
        {
            var response = new ResponseBase();
            var fileName = "";
            using (var stream = file.OpenReadStream())
            {
                var folderPath = AppContext.BaseDirectory;
                fileName = await GetFilePath(folderPath, file.FileName);
                await WriteFileAsync(stream, fileName);
            }
            response.Code = (int)StatusCodeEnum.Success;
            response.IsSuccess = true;
            response.Msg = "Upload Success!";
            response.Result = fileName;
            return response;
        }

        private async Task<string> GetFilePath(string folderPath, string filename)
        {
            var folder = DateTime.Now.ToString("yyyyMMdd");

            var path = Path.Combine(folderPath, "UserSigns", folder);
            var exists = Directory.Exists(path);
            if (!exists)
            {
                Directory.CreateDirectory(path);
            }

            return Path.Combine(path, filename);
        }
        /// <summary>
        /// 写文件导到磁盘
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="path">文件保存路径</param>
        /// <returns></returns>
        private async Task<int> WriteFileAsync(Stream stream, string path)
        {
            const int FILE_WRITE_SIZE = 84975;//写出缓冲区大小
            int writeCount = 0;
            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write, FILE_WRITE_SIZE, true))
            {
                byte[] byteArr = new byte[FILE_WRITE_SIZE];
                int readCount = 0;
                while ((readCount = await stream.ReadAsync(byteArr, 0, byteArr.Length)) > 0)
                {
                    await fileStream.WriteAsync(byteArr, 0, readCount);
                    writeCount += readCount;
                }
            }
            return writeCount;
        }
    }
    public interface IFileManagerService
    {
        Task<ResponseBase> UploadFiles(IFormFile file);
    }
}
