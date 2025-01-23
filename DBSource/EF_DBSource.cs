using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSource
{
    public class EF_DBSource
    {
        public List<Asset_DTO> GetAllAssets()
        {

        }

        public Asset_DTO GetAssetByID(int assetID)
        {

        }

        public List<Asset_DTO> GetPagedAssets(int pagenumber, int pagesize)
        {

        }
        public List<AssetDocument_DTO> GetAssetDocumentsByAssetID(int assetID)
        {

        }


    }

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
    public class AssetDocument_DTO
    {
        public int IdAssetDocument { get; set; }

        public string AssetDocumentName { get; set; }

        public string AssetDocumentType { get; set; }
    }
}
