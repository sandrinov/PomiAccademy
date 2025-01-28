using System;
using System.Collections.Generic;

namespace DungeonAccademy.DAL.EF;

public partial class ItemsXroom
{
    public int IdItemsXrooms { get; set; }

    public int IdRoom { get; set; }

    public int IdItem { get; set; }

    public bool IsCollectable { get; set; }

    public int? IdCharacter { get; set; }

    public virtual Item IdItemNavigation { get; set; } = null!;

    public virtual Room IdRoomNavigation { get; set; } = null!;
}
