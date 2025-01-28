using System;
using System.Collections.Generic;

namespace DungeonAccademy.DAL.EF;

public partial class Room
{
    public int IdRoom { get; set; }

    public string RoomName { get; set; } = null!;

    public int? North { get; set; }

    public int? South { get; set; }

    public int? East { get; set; }

    public int? West { get; set; }

    public int IdGame { get; set; }

    public virtual Game IdGameNavigation { get; set; } = null!;

    public virtual ICollection<ItemsXroom> ItemsXrooms { get; set; } = new List<ItemsXroom>();
}
