using rock_paper_scissors_game.Services.Menu;
using rock_paper_scissors_game.Services.Player;
using rock_paper_scissors_game.Services.Rule;
using rock_paper_scissors_game.Services.Security;

namespace rock_paper_scissors_game.Services.Game
{
    internal class PSRGame
    {
        GameRule gameRule;
        Computer computer;
        string[] moves;
        string userMove;

        public PSRGame(string[] args)
        {
            moves = args;
        }

        public void Playing()
        {
            if (IsMovesValid(moves))
            {
                GameSetUp();
                ComputerPlayerSetUp();
                StartGame();
            }
            else
            {
                ShowInValidMoveMessage(moves);
            }
        }

        private void StartGame()
        {
            ComputerPlay();
            ShowMenu();
            UserPlay();
        }

        public void ComputerPlayerSetUp()
        {
            computer = new Computer(new SecurityService());
            computer.Moves = moves;
        }

        public void GameSetUp()
        {
            gameRule = new GameRule();
            gameRule.SetMoves(moves);
        }

        public void ComputerPlay()
        {
            computer.Play();
            PrintHMAC();
        }

        public void PlayGameAndFindWinner()
        {
            string resultOfGame = gameRule.PlayGame(userMove, computer.ComputerMove.Value);
            ShowResult(resultOfGame, userMove);
            PrintKey();
            StartGame();
        }

        public void ShowResult(string resultOfGame, string userMove)
        {
            Console.WriteLine("Your move: " + userMove);
            Console.WriteLine("Computer move: " + computer.ComputerMove.Value);
            Console.WriteLine(resultOfGame);
        }

        public void UserPlay()
        {
            string userMove = getUserInput();
            bool isValidMove;
            if (MenuItemSelected(userMove)) { return; }

            isValidMove = MoveSelected(userMove);

            if (isValidMove)
            {
                PlayGameAndFindWinner();
            }
            else
            {
                InvalidMoveInputMessage(userMove);
            }
        }

        private string getUserInput()
        {
            Console.Write("Enter your move: ");
            string userMove = Console.ReadLine();
            return userMove;
        }

        private bool MenuItemSelected(string userMove)
        {
            if (userMove.Equals("0"))
            {
                Console.WriteLine("The End");
                return true;
            }
            else if (userMove.Equals("?"))
            {
                gameRule.PrintRuleTable();
                UserPlay();
                return true;
            }
            return false;
        }

        private bool MoveSelected(string move)
        {
            int userMoveNumber;

            int.TryParse(move, out userMoveNumber);

            if (userMoveNumber > 0 && userMoveNumber <= moves.Length)
            {
                userMove = moves[userMoveNumber - 1];

                return true;
            }
            return false;
        }

        public void InvalidMoveInputMessage(string input)
        {
            Console.WriteLine(input + " is not recognized! Please retry.");
            UserPlay();
        }

        public void ShowMenu()
        {
            MoveMenu.GetMoveMenu(moves);
        }

        public void PrintHMAC()
        {
            Console.WriteLine("HMAC: " + computer.ComputerMove.HMAC);
        }

        public void PrintKey()
        {
            Console.WriteLine("HMAC key: " + computer.ComputerMove.Key);
        }

        public bool IsMovesValid(string[] args)
        {
            return MoveRule.IsMovesValid(args);
        }

        public void ShowInValidMoveMessage(string[] args)
        {
            string errorMessage = MoveRule.GetInValidMoveMessage(args);
            Console.WriteLine(errorMessage);
        }
    }
}
