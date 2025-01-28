using System;
using System.Collections.Generic;

namespace DungeonAccademy.DAL.EF;

public partial class CharactersXroom
{
    public int IdCharacterXroom { get; set; }

    public int IdCharacter { get; set; }

    public int IdRoom { get; set; }

    public virtual Character IdCharacterNavigation { get; set; } = null!;

    public virtual Room IdRoomNavigation { get; set; } = null!;
}
