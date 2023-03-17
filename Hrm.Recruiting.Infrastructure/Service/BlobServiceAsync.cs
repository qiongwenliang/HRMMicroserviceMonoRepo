using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Hrm.Recruiting.ApplicationCore.Contract.Service;
using Hrm.Recruiting.ApplicationCore.Model;
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

        public BlobServiceAsync(BlobServiceClient _blobServiceClient)
        {
            blobServiceClient = _blobServiceClient;
        }


        public Task DeleteFileAsync(string fileName)
        {
            var clientContainer = blobServiceClient.GetBlobContainerClient("recruitingcandidateresumecontainer");
            var clientName = clientContainer.GetBlobClient(fileName);
            return clientName.DeleteAsync();
        }

        public async Task<BlobContent> GetFile(string filePath)
        {
            var fileName = new Uri(filePath).Segments.LastOrDefault();
            //this will give you a file name
            var clientContainer = blobServiceClient.GetBlobContainerClient("recruitingcandidateresumecontainer");
            var clientName = clientContainer.GetBlobClient(fileName);
            if (await clientName.ExistsAsync())
            {
                var download = await clientName.DownloadContentAsync();
                return new BlobContent()
                {
                    Content = download.Value.Content.ToStream(),
                    ContentType = download.Value.Details.ContentType
                };              
            }
            else
            {
                return null;
            }
        }


        public async Task<string> UploadFileAsync(string filePath, string fileName)
        {
            var clientContainer = blobServiceClient.GetBlobContainerClient("recruitingcandidateresumecontainer");
            var clientName = clientContainer.GetBlobClient(fileName);
            await clientName.UploadAsync(filePath);
            return clientName.Uri.AbsoluteUri;
        }
    }
}
