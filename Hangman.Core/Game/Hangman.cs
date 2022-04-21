using System;
using HangmanRenderer.Renderer;

namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private GallowsRenderer _renderer;

        public HangmanGame()
        {
            _renderer = new GallowsRenderer();
        }
        private string _Guessword;
        private string _mysteryWord;
        int lives = 6;


        public HangmanGame(string mysteryWord)
        {
            string _mysteryWord = mysteryWord;

            for (int index = 0; index < _mysteryWord.Length; index++)
            {
                _Guessword += "*";
            }
            _renderer = new GallowsRenderer();
            {

                string GetmysteryWord()
                {
                    return _mysteryWord;

                }

            }
        }
        public void AddGuess(char letter)
        {
            char[] guessProgressArray = _mysteryWord.ToCharArray();

            for (int index = 0; index < _Guessword.Length; index++)
            {
                if (_Guessword[index] == letter)
                {
                    guessProgressArray[index] = letter;
                }


                _mysteryWord = new string(guessProgressArray);
            }
        }

        public void Run()
        {
            Console.WriteLine("");
            _renderer.Render(5, 5, 6);

            Console.SetCursorPosition(0, 20);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Your current guess: ");
            Console.WriteLine("*********");
            Console.SetCursorPosition(0, 15);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("What is your next guess: ");
            var nextGuess = Console.ReadLine();
        }

        public void PlayGame()
        {
            Console.WriteLine("Welcome to hangman!");
            string[] listwords = new string[20];
            Console.WriteLine(listwords[20]);
            Console.WriteLine("Pink", "Black", "Light blue", "Nude", "Lemon", "Light brown", "Black blue", "Light orange", "Maroon", "leapard", "Blue", "Black", "Navy",
                   "Purple", "Brown", "Yellow", "White", "Red", "Charcoal", "Rainbow");


            //Pick randomly from the listwords 0 to 20
            Random randGen = new Random();
            var idx = randGen.Next(0, 20);

            string mysteryWord = listwords[idx];
            char[] guess = new char[mysteryWord.Length];

            Console.Write("Please enter your guess: ");

            for (int p = 0; p < mysteryWord.Length; p++)
                guess[p] = '*';

            while (true)
            {
                char playerGuess = char.Parse(Console.ReadLine());
                for (int j = 0; j < mysteryWord.Length; j++)
                {
                    if (playerGuess == mysteryWord[j])
                        guess[j] = playerGuess;
                    if (playerGuess != mysteryWord[j])
                    {

                        lives--;
                        _renderer.Render(5, 5, lives);
                    }
                }
                Console.WriteLine("You've guessed right! {0}", "Play again ");

                if (lives == 0)
                {
                    Console.WriteLine("You loose.");
                }
                else if (lives == 1)
                {
                    Console.WriteLine("You win!", guess);

                    _renderer.Render(5, 5, lives);
                }


                for (int index = 20; index < 0; index++) ;
            }


        }



    }

    }
