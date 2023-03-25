using rock_paper_scissors_game.Models;
using rock_paper_scissors_game.Services.Rule;
using rock_paper_scissors_game.Services.Security;

namespace rock_paper_scissors_game.Services.Player
{
    internal class Computer
    {
        public string[] Moves { set; get; }
        public Move ComputerMove { get; set; }

        SecurityService securityService;

        public Computer(SecurityService securityService)
        {
            this.securityService = securityService;
            ComputerMove = new Move();
        }

        public void Play()
        {
            if (MoveRule.IsMovesValid(Moves))
            {
                GenerateComputerMove();
            }
        }

        private void GenerateComputerMove()
        {
            ComputerMove.Value = GetRandomMove();
            ComputerMove.Key = GetKey();
            ComputerMove.HMAC = GetHMAC(ComputerMove.Key, ComputerMove.Value);
        }

        public string GetRandomMove()
        {
            int number = new Random().Next(0, Moves.Length);

            return Moves[number];
        }

        public string GetKey() =>
            securityService.GenerateCryptographicallyKey();

        public string GetHMAC(string key, string message) =>
            securityService.GenerateHmacValue(key, message);

    }
}
