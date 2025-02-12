// See https://aka.ms/new-console-template for more information

// Elora Smith, 2/12/25, Lab 3 Mastermind

using System.Collections.Concurrent;
using System.Runtime.Intrinsics.Arm;

Console.WriteLine("Welcome!");
Console.WriteLine("I have chosen 4 letters between \"a\" and \"g\" and arranged them in a particular order. \nYour job is to guess the letters and put them in the right order.");
string secret = "aefb";
string guess = "aaaa";
int guessNum = 1;
int correctPositions = 0;


do
{
    Console.WriteLine($"Guess {guessNum}: Please guess a sequence of 4 lowercase letters with no repeats.");
    guess = Console.ReadLine();
    guessNum ++;
    for (int i = 0; i < secret.Length; i++)
        if (guess[i] == secret[i])
            correctPositions++;
    Console.WriteLine($"-- {correctPositions} letters in the correct position.");
}
while (secret != guess);
Console.WriteLine(guess);
