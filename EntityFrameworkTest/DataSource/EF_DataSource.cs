using EntityFrameworkTest.EF;
using EntityFrameworkTest.Mappers;
using EntityFrameworkTest.Models;
using Microsoft.EntityFrameworkCore;
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
                result_list.Add(Mapper.From_EFAsset_to_DTOAsset(asset));
            }
            return result_list;
        }

        public Asset_DTO GetAssetByID(int assetID)
        {
            Asset_DTO result_dto = null;
            Asset asset = _context.Assets.Where(a=>a.IdAsset == assetID).FirstOrDefault();
            if (asset != null)
                result_dto = Mapper.From_EFAsset_to_DTOAsset(asset);

            return result_dto;
        }

        public List<AssetDocument_DTO> GetAssetDocumentsByAssetID(int assetID)
        {
            List<AssetDocument_DTO> resultList = new List<AssetDocument_DTO>();
            Asset asset = _context.Assets.Include(a=> a.AssetDocuments).Where(a => a.IdAsset == assetID).FirstOrDefault();
            if (asset != null)
            {
                List<AssetDocument> ef_assetdocuments = asset.AssetDocuments.ToList();
                foreach(AssetDocument ef_document in ef_assetdocuments)
                {
                    resultList.Add(Mapper.From_EFAssetDocument_to_DTOAssetDocument(ef_document));
                }
            }               
            return resultList;
        }

        public List<Asset_DTO> GetPagedAssets(int pagenumber, int pagesize)
        {
            throw new NotImplementedException();
        }
    }
}
