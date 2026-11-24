using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PoemCollectionHw
{
    public class PoemReportGenerator
    {
        public string CreateReport(string reportTitle, List<Poem> poems)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"=== {reportTitle} ===");
            sb.AppendLine($"Total poems found: {poems.Count}");
            sb.AppendLine();

            if (poems.Count == 0)
            {
                sb.AppendLine("No poems match the criteria.");
                return sb.ToString();
            }

            for (int i = 0; i < poems.Count; i++)
            {
                sb.AppendLine($"--- Poem #{i + 1} ---");
                sb.AppendLine(poems[i].ToString());
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public void PrintReport(string report)
        {
            Console.WriteLine(report);
        }

        public void SaveReportToFile(string report, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(report);
            }
        }
    }
}