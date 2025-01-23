using System;
using System.Collections.Generic;

namespace EntityFrameworkTest.EF;

public partial class AssetDocument
{
    public int IdAssetDocument { get; set; }

    public string AssetDocumentName { get; set; } = null!;

    public string AssetDocumentHash { get; set; } = null!;

    public string AssetDocumentType { get; set; } = null!;

    public int? AssetContainer { get; set; }

    public string? AssetDocumentEditor { get; set; }

    public string? AssetDocumentEditorUserName { get; set; }

    public string? TransactionAddDocumenthash { get; set; }

    public string? AssetDocumentGuid { get; set; }

    public string? AssetContainerGuid { get; set; }

    public virtual Asset? AssetContainerNavigation { get; set; }
}
