using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace FirstGame
{
    class Program
    {
        static void Main(string[] args)
        {

            Program programInstance = new Program();
            bool gameLoop = true;



            programInstance.GamePlay();

            Console.WriteLine("");
            Console.WriteLine("To play again please enter [1], to exit press any button");
            Console.WriteLine("");
            string playAgain = Console.ReadLine();

            while (gameLoop == true)
            {
                if (playAgain == "1")
                {
                    programInstance.GamePlay();
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Thank you for play :)");
                    gameLoop = false;
                }
            }



        }

        bool GamePlay()
        {
            int _lifePoints = 5;
            bool _isThisCharInCapital = false;


            string[] capitols = new string[] { "Tirana", "Yerevan", "Vienna", "Baku", "Minsk", "Brussels", "Sarajevo", "Sofia",
            "Nicosia", "Prague", "Copenhagen", "Tallinn", "Helsinki", "Paris", "Tbilisi", "	Berlin",
            "Athens", "Budapest", "Reykjavik", "Dublin", "Rome", "Pristina", "Riga", "Vaduz",
            "Vilnius", "Luxembourg", "Valletta", "Chisinau", "Monaco", "Podgorica", "Amsterdam", "Skopje",
            "Oslo", "Warsaw", "	Lisbon", "Bucharest", "Moscow", "Belgrade", "Bratislava", "Ljubljana",
            "Madrid", "Stockholm", "Bern", "Ankara", "Kyiv", "London"};

            //string[] capitols = new string[] { "London" };

            Random rnd = new Random();
            int rIndex = rnd.Next(capitols.Length);
            string randomCity = capitols[rIndex].ToLower();
            int capitolLenght = randomCity.Length;
            char[] guess = new char[capitolLenght];
            bool endGame = true;


            List<string> faintSigns = new List<string>();

            string hiddenLetter = new string(' ', randomCity.Length).Replace(" ", "_");

            Console.WriteLine("");
            Console.WriteLine("******** Welcome in - Hangman game! ********");
            Console.WriteLine("");



            while (endGame == true)
            {

                Console.WriteLine("");
                Console.WriteLine("Yours Lives: " + _lifePoints);
                Console.WriteLine("");
                Console.WriteLine("Please press [1] to guess a letter or [2] to whole words.");
                string playerDecysion = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("Guess the capital city: " + hiddenLetter + " Letters: " + capitolLenght);
                Console.WriteLine("");
                Console.WriteLine("Your Faint Signs : ");

                for (int i = 0; i < faintSigns.Count; i++)
                {
                    Console.Write(faintSigns[i] + ", ");
                }
                Console.WriteLine("");

                // ----------------------------------------------------------------------------------------------------


                if (playerDecysion == "1")
                {

                    for (int letters = 0; letters < hiddenLetter.Length; letters++)
                    {

                        if (hiddenLetter[letters] == '_')
                        {
                            guess[letters] = '_';
                        }

                        else
                        {
                            guess[letters] = hiddenLetter[letters];
                        }
                    }

                    Console.WriteLine("");
                    Console.WriteLine("Please write your lettere : ");
                    Console.WriteLine("");

                    //###########################################################################################
                    string convertChoiceToChar = Console.ReadLine().ToString();

                    if (convertChoiceToChar.Length > 1 || convertChoiceToChar.Length == 0)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Please enter only One letter, to many or to less sight have been provided, Please try again :");
                        convertChoiceToChar = Console.ReadLine().ToString();
                    }

                    char playerGuessingLetters = char.Parse(convertChoiceToChar);

                    //###########################################################################################


                    for (int j = 0; j < capitolLenght; j++)
                    {

                        if (playerGuessingLetters == randomCity[j])
                        {
                            guess[j] = playerGuessingLetters;
                            _isThisCharInCapital = true;
                        }
                    }


                    string unHiddenLetter = String.Concat(guess);
                    hiddenLetter = unHiddenLetter;
                    Console.WriteLine(unHiddenLetter);


                    if (_isThisCharInCapital == false)
                    {
                        faintSigns.Add(Char.ToString(playerGuessingLetters));
                        _lifePoints--;
                    }

                    _isThisCharInCapital = false;

                }

                // ----------------------------------------------------------------------------------------------------

                else if (playerDecysion == "2")
                {

                    for (int letters = 0; letters < hiddenLetter.Length; letters++)
                    {

                        if (hiddenLetter[letters] == '_')
                        {
                            guess[letters] = '_';
                        }

                        else
                        {
                            guess[letters] = hiddenLetter[letters];
                        }
                    }

                    Console.WriteLine("Please write Whole Word : ");
                    string playerGuessWholeWord = Console.ReadLine();

                    if (playerGuessWholeWord.ToLower() == randomCity.ToLower())
                    {
                        Console.WriteLine("");
                        Console.WriteLine("!!!!!!!!!!!!!!!!!! You Win !!!!!!!!!!!!!!!!!!");

                        endGame = false;
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("This is not a correct answer, Try again");
                        faintSigns.Add(playerGuessWholeWord);
                        _lifePoints--;
                    }
                }

                // ----------------------------------------------------------------------------------------------------                

                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("what");
                    Console.WriteLine("");
                }

                // ----------------------------------------------------------------------------------------------------        

                if (hiddenLetter == randomCity && _lifePoints > 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("!!!!!!!!!!!!!!!!!! You win !!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("");
                    endGame = false;

                }

                if (_lifePoints == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("!!!!!!!!!!!!!!!!!! You Lost !!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("");

                    endGame = false;
                    ;

                }



            }
            return true;
        }


    }


}
