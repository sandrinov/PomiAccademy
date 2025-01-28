using DungeonAccademy.DAL.EF;
using DungeonAccademy.DTO;
using DungeonAccademyDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAccademy.DAL
{
    public class DBSource
    {
        private DungeonAccademyContext ctx = new DungeonAccademyContext();
        public void CreateCharacter(Character_DTO dto_character)
        {
            // 1 crea il Character EF from DTO
            DungeonAccademy.DAL.EF.Character ef_character = new EF.Character();
            ef_character.TypeCharacter = dto_character.TypeCharacter;
            ef_character.CharacterStatus = dto_character.CharacterStatus;
            ef_character.AttakValue = dto_character.AttakValue;
            ef_character.DefenseValue = dto_character.DefenseValue;
            ef_character.Health = dto_character.Health;
            ef_character.NickName = dto_character.NickName;
            // 2 INsert Character EF in DBContext
            ctx.Characters.Add(ef_character);
            // 3 ctx.savechanges();
            ctx.SaveChanges();
        }
    }
}
