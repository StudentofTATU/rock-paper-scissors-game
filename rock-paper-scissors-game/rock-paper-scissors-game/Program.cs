using rock_paper_scissors_game.Services.Game;

namespace rock_paper_scissors_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PSRGame game = new PSRGame(null);
            game.Playing();
        }
    }
}