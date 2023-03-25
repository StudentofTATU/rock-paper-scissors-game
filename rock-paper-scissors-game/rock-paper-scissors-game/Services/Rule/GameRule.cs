using ConsoleTables;

namespace rock_paper_scissors_game.Services.Rule
{
    internal class GameRule
    {
        string[] moves;
        public void SetMoves(string[] _moves)
        {
            moves = _moves;

        }

        public string PlayGame(string userMove, string computerMove)
        {
            GameResult isUserWinner = IsPlayerOneWinner(userMove, computerMove);
            string resultOfGame = PlayerResultMessage(isUserWinner);


            return resultOfGame;
        }

        public GameResult IsPlayerOneWinner(string playerOne, string playerTwo)
        {
            int size = moves.Length;


            int center = size / 2;
            int playerOneIndex = Array.IndexOf(moves, playerOne);

            if (playerTwo.Equals(moves[playerOneIndex]))
            {
                return GameResult.Draw;
            }

            while (center > 0)
            {
                playerOneIndex++;

                if (playerTwo.Equals(moves[(playerOneIndex % size)]))
                {
                    return GameResult.Lose;
                }

                center--;
            }

            return GameResult.Win;
        }

        private string PlayerResultMessage(GameResult isUserWinner)
        {
            string result = "";

            switch (isUserWinner)
            {
                case GameResult.Lose: result = "Computer win!"; break;
                case GameResult.Draw: result = "Draw"; break;
                case GameResult.Win: result = "You win!"; break;
            }
            return result;
        }

        private string PlayerResult(GameResult isUserWinner)
        {
            string result = "";

            switch (isUserWinner)
            {
                case GameResult.Lose: result = "Lose"; break;
                case GameResult.Draw: result = "Draw"; break;
                case GameResult.Win: result = "Win"; break;
            }
            return result;
        }

        public void PrintRuleTable()
        {
            var table = new ConsoleTable();

            List<string> colums = new List<string>();
            List<string> rows = new List<string>();

            colums.Add("№ ");
            for (int i = 0; i < moves.Length; i++)
            {
                colums.Add(moves[i]);
            }

            table.AddColumn(colums);

            for (int i = 0; i < moves.Length; i++)
            {
                rows.Add(moves[i]);

                for (int j = 1; j < moves.Length + 1; j++)
                {
                    rows.Add(PlayerResult(IsPlayerOneWinner(moves[i], moves[j - 1])));
                }
                table.AddRow(rows.ToArray());
                rows.Clear();
            }

            table.Write(Format.Alternative);
        }

    }

}
