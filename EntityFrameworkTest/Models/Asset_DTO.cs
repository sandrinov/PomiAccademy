using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTest.Models
{
    public class Asset_DTO
    {
        public Asset_DTO()
        {
            Documents = new List<AssetDocument_DTO>();
        }
        public int IdAsset { get; set; }

        public string AssetName { get; set; }

        public string AssetType { get; set; }

        public List<AssetDocument_DTO> Documents { get; set; }
    }
}
