using DungeonAccademy.DAL;
using DungeonAccademy.DTO;
using DungeonAccademyDTO;

namespace DungeonAccademy.BusinessLogic
{
    public class BUsinessLogic
    {
        // creo l'istanza di DBSource
        DBSource db = new DBSource();

        public void CreateCharacter(String nikName, int health, int defence, int attack, string typechar)
        {
            // 1 crea il Character DTO
            Character_DTO character = new Character_DTO();
            character.NickName = nikName;
            character.Health = health;
            character.DefenseValue = defence;
            character.AttakValue = attack;
            character.TypeCharacter = typechar;

            db.CreateCharacter(character);
           
        }
    }
}
