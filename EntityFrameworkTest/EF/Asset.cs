using System;
using System.Collections.Generic;

namespace EntityFrameworkTest.EF;

public partial class Asset
{
    public int IdAsset { get; set; }

    public string AssetName { get; set; } = null!;

    public string AssetIdentifier { get; set; } = null!;

    public string AssetType { get; set; } = null!;

    public string AssetShortDescription { get; set; } = null!;

    public string AssetLongDescription { get; set; } = null!;

    public string? AssetOwner { get; set; }

    public byte[]? ImageData { get; set; }

    public string? ImageName { get; set; }

    public string? AssetOwnerUserName { get; set; }

    public string? TransactionCreationHash { get; set; }

    public string? AssetGuid { get; set; }

    public string? AssetParentGuid { get; set; }

    public int? IdParentAsset { get; set; }

    public bool? HasNested { get; set; }

    public string? TransactionNestedAssetHash { get; set; }

    public virtual ICollection<AssetDocument> AssetDocuments { get; set; } = new List<AssetDocument>();

    public virtual ICollection<AssetHistory> AssetHistories { get; set; } = new List<AssetHistory>();

    public virtual Asset? IdParentAssetNavigation { get; set; }

    public virtual ICollection<Asset> InverseIdParentAssetNavigation { get; set; } = new List<Asset>();
}
