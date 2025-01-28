namespace DungeonAccademyDTO
{
    public class Character_DTO
    {
        public int IdCharacter { get; set; }

        public string NickName { get; set; } = null!;

        public int Health { get; set; }

        public int AttakValue { get; set; }

        public int DefenseValue { get; set; }

        public string TypeCharacter { get; set; } = null!;

        public int CharacterStatus { get; set; }

        public int IdGame { get; set; }

       
    }
}
