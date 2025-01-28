using System;
using System.Collections.Generic;

namespace DungeonAccademy.DAL.EF;

public partial class Character
{
    public int IdCharacter { get; set; }

    public string NickName { get; set; } = null!;

    public int Health { get; set; }

    public int AttakValue { get; set; }

    public int DefenseValue { get; set; }

    public string TypeCharacter { get; set; } = null!;

    public int CharacterStatus { get; set; }

    public int IdGame { get; set; }

    public virtual Game IdGameNavigation { get; set; } = null!;
}
