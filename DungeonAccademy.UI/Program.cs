using DungeonAccademy.BusinessLogic;

namespace DungeonAccademy.UI
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            BUsinessLogic bl = new BUsinessLogic();
            //.................
            String nickname = Console.ReadLine();
            int health = Console.ReadLine();
            int defence = 0;
            int attack = 0;
            string typechar = Console.ReadLine();
            //...............
            bl.CreateCharacter(nickname, health, defence, attack, "Enemy");
        }
    }
}
