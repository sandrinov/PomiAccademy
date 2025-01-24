using EntityFrameworkTest.EF;
using EntityFrameworkTest.Mappers;
using EntityFrameworkTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTest.DataSource
{
    public class EF_DataSource : IDataSource
    {
        private AvioAssetChainDBContext _context;

        public EF_DataSource()
        {
            _context = new AvioAssetChainDBContext();
        }
        public List<Asset_DTO> GetAllAssets()
        {
            List<Asset_DTO> result_list = new List<Asset_DTO>();

            List<Asset> assets = _context.Assets.ToList();

            foreach (Asset asset in assets)
            {
                result_list.Add(Mapper.From_EF_to_DTO(asset));
            }
            return result_list;
        }

        public Asset_DTO GetAssetByID(int assetID)
        {
            throw new NotImplementedException();
        }

        public List<AssetDocument_DTO> GetAssetDocumentsByAssetID(int assetID)
        {
            throw new NotImplementedException();
        }

        public List<Asset_DTO> GetPagedAssets(int pagenumber, int pagesize)
        {
            throw new NotImplementedException();
        }
    }
}
