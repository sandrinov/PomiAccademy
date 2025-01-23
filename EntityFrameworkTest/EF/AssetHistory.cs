using System;
using System.Collections.Generic;

namespace EntityFrameworkTest.EF;

public partial class AssetHistory
{
    public int IdAssetHistory { get; set; }

    public int? IdAsset { get; set; }

    public string? FromOwner { get; set; }

    public string? ToOwner { get; set; }

    public DateTime? TransferDate { get; set; }

    public string? TransactionHash { get; set; }

    public string? AssetGuid { get; set; }

    public virtual Asset? IdAssetNavigation { get; set; }
}
