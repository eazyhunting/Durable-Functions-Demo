

using Azure.Storage.Blobs.Models;

namespace Models
{
    public class BlobStorageResult
    {
        public string Uri { get; set; }
        public BlobProperties Properties { get; set; }

    }
}
