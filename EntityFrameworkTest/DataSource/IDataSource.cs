using EntityFrameworkTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTest.DataSource
{
    public interface IDataSource
    {
        List<Asset_DTO> GetAllAssets();
        Asset_DTO GetAssetByID(int assetID);
        List<Asset_DTO> GetPagedAssets(int pagenumber, int pagesize);
        List<AssetDocument_DTO> GetAssetDocumentsByAssetID(int assetID);
    }
}
