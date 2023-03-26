namespace rock_paper_scissors_game.Services.Rule
{
    internal class MoveRule
    {
        public static bool IsMovesValid(string[] moves)
        {
            if (moves == null)
            {
                return false;
            }
            else if (!NumerOfMovesNotLessThanTwo(moves.Length))
            {
                return false;
            }
            else if (!NumerOfMovesIsOdd(moves.Length))
            {
                return false;
            }
            else if (HasDublicatedMove(moves))
            {
                return false;
            }
            return true;
        }

        public static string GetInValidMoveMessage(string[] moves)
        {
            string errorMessage = "";
            if (moves == null)
            {
                return "Not found input moves.Please insert moves,for example: Rock Paper Scissors";
            }
            else if (!NumerOfMovesNotLessThanTwo(moves.Length))
            {
                errorMessage += "Moves must be more than 2 move.\n";
            }
            if (!NumerOfMovesIsOdd(moves.Length))
            {
                errorMessage += "Number of moves must be odd.\n";
            }
            if (HasDublicatedMove(moves))
            {
                errorMessage += "Moves can not contain dublicated value.\n";
            }
            errorMessage += "for example: Rock Paper Scissors or Rock Paper Scissors Lizard Spock";

            return errorMessage;
        }

        public static bool NumerOfMovesNotLessThanTwo(int movesNumber)
        {
            return movesNumber > 2;
        }

        public static bool NumerOfMovesIsOdd(int movesNumber)
        {
            return movesNumber % 2 == 1;
        }

        public static bool HasDublicatedMove(string[] moves)
        {
            for (int i = 0; i < moves.Length; i++)
            {
                for (int j = i + 1; j < moves.Length; j++)
                {
                    if (moves[i].Equals(moves[j])) return true;
                }
            }
            return false;
        }
    }
}