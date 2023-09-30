using System;
using System.Collections.Generic;
using System.IO;

public class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
}

public class Journal
{
    private readonly List<JournalEntry> entries = new();
    public string UserName { get; set; }
    public string UserPhoneNumber { get; set; }

    public void WriteNewEntry()
    {
        Console.WriteLine("Random Prompt: " + GetRandomPrompt());
        Console.Write("Your Response: ");
        string response = Console.ReadLine();

        JournalEntry entry = new()
        {
            Prompt = GetRandomPrompt(),
            Response = response,
            Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        };

        entries.Add(entry);
        Console.WriteLine("Entry added successfully!");
    }

    public void DisplayJournal()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine();
        }
    }

    public void SaveJournalToFile(string fileName)
    {
        using (StreamWriter writer = new(fileName))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
            }
        }
        Console.WriteLine("Journal saved to file successfully!");
    }

    public void LoadJournalFromFile(string fileName)
    {
        entries.Clear();
        try
        {
            using (StreamReader reader = new(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string[] values = reader.ReadLine().Split(',');
                    JournalEntry entry = new()
                    {
                        Date = values[0],
                        Prompt = values[1],
                        Response = values[2]
                    };
                    entries.Add(entry);
                }
            }
            Console.WriteLine("Journal loaded from file successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading journal: " + ex.Message);
        }
    }
    public void SetUserDetails()
    {
        Console.Write("Enter your name: ");
        UserName = Console.ReadLine();

        Console.Write("Enter your phone: ");
        UserPhoneNumber = Console.ReadLine();

        Console.WriteLine("User details updated successfully!");
    }

    public void DisplayJournalWithUserInfo()
    {
        Console.WriteLine($"User Details - Name: {UserName}, Phone number: {UserPhoneNumber}\n");

        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine();
        }
    }

    public int GetTotalEntries()
    {
        return entries.Count;
    }

    private string GetRandomPrompt()
    {
        List<string> prompts = new()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "What was the worst part of my day?",
            "What is something I learned today?",
            "What is something I wish I could do over?",
            "What is something I wish I could do again?",
            "What is something I wish I could do more often?",
            "What is something I wish I could do less often?",
            "What is something I wish I could do for the first time?",
            "What is something I wish I could do for the last time?",
            "What is something I wish I could do with someone else?",
            "What is something I wish I could do by myself?",
            "What is something I wish I could do for someone else?",

        };

        Random random = new();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}

class Program
{
    static void Main()
    {
        Journal journal = new();

        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Display the journal with user info");
            Console.WriteLine("4. Save the journal to a file");
            Console.WriteLine("5. Load the journal from a file");
            Console.WriteLine("6. Set user details");
            Console.WriteLine("7. View basic statistics");
            Console.WriteLine("8. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    journal.WriteNewEntry();
                    break;
                case 2:
                    journal.DisplayJournal();
                    break;
                case 3:
                    journal.DisplayJournalWithUserInfo();
                    break;
                case 4:
                    Console.Write("Enter filename to save: ");
                    string saveFileName = Console.ReadLine();
                    journal.SaveJournalToFile(saveFileName);
                    break;
                case 5:
                    Console.Write("Enter filename to load: ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadJournalFromFile(loadFileName);
                    break;
                case 6:
                    journal.SetUserDetails();
                    break;
                case 7:
                    Console.WriteLine($"Total Entries: {journal.GetTotalEntries()}");
                    break;
                case 8:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
