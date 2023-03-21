using Azure.Storage.Blobs.Models;
using Hrm.Recruiting.ApplicationCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Recruiting.ApplicationCore.Contract.Service
{
    public interface IBlobServiceAsync
    {
        Task<string> UploadFileAsync(string filePath, string fileName);
        Task DeleteFileAsync(string fileName);
        Task<BlobContent> GetFile(string filePath);
    }
}
