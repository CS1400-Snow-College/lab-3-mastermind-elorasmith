
// Elora Smith, 2/12/25, Lab 3 Mastermind


Console.WriteLine("Welcome!");
Console.WriteLine("I will chose a certain number of letters and arrange them in a particular order.\nYour job is to guess the letters and put them in the right order.");
Console.WriteLine("How many letters would you like me to use?");
int maxNumbers = Convert.ToInt32(Console.ReadLine());
char g = (char)(97+maxNumbers+2);
Console.WriteLine($"I have chosen {maxNumbers} letters between \"a\" and \"{g}\". Guess the letters and put them in the right order!");
string secret = "";
string? guess = "aaaa";
int guessNum = 1;

// CHOOSING SECRET
string check = "";
for (int i = 97; i < (97+maxNumbers+5); i++)
    check += (char)i;

Random rand = new Random();
while (secret.Length < maxNumbers)
    {
        int temp = rand.Next(97, (97 + maxNumbers + 6));
        char letter = (char)temp;
        if (check.Contains(letter))
        {
            secret += letter;
            check = check.Replace(letter, '1');
        }
    }

// MAIN BODY
do
{
    int correctPositions = 0;
    int correctLetters = 0;
    Console.WriteLine($"Guess #{guessNum}: Please guess a sequence of {maxNumbers} lowercase letters with no repeats.");
    guess = Console.ReadLine();

    // RESPONSE VALIDATION
    guess = guess.ToLower();
    if (guess.Length > secret.Length)
    {
        Console.WriteLine($"Please only enter {maxNumbers} letters. Try again!");
        continue;
    }
    if (guess.Length < secret.Length)
    {
        Console.WriteLine($"Please enter {maxNumbers} letters. Try again!");
        continue;
    }
    guessNum ++;

    // HINTS
    for (int i = 0; i < secret.Length; i++)
       {
        if (guess[i] == secret[i])
           correctPositions++;
       }
    for (int j = 0; j < secret.Length; j++)
        {
             if (guess.Contains(secret[j]))
             correctLetters++;
        }
    correctLetters -= correctPositions;
   Console.WriteLine($"-- {correctPositions} letters in the correct position.");
   Console.WriteLine($"-- {correctLetters} correct letters in the wrong position.");
}

// END OF GAME
while (secret != guess);
Console.WriteLine($"Congrats! You guessed the secret: {secret}. It took you {guessNum} guesses!");
