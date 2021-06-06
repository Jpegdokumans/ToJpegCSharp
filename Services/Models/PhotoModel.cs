using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Models
{
    public class PhotoModel
    {
        public string Name { get; set; }
        public byte[] Photo { get; set; }
        public CompressionLevel CompressionLevel { get; set; }
    }
}
