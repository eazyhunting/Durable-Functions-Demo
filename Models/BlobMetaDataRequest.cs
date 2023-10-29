using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class BlobMetaDataRequest
    {
        public string BlobName { get; set; }
        public StorageRequest StorageRequest { get; set; }
    }
}
