using EntityFrameworkTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTest.Mappers
{
    public class Mapper
    {
        public static Asset_DTO From_EFAsset_to_DTOAsset(EntityFrameworkTest.EF.Asset ef_asset)
        {
            Asset_DTO result_dto = new Asset_DTO();

            result_dto.IdAsset = ef_asset.IdAsset;
            result_dto.AssetName = ef_asset.AssetName;
            result_dto.AssetType = ef_asset.AssetType;

            return result_dto;
        }
        public static AssetDocument_DTO From_EFAssetDocument_to_DTOAssetDocument(EntityFrameworkTest.EF.AssetDocument ef_asset)
        {
            AssetDocument_DTO result_dto = new AssetDocument_DTO();
            result_dto.IdAssetDocument = ef_asset.IdAssetDocument;
            result_dto.AssetDocumentName = ef_asset.AssetDocumentName;
            result_dto.AssetDocumentType = ef_asset.AssetDocumentType;

            return result_dto;
        }
    }
}
