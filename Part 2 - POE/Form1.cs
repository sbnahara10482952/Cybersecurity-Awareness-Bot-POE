using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CyberSecurityBotGUI
{
    public partial class Form1 : Form
    {
        private delegate void LogHandler(string message);
        private ChatbotEngine bot = new ChatbotEngine();

        // GUI Controls
        private RichTextBox chatBox;
        private TextBox inputBox;
        private Button sendButton;
        private Button clearButton;
        private Label titleLabel;

        // Random object
        private Random random = new Random();

        // Memory system
        private List<string> memory = new List<string>();

        // Password responses
        private List<string> passwordResponses = new List<string>()
        {
            "Use passwords with 12+ characters.",
            "Avoid using personal information in passwords.",
            "Use different passwords for different accounts.",
            "Enable two-factor authentication whenever possible."
        };

        // Phishing responses
        private List<string> phishingResponses = new List<string>()
        {
            "Be cautious of emails asking for personal information.",
            "Never click suspicious links from unknown senders.",
            "Scammers often disguise themselves as trusted organisations.",
            "Always verify email addresses before responding."
        };

        // Privacy responses
        private List<string> privacyResponses = new List<string>()
        {
            "Review your privacy settings regularly.",
            "Avoid sharing personal information publicly online.",
            "Use secure websites that begin with HTTPS.",
            "Be careful when downloading files from the internet."
        };
        public List<string> malwareResponses = new List<string>()
        {
            "Install trusted antivirus software.",
            "Avoid downloading files from unknown websites.",
            "Keep your operating system updated.",
            "Malware can steal personal information from your device."
        };

        private Dictionary<string, List<string>> responseDictionary = new Dictionary<string, List<string>>();

        public Form1()
        {
            InitializeComponent();
            BuildInterface();
            PlayGreeting();
        }

        // Voice greeting
        private void PlayGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("greeting.wav");
                player.Play();
            }
            catch
            {
                MessageBox.Show("Voice greeting file not found.");
            }
        }

        private void LogMessage(string message)
        {
            Console.WriteLine(message);
        }

        // Build GUI
        private void BuildInterface()
        {
            // Form settings
            this.Text = "Cybersecurity Awareness Bot";
            this.Size = new Size(850, 650);
            this.BackColor = Color.Black;

            // Title label
            titleLabel = new Label();
            titleLabel.Text = "🔐 CYBERSECURITY AWARENESS BOT";
            titleLabel.ForeColor = Color.Cyan;
            titleLabel.Font = new Font("Arial", 20, FontStyle.Bold);
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(180, 20);

            // Chat box
            chatBox = new RichTextBox();
            chatBox.Location = new Point(50, 80);
            chatBox.Size = new Size(730, 400);
            chatBox.BackColor = Color.White;
            chatBox.ForeColor = Color.Black;
            chatBox.ReadOnly = true;
            chatBox.Font = new Font("Arial", 11);

            // Input box
            inputBox = new TextBox();
            inputBox.Location = new Point(50, 520);
            inputBox.Size = new Size(550, 30);
            inputBox.Font = new Font("Arial", 11);
            inputBox.KeyDown += InputBox_KeyDown;

            // Send button
            sendButton = new Button();
            sendButton.Text = "Send";
            sendButton.Location = new Point(630, 515);
            sendButton.Size = new Size(150, 40);
            sendButton.BackColor = Color.Cyan;
            sendButton.Font = new Font("Arial", 11, FontStyle.Bold);

            clearButton = new Button();
            clearButton.Text = "Clear Chat";
            clearButton.Location = new Point(630, 565);
            clearButton.Size = new Size(150, 40);
            clearButton.BackColor = Color.LightGray;

            clearButton.Click += ClearButton_Click;

            // Button event
            sendButton.Click += SendButton_Click;

            // Add controls
            this.Controls.Add(titleLabel);
            this.Controls.Add(chatBox);
            this.Controls.Add(inputBox);
            this.Controls.Add(sendButton);
            this.Controls.Add(clearButton);

            chatBox.AppendText(
@"=================================================
|| CYBERSECURITY AWARENESS BOT 🔐 ||
=================================================
______________________
| _________________ |
| | SAFE LOGIN | |
| |________________| |
|_____________________|

==========================================================
|| CYBERSECURITY AWARENESS BOT 🔐 ||
==========================================================

_______________________
| ________________ |
| | ACCESS SAFE | |
| |________________| |
| _____________ |
| | LOCKED | |
| |____________| |
|_______________________|

[ SECURITY ACTIVE ]

");

            // Welcome messages
            chatBox.AppendText("====================================================\n");
            chatBox.AppendText("WELCOME TO THE CYBERSECURITY AWARENESS BOT\n");
            chatBox.AppendText("====================================================\n\n");



            chatBox.AppendText("Bot: Hello! Ask me about:\n");
            chatBox.AppendText("- Password safety\n");
            chatBox.AppendText("- Phishing scams\n");
            chatBox.AppendText("- Online privacy\n");
            chatBox.AppendText("- Safe browsing\n\n");
        }

        // Send button logic
        private async void SendButton_Click(object sender, EventArgs e)
        {
            string userInput = inputBox.Text.Trim();

            // Input validation
            if (string.IsNullOrWhiteSpace(userInput))
            {
                MessageBox.Show("Please enter a message.");
                return;
            }

            // Display user message
            chatBox.AppendText("[" + DateTime.Now.ToShortTimeString() + "] You: " + userInput + "\n");

            // Typing effect
            chatBox.AppendText("Bot is typing...\n");
            await Task.Delay(700);

            // Remove typing text
            chatBox.Text = chatBox.Text.Replace("Bot is typing...\n", "");

            LogHandler logger = LogMessage;

            string response = bot.GetResponse(userInput.ToLower());

            logger("User asked: " + userInput);

            // Display response
            chatBox.AppendText("[" + DateTime.Now.ToShortTimeString() + "] Bot: " + response + "\n\n");

            // Clear textbox
            inputBox.Clear();
        }
        private void InputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendButton.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            chatBox.Clear();
            chatBox.AppendText("Chat cleared.\n\n");
        }
    }
}