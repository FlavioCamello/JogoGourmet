using JogoGourmet.Model;
using System;

namespace JogoGourmet
{
    class Program
    {
        private const string LETTER_TO_QUIT = "Q";

        private const string TEXT_TO_QUIT = $"OBS: Tecle {LETTER_TO_QUIT} para sair";
        private const string TEXT_REQUEST_PLATE = "Pense em um prato que goste: (Pressione qualquer tecla)";
        private const string TEXT_FINISHED_PROGRAM = "Programa encerrado!";

        static void Main(string[] args)
        {
            GameStore gameStore = new GameStore();

            var root = gameStore.StartGame();
            
            Console.WriteLine(TEXT_TO_QUIT);

            while (true)
            {
                Console.WriteLine(TEXT_REQUEST_PLATE);
                Console.WriteLine();

                var answer = gameStore.GetAnswer(string.Empty);
                if (answer.Equals(LETTER_TO_QUIT))
                {
                    break;
                }
                else
                {
                    gameStore.LookUp(root);
                }
            }

            Console.WriteLine(TEXT_FINISHED_PROGRAM);

        }
    }
}