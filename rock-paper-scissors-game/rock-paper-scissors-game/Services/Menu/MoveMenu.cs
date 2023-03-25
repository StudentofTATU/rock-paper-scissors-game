using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rock_paper_scissors_game.Services.Menu
{
    internal class MoveMenu
    {
        public static void GetMoveMenu(string[] moves)
        {
            Console.WriteLine("Available moves:");
            for (int i = 0; i < moves.Length; i++)
            {
                Console.WriteLine((i + 1) + " - " + moves[i]);
            }
            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
        }

        public static IDictionary<string, string> MenuItems(string[] moves)
        {
            IDictionary<string, string> items = new Dictionary<string, string>();

            items.Add("0", "exit");
            items.Add("?", "help");
            for (int i = 0; i < moves.Length; i++)
            {
                items.Add((i + 1) + "", moves[i]);
            }

            return items;
        }
    }
}
