 namespace Jumper
 {
    class Game
     {
        Board board = new Board();
        Word word = new Word();
        
        public int printWord(List<char> guessedLetters, String randomWord)
        {
            int counter = 0;
            int rightLetters = 0;
            Console.Write("\r\n");
            foreach (char c in randomWord)
            {
                if (guessedLetters.Contains(c))
                {
                    Console.Write(c + " ");
                    rightLetters += 1;
                }
                else
                {
                    Console.Write("  ");
                }
                counter += 1;
            }
            return rightLetters;
        }

        public void printLines(String randomWord)
        {
            Console.Write("\r");
            foreach (char c in randomWord)
            {
                Console.Write("_ ");
            }
        }

        public void playJumper()
        {
            Console.WriteLine("Welcome to hangman :)");
            Console.WriteLine("-----------------------------------------");
            string randomWord = word.getRandomWord();
            foreach (char x in randomWord)
            {
                Console.Write("_ ");
            }
            int amountOfTimesWrong = 0;
            int currentLettersRight = 0;
            
            int lengthOfWordToGuess = randomWord.Length;
            List<char> currentLettersGuessed = new List<char>();
            
          

            

            while (amountOfTimesWrong != 5 && currentLettersRight != lengthOfWordToGuess)
            {
                Console.Write("\nLetters guessed so far: ");
                foreach (char letter in currentLettersGuessed)
                {
                    Console.Write(letter + " ");
                }
                Console.Write("\nGuess a letter: ");
                char letterGuessed = Console.ReadLine()[0];
                // Check if that letter has already been guessed
                if (currentLettersGuessed.Contains(letterGuessed))
                {
                    Console.Write("\r\n You have already guessed this letter");
                    board.printHangman(amountOfTimesWrong);
                    currentLettersRight = printWord(currentLettersGuessed, randomWord);
                    printLines(randomWord);
                }
                else
                {
                    // Check if letter is in randomWord
                    bool right = false;
                    for (int i = 0; i < randomWord.Length; i++) { if (letterGuessed == randomWord[i]) { right = true; } }

                    // User is right
                    if (right)
                    {
                        board.printHangman(amountOfTimesWrong);
                        // Print word
                        currentLettersGuessed.Add(letterGuessed);
                        currentLettersRight = printWord(currentLettersGuessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                    // User was wrong af
                    else
                    {
                        amountOfTimesWrong += 1;
                        currentLettersGuessed.Add(letterGuessed);
                        // Update the drawing
                        board.printHangman(amountOfTimesWrong);
                        // Print word
                        currentLettersRight = printWord(currentLettersGuessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                }
            }
            Console.WriteLine("\r\nGame is over! Thank you for playing :)");
        }
     }
 }