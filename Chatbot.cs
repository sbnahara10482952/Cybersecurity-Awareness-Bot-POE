using System;
using System.Threading;

namespace CyberSecurityBot
{
  public static class Chatbot
  {
    public static void StartConversation()
    {
      Console.Write("Enter your name: ");
      string userName = Console.ReadLine();

      if (string.IsNullOrWhiteSpace(userName))
      {
        userName = "User";
      }

      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine($"\nWelcome {userName}! I am your Cybersecurity Awareness Bot.");
      Console.WriteLine("Ask me about password safety, phishing, or safe browsing.");
      Console.ResetColor();

      while (true)
      {
        Console.Write("\nYou: ");
        string input = Console.ReadLine()?.ToLower();

        if (string.IsNullOrWhiteSpace(input))
        {
          Console.WriteLine("Bot: Please enter something first.");
          continue;
        }

        if (input.Contains("exit"))
        {
          Console.WriteLine("Bot: Goodbye! Remember to stay alert and protect your personal data online.");
          break;
        }
        else if (input.Contains("how are you"))
        {
          Console.WriteLine("Bot: I am functioning perfectly and ready to keep you cyber safe!");
        }
        else if (input.Contains("purpose"))
        {
          Console.WriteLine("Bot: My purpose is to teach cybersecurity awareness and safe online habits.");
        }
        else if (input.Contains("what can i ask"))
        {
          Console.WriteLine("Bot: Ask me about password safety, phishing scams, suspicious links, or safe browsing.");
        }
        else if (input.Contains("password"))
        {
          Console.WriteLine("Bot: Use 12+ character passwords with symbols, numbers, and never reuse them.");
        }
        else if (input.Contains("phishing"))
        {
          Console.WriteLine("Bot: Be careful of fake emails, urgent payment requests, and suspicious login pages.");
        }
        else if (input.Contains("safe browsing"))
        {
          Console.WriteLine("Bot: Only visit HTTPS websites and avoid downloading unknown files.");
        }
        else
        {
          Console.WriteLine("Bot: I didn't quite understand that. Please ask about passwords, phishing, or safe browsing.");
        }

        Thread.Sleep(500);
      }
    }
  }
}