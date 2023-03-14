using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Recruiting.ApplicationCore.Contract.Service
{
    public interface IBlobServiceAsync
    {
        Task UploadFileAsync(string filePath, string fileName);
        Task DeleteFileAsync(string fileName);
        Task<BlobInfo> GetFile(string fileName);
    }
}
