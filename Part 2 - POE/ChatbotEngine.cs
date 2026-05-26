using System;
using System.Collections.Generic;

namespace CyberSecurityBotGUI
{
    public class ChatbotEngine
    {
        private Random random = new Random();

        private string userName = "";
        private string lastTopic = "";

        // Memory system
        private List<string> memory = new List<string>();

        // Password responses
        public List<string> passwordResponses = new List<string>()
        {
            "Use passwords with 12+ characters.",
            "Avoid using personal information in passwords.",
            "Use different passwords for different accounts.",
            "Enable two-factor authentication whenever possible."
        };

        // Phishing responses
        public List<string> phishingResponses = new List<string>()
        {
            "Never click suspicious links.",
            "Verify email senders before responding.",
            "Scammers often pretend to be trusted organisations.",
            "Avoid emails asking for urgent payments."
        };

        // Privacy responses
        public List<string> privacyResponses = new List<string>()
        {
            "Review your privacy settings regularly.",
            "Avoid oversharing personal information online.",
            "Use secure websites with HTTPS.",
            "Be careful when downloading unknown files."
        };

        // Malware responses
        public List<string> malwareResponses = new List<string>()
        {
            "Install trusted antivirus software.",
            "Avoid downloading files from unknown websites.",
            "Keep your operating system updated.",
            "Malware can steal personal information from your device."
        };

        // Dictionary
        private Dictionary<string, List<string>> keywordResponses;

        // Constructor
        public ChatbotEngine()
        {
            keywordResponses = new Dictionary<string, List<string>>()
            {
                { "password", passwordResponses },
                { "phishing", phishingResponses },
                { "privacy", privacyResponses },
                { "malware", malwareResponses },
                { "virus", malwareResponses },
                { "hacker", malwareResponses}
            };
        }

        // Main chatbot response method
        public string GetResponse(string input)
        {
            // Name memory
            if (input.StartsWith("my name is"))
            {
                userName = input.Replace("my name is", "").Trim();

                return "Nice to meet you, " + userName + "! I will remember your name.";
            }

            // Greetings
            if (input.Contains("hello") || input.Contains("hi"))
            {
                if (!string.IsNullOrEmpty(userName))
                {
                    return "Hello again, " + userName + "! How can I help you today?";
                }

                return "Hello! How can I help you stay cyber safe today?";
            }

            // Password
            else if (input.Contains("password"))
            {
                if (!memory.Contains("password safety"))
                {
                    memory.Add("password safety");
                }

                lastTopic = "password";

                List<string> responses = keywordResponses["password"];

                return responses[random.Next(responses.Count)]
                    + " Would you also like phishing protection tips?";
            }

            // Phishing
            else if (input.Contains("phishing") || input.Contains("scam"))
            {
                if (!memory.Contains("phishing awareness"))
                {
                    memory.Add("phishing awareness");
                }

                lastTopic = "phishing";

                List<string> responses = keywordResponses["phishing"];

                return responses[random.Next(responses.Count)]
                    + " Remember to avoid clicking suspicious links.";
            }

            // Privacy
            else if (input.Contains("privacy") || input.Contains("safe browsing"))
            {
                if (!memory.Contains("online privacy"))
                {
                    memory.Add("online privacy");
                }

                lastTopic = "privacy";

                List<string> responses = keywordResponses["privacy"];

                return responses[random.Next(responses.Count)];
            }

            // Malware
            else if (input.Contains("malware") || input.Contains("virus") || input.Contains("hacker"))
            {
                if (!memory.Contains("malware protection"))
                {
                    memory.Add("malware protection");
                }

                lastTopic = "malware";

                List<string> responses = keywordResponses["malware"];

                return responses[random.Next(responses.Count)];
            }

            // Extra cybersecurity tips
            else if (input.Contains("tell me more") || input.Contains("another tip"))
            {
                List<string> extraTips = new List<string>()
                {
                    "Always log out from shared computers.",
                    "Do not reuse passwords across websites.",
                    "Avoid opening suspicious email attachments.",
                    "Use multi-factor authentication whenever possible."
                };

                return extraTips[random.Next(extraTips.Count)];
            }

            // Memory recall
            else if (input.Contains("what did we talk about"))
            {
                if (memory.Count > 0)
                {
                    return "Earlier we discussed: " + string.Join(", ", memory);
                }

                return "We have not discussed any cybersecurity topics yet.";
            }

            // Sentiment detection
            else if (input.Contains("worried") || input.Contains("scared"))
            {
                return "It is okay to feel concerned. Staying informed and cautious online helps keep you safe.";
            }

            else if (input.Contains("confused"))
            {
                return "Cybersecurity can seem difficult at first, but I am here to help you understand it.";
            }

            else if (input.Contains("curious"))
            {
                return "That is great! Learning more about cybersecurity is an excellent habit.";
            }

            // Purpose
            else if (input.Contains("purpose"))
            {
                return "My purpose is to educate users about cybersecurity awareness and online safety.";
            }

            // Tips
            else if (input.Contains("tips") || input.Contains("advice"))
            {
                List<string> tips = new List<string>()
                {
                    "Never share your passwords with anyone.",
                    "Always update your software regularly.",
                    "Avoid public Wi-Fi for sensitive transactions.",
                    "Enable two-factor authentication on important accounts.",
                    "Be careful when downloading attachments from emails."
                };

                return tips[random.Next(tips.Count)];
            }

            // Goodbye
            else if (input.Contains("bye") || input.Contains("exit"))
            {
                return "Goodbye! Stay safe online.";
            }

            // Default response
            else
            {
                return "I didn't quite understand that. Please rephrase your question.";
            }
        }
    }
}