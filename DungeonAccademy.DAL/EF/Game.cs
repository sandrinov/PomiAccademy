using System;
using System.Collections.Generic;

namespace DungeonAccademy.DAL.EF;

public partial class Game
{
    public int IdGame { get; set; }

    public string GameName { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public int GameStatus { get; set; }

    public int? CurrentCharacter { get; set; }

    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
