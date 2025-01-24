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
        public static Asset_DTO From_EF_to_DTO(EntityFrameworkTest.EF.Asset ef_asset)
        {
            Asset_DTO result_dto = new Asset_DTO();

            result_dto.IdAsset = ef_asset.IdAsset;
            result_dto.AssetName = ef_asset.AssetName;
            result_dto.AssetType = ef_asset.AssetType;

            return result_dto;
        }
    }
}
