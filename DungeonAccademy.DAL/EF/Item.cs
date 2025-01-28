using System;
using System.Collections.Generic;

namespace DungeonAccademy.DAL.EF;

public partial class Item
{
    public int IdItem { get; set; }

    public string ItemName { get; set; } = null!;

    public int ModifyAttack { get; set; }

    public int ModifyDefense { get; set; }

    public int ModifyHealth { get; set; }

    public virtual ICollection<ItemsXroom> ItemsXrooms { get; set; } = new List<ItemsXroom>();
}
