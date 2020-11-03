using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Claims;

namespace SecondGame
{
    class Program
    {
        static void Main(string[] args)
        {

            //###################################################################################################################

            Console.WriteLine("");
            Console.WriteLine("!!!!!!!!!!!!!! Welcome in - Hangman game! V: 2.0 !!!!!!!!!!!!!!");
            Console.WriteLine("");

            Program programInstance = new Program();

            int _score = 0;
            bool gameLoop = true;

            //###################################################################################################################

            while (gameLoop == true)
            {
                Console.WriteLine("");
                Console.WriteLine("                                                 MENU");
                Console.WriteLine("To start or continue game enter [1],To see high score form lasts game press [2], ");
                Console.WriteLine("to save your score and exit game [3], to exit press any button");
                Console.WriteLine("");

                //###################################################################################################################

                string playAgain = Console.ReadLine();
                Console.Clear();

                if (playAgain == "1")
                {
                    int scoreHit = programInstance.GamePlay();
                    _score += scoreHit;
                    Console.WriteLine("Your Score is :" + _score);
                    Console.WriteLine("");
                }
                else if (playAgain == "2")
                {

                    string pathToHighScore = @"C:\Git\Motorola-Academy-Game\SecondGame\score.txt";

                    var first10Lines = File.ReadLines(pathToHighScore).Take(10).ToList();
                    //List<string> lines = File.ReadAllLines(pathToHighScore).ToList();

                    foreach (string line in first10Lines)
                    {
                        Console.WriteLine(line);
                    }


                    //###################################################################################################################
                }
                else if (playAgain == "3")
                {


                    Console.WriteLine("");
                    Console.WriteLine("Please provide your name :");
                    Console.WriteLine("");


                    //###################################################################################################################

                    string pathToSaveScore = @"C:\Git\Motorola-Academy-Game\SecondGame\score.txt";

                    string playerName = Console.ReadLine();
                    DateTime localDate = DateTime.Now;

                    List<string> highScoreList = File.ReadAllLines(pathToSaveScore).ToList();

                    string allInOne = playerName + " | " + localDate.ToString() + " | " + _score.ToString();
                    highScoreList.Add(allInOne);




                    File.WriteAllLines(pathToSaveScore, highScoreList);

                    Console.WriteLine("");
                    Console.WriteLine("Your Score have been saved");
                    Console.WriteLine("");


                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Thank you for play :)");
                    gameLoop = false;
                }
            }


        }


        int GamePlay()
        {

            int _lifePoints = 5;

            string filePath = @"C:\Git\Motorola-Academy-Game\SecondGame\countries_and_capitals.txt";

            var lines = File.ReadAllLines(filePath);
            var random = new Random();
            var randomLineNumber = random.Next(0, lines.Length - 1);
            string randomLine = lines[randomLineNumber];

            string seperator = " | ";

            string[] words = randomLine.Split(seperator);

            string country = words[0].ToLower();
            string capitol = words[1].ToLower();
            char[] guess = new char[capitol.Length];
            bool _isThisCharInCapital = false;

            Console.WriteLine(capitol);

            string hiddenCapitol = new string(' ', capitol.Length).Replace(" ", "*");

            bool endGame = false;

            Program programInstance = new Program();


            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            while (endGame == false)
            {


                if (_lifePoints == 4)
                {
                    Console.WriteLine("0");
                }
                else if (_lifePoints == 3)
                {
                    Console.WriteLine("0");
                    Console.WriteLine("|");
                }
                else if (_lifePoints == 2)
                {
                    Console.WriteLine("  0");
                    Console.WriteLine(@"/ | \");
                }
                else if (_lifePoints == 1)
                {
                    Console.WriteLine(@"  0");
                    Console.WriteLine(@"/ | \");
                    Console.WriteLine(@" /  ");

                    Console.WriteLine("");
                    Console.WriteLine("This is your last Life: the Capital of Country you are looking for is : " + country);
                    Console.WriteLine("");
                    endGame = true;

                }
                else if (_lifePoints == 0)
                {
                    Console.WriteLine(@"  0");
                    Console.WriteLine(@"/ | \");
                    Console.WriteLine(@" / \  ");

                }


                Console.WriteLine("");
                Console.WriteLine("Your LifePoint : " + _lifePoints + " | Capitol to gess : " + hiddenCapitol);
                Console.WriteLine("");

                Console.WriteLine("");
                Console.WriteLine("Please press [1] to guess a letter or [2] to whole words.");
                Console.WriteLine("");


                string playerDecysion = Console.ReadLine();


                if (playerDecysion == "1")
                {

                    for (int letters = 0; letters < hiddenCapitol.Length; letters++)
                    {

                        if (hiddenCapitol[letters] == '*')
                        {
                            guess[letters] = '*';
                        }

                        else
                        {
                            guess[letters] = hiddenCapitol[letters];
                        }
                    }


                    Console.WriteLine("");
                    Console.WriteLine("Please enter Your letter.");
                    Console.WriteLine("");

                    string guessLetter = Console.ReadLine().ToString();

                    if (guessLetter.Length > 1 || guessLetter.Length == 0)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Please enter only One letter, to many or to less sight have been provided, Please try again :");
                        guessLetter = Console.ReadLine().ToString();

                    }


                    char playerGuessingLetters = char.Parse(guessLetter);

                    for (int j = 0; j < capitol.Length; j++)
                    {

                        if (playerGuessingLetters == capitol[j])
                        {
                            guess[j] = playerGuessingLetters;
                            _isThisCharInCapital = true;
                        }
                    }


                    string unHiddenLetter = String.Concat(guess);
                    hiddenCapitol = unHiddenLetter;
                    Console.WriteLine(unHiddenLetter);


                    if (_isThisCharInCapital == false)
                    {
                        _lifePoints--;
                    }

                    _isThisCharInCapital = false;

                    if (unHiddenLetter == capitol)
                    {
                        Console.WriteLine("You win");
                        endGame = true;
                    }



                }

                else if (playerDecysion == "2")
                {

                    Console.WriteLine("");
                    Console.WriteLine("Please enter Capital : ");
                    Console.WriteLine("");

                    string guessingWholeWord = Console.ReadLine().ToLower();

                    if (guessingWholeWord == capitol)
                    {
                        Console.WriteLine("You win");
                        endGame = true;
                    }
                    else
                    {
                        Console.WriteLine("Wrong answer, -2 life");
                        _lifePoints = _lifePoints - 2;
                    }

                }

                else
                {
                    Console.WriteLine("Please select [1] to guess letter or [2] to guess whole word");
                }

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




            }

            endGame = false;

            if (_lifePoints <= 0)
            {
                return _lifePoints = 0;
            }


            return _lifePoints;

        }





    }
}
