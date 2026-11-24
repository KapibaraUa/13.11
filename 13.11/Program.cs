using System;
using System.Collections.Generic;

namespace PoemCollectionHw
{
    internal class Program
    {
        static Poem ReadPoemFromConsole()
        {
            Console.Write("Enter title: ");
            string title = Console.ReadLine() ?? String.Empty;

            Console.Write("Enter author full name: ");
            string author = Console.ReadLine() ?? String.Empty;

            Console.Write("Enter year: ");
            int year = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter theme: ");
            string theme = Console.ReadLine() ?? String.Empty;

            Console.Write("Enter text: ");
            string text = Console.ReadLine() ?? String.Empty;

            return new Poem(title, author, year, text, theme);
        }

        static void OutputReport(PoemReportGenerator generator, string reportTitle, List<Poem> poems)
        {
            string report = generator.CreateReport(reportTitle, poems);

            Console.WriteLine("1. Show report on screen");
            Console.WriteLine("2. Save report to file");
            Console.Write("Choose output option: ");
            string outputChoice = Console.ReadLine() ?? String.Empty;

            if (outputChoice == "1")
            {
                Console.WriteLine();
                generator.PrintReport(report);
            }
            else if (outputChoice == "2")
            {
                Console.Write("Enter file path for report: ");
                string reportPath = Console.ReadLine() ?? String.Empty;
                generator.SaveReportToFile(report, reportPath);
                Console.WriteLine("Report saved successfully.");
            }
            else
            {
                Console.WriteLine("Invalid output option.");
            }
        }

        static void Main(string[] args)
        {
            PoemManager manager = new PoemManager();
            PoemReportGenerator reportGenerator = new PoemReportGenerator();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Add poem");
                Console.WriteLine("2. Remove poem");
                Console.WriteLine("3. Edit poem");
                Console.WriteLine("4. Show all poems");
                Console.WriteLine("5. Save poems to file");
                Console.WriteLine("6. Load poems from file");
                Console.WriteLine("7. Report by title");
                Console.WriteLine("8. Report by author");
                Console.WriteLine("9. Report by theme");
                Console.WriteLine("10. Report by word in text");
                Console.WriteLine("11. Report by year");
                Console.WriteLine("12. Report by length");
                Console.WriteLine("0. Exit");
                Console.Write("Select option: ");

                string choice = Console.ReadLine() ?? String.Empty;
                Console.WriteLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Poem newPoem = ReadPoemFromConsole();
                            manager.AddPoem(newPoem);
                            Console.WriteLine("Poem added.");
                            break;

                        case "2":
                            Console.Write("Enter title of poem to remove: ");
                            string removeTitle = Console.ReadLine() ?? String.Empty;
                            if (manager.RemovePoem(removeTitle))
                                Console.WriteLine("Poem removed.");
                            else
                                Console.WriteLine("Poem not found.");
                            break;

                        case "3":
                            Console.Write("Enter title of poem to edit: ");
                            string editTitle = Console.ReadLine() ?? String.Empty;
                            Poem updatedPoem = ReadPoemFromConsole();
                            if (manager.UpdatePoem(editTitle, updatedPoem))
                                Console.WriteLine("Poem updated.");
                            else
                                Console.WriteLine("Poem not found.");
                            break;

                        case "4":
                            List<Poem> allPoems = manager.GetAllPoems();
                            string allReport = reportGenerator.CreateReport("All Poems", allPoems);
                            reportGenerator.PrintReport(allReport);
                            break;

                        case "5":
                            Console.Write("Enter file path to save: ");
                            string savePath = Console.ReadLine() ?? String.Empty;
                            manager.SaveToFile(savePath);
                            Console.WriteLine("Collection saved.");
                            break;

                        case "6":
                            Console.Write("Enter file path to load: ");
                            string loadPath = Console.ReadLine() ?? String.Empty;
                            manager.LoadFromFile(loadPath);
                            Console.WriteLine("Collection loaded.");
                            break;

                        case "7":
                            Console.Write("Enter title to search: ");
                            string searchTitle = Console.ReadLine() ?? String.Empty;
                            OutputReport(reportGenerator, $"Report by Title: {searchTitle}", manager.FindByTitle(searchTitle));
                            break;

                        case "8":
                            Console.Write("Enter author to search: ");
                            string searchAuthor = Console.ReadLine() ?? String.Empty;
                            OutputReport(reportGenerator, $"Report by Author: {searchAuthor}", manager.FindByAuthor(searchAuthor));
                            break;

                        case "9":
                            Console.Write("Enter theme to search: ");
                            string searchTheme = Console.ReadLine() ?? String.Empty;
                            OutputReport(reportGenerator, $"Report by Theme: {searchTheme}", manager.FindByTheme(searchTheme));
                            break;

                        case "10":
                            Console.Write("Enter word to search in text: ");
                            string searchWord = Console.ReadLine() ?? String.Empty;
                            OutputReport(reportGenerator, $"Report by Word: {searchWord}", manager.FindByWordInText(searchWord));
                            break;

                        case "11":
                            Console.Write("Enter year: ");
                            int searchYear = Convert.ToInt32(Console.ReadLine());
                            OutputReport(reportGenerator, $"Report by Year: {searchYear}", manager.FindByYear(searchYear));
                            break;

                        case "12":
                            Console.Write("Enter minimum length: ");
                            int minLength = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter maximum length: ");
                            int maxLength = Convert.ToInt32(Console.ReadLine());
                            OutputReport(reportGenerator, $"Report by Length: {minLength}-{maxLength}", manager.FindByLength(minLength, maxLength));
                            break;

                        case "0":
                            return;

                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}