using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTest.Models
{
    public class AssetDocument_DTO
    {
        public int IdAssetDocument { get; set; }

        public string AssetDocumentName { get; set; }

        public string AssetDocumentType { get; set; }
    }
}
