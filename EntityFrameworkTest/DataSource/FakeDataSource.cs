using EntityFrameworkTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTest.DataSource
{
    public class FakeDataSource : IDataSource
    {
        private List<Asset_DTO> _assets;
        public FakeDataSource()
        {
            _assets = new List<Asset_DTO>();
            _assets.Add(new Asset_DTO()
            {
                AssetName = "asset1",
                AssetType = "type 1",
                IdAsset = 1,
                Documents = new List<AssetDocument_DTO>()
                {
                    new AssetDocument_DTO()
                    {
                        IdAssetDocument = 1,
                        AssetDocumentName = "Test doc 1.pdf",
                        AssetDocumentType = ".pdf"
                    }
                }
            });
            _assets.Add(new Asset_DTO()
            {
                AssetName = "asset2",
                AssetType = "type 1",
                IdAsset = 2,
                Documents = new List<AssetDocument_DTO>()
                {
                    new AssetDocument_DTO()
                    {
                        IdAssetDocument = 2,
                        AssetDocumentName = "Test doc 2.pdf",
                        AssetDocumentType = ".pdf"
                    }
                }
            });
            _assets.Add(new Asset_DTO()
            {
                AssetName = "asset3",
                AssetType = "type 1",
                IdAsset = 3,
                Documents = new List<AssetDocument_DTO>()
                {
                    new AssetDocument_DTO()
                    {
                        IdAssetDocument = 3,
                        AssetDocumentName = "Test doc 5.pdf",
                        AssetDocumentType = ".pdf"
                    }
                }
            });
            _assets.Add(new Asset_DTO()
            {
                AssetName = "asset4",
                AssetType = "type 2",
                IdAsset = 4,
                Documents = new List<AssetDocument_DTO>()
                {
                    new AssetDocument_DTO()
                    {
                        IdAssetDocument = 4,
                        AssetDocumentName = "Test doc 66.txt",
                        AssetDocumentType = ".txt"
                    }
                }
            });
            _assets.Add(new Asset_DTO()
            {
                AssetName = "asset5",
                AssetType = "type 3",
                IdAsset = 5,
                Documents = new List<AssetDocument_DTO>()
                {
                    new AssetDocument_DTO()
                    {
                        IdAssetDocument = 5,
                        AssetDocumentName = "Test doc 97.pdf",
                        AssetDocumentType = ".pdf"
                    },
                    new AssetDocument_DTO()
                    {
                        IdAssetDocument = 6,
                        AssetDocumentName = "Test doc 1327.excl",
                        AssetDocumentType = ".excl"
                    }

                }
            });
        }

        public List<Asset_DTO> GetAllAssets()
        {
            return _assets;
        }

        public Asset_DTO GetAssetByID(int assetID)
        {
           return  _assets.Where(a => a.IdAsset == assetID).FirstOrDefault();
        }

        public List<AssetDocument_DTO> GetAssetDocumentsByAssetID(int assetID)
        {
            List<AssetDocument_DTO> resultList = new List<AssetDocument_DTO>();

            Asset_DTO asset = _assets.Where(a => a.IdAsset == assetID).FirstOrDefault();
            if (asset != null)
                resultList = asset.Documents;
            return resultList;
        }

        public List<Asset_DTO> GetPagedAssets(int pagenumber, int pagesize)
        {
            throw new NotImplementedException();
        }
    }
}
