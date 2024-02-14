using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NotificationParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter notification title:");
            string title = Console.ReadLine();

            List<string> channels = ParseNotificationChannels(title);

            Console.WriteLine("Receive channels: " + string.Join(", ", channels));
        }

        static List<string> ParseNotificationChannels(string title)
        {
            List<string> channels = new List<string>();

            // Regular expression pattern to match tags within square brackets
            string pattern = @"\[(.*?)\]";

            // Find all matches of tags in the title
            MatchCollection matches = Regex.Matches(title, pattern);

            // List of valid notification channels
            List<string> validChannels = new List<string> { "BE", "FE", "QA", "Urgent" };

            foreach (Match match in matches)
            {
                // Extract the tag from the match
                string tag = match.Groups[1].Value;

                // Check if the tag is a valid channel
                if (validChannels.Contains(tag))
                {
                    channels.Add(tag);
                }
            }

            return channels.Distinct().ToList(); // Remove duplicates and return the list
        }
    }
}

