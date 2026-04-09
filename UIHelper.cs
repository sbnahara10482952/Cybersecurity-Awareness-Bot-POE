using System;
using System.Media;

namespace CyberSecurityBot
{
    public static class UIHelper
    {
        public static void DisplayHeader()
        {
            Console.Title = "Cybersecurity Awareness Bot";

            try
            {
                SoundPlayer player = new SoundPlayer("greeting.wav");
                player.Play();
            }
            catch
            {
                Console.WriteLine("Voice greeting file not found.");
            }

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(@"
==========================================================
||         CYBERSECURITY AWARENESS BOT 🔐              ||
==========================================================

              _______________________
             |  ________________    |
             | |   ACCESS SAFE  |   |
             | |________________|   |
             |   _____________       |
             |  |   LOCKED   |       |
             |  |____________|       |
             |_______________________|

                  [ SECURITY ACTIVE ]
");

            Console.ResetColor();
        }
    }
}