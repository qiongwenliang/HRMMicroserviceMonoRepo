using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Hrm.Recruiting.ApplicationCore.Contract.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Recruiting.Infrastructure.Service
{
    public class BlobServiceAsync : IBlobServiceAsync
    {
        private readonly BlobServiceClient blobServiceClient;

        public BlobServiceAsync(BlobServiceClient blobServiceClient)
        {
            this.blobServiceClient = blobServiceClient;
        }


        public Task DeleteFileAsync(string fileName)
        {
            var clientContainer = blobServiceClient.GetBlobContainerClient("eg.resumecontainer");
            var clientName = clientContainer.GetBlobClient(fileName);
            return clientName.DeleteAsync();
        }

        public async Task<BlobInfo> GetFile(string fileName)
        {
            var clientContainer = blobServiceClient.GetBlobContainerClient("eg.resumecontainer");
            var clientName = clientContainer.GetBlobClient(fileName);
            var result = await clientName.DownloadContentAsync();
            return null;
        }

        public async Task UploadFileAsync(string filePath, string fileName)
        {
            var clientContainer = blobServiceClient.GetBlobContainerClient("eg.resumecontainer");
            var clientName = clientContainer.GetBlobClient(fileName);
            await clientName.UploadAsync(filePath, new BlobHttpHeaders
            {
                ContentType = "file"
            });
        }
    }
}
