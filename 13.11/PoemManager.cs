using System;
using System.Collections.Generic;
using System.IO;

namespace PoemCollectionHw
{
    public class PoemManager
    {
        private List<Poem> _poems = new List<Poem>();

        public void AddPoem(Poem poem)
        {
            if (poem == null)
                throw new ArgumentNullException(nameof(poem));

            _poems.Add(poem);
        }

        public bool RemovePoem(string title)
        {
            for (int i = 0; i < _poems.Count; i++)
            {
                if (_poems[i].Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    _poems.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public bool UpdatePoem(string oldTitle, Poem updatedPoem)
        {
            if (updatedPoem == null)
                throw new ArgumentNullException(nameof(updatedPoem));

            for (int i = 0; i < _poems.Count; i++)
            {
                if (_poems[i].Title.Equals(oldTitle, StringComparison.OrdinalIgnoreCase))
                {
                    _poems[i] = updatedPoem;
                    return true;
                }
            }

            return false;
        }

        public List<Poem> GetAllPoems()
        {
            return new List<Poem>(_poems);
        }

        public List<Poem> FindByTitle(string title)
        {
            List<Poem> result = new List<Poem>();

            foreach (Poem poem in _poems)
            {
                if (poem.Title.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    result.Add(poem);
                }
            }

            return result;
        }

        public List<Poem> FindByAuthor(string author)
        {
            List<Poem> result = new List<Poem>();

            foreach (Poem poem in _poems)
            {
                if (poem.Author.IndexOf(author, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    result.Add(poem);
                }
            }

            return result;
        }

        public List<Poem> FindByTheme(string theme)
        {
            List<Poem> result = new List<Poem>();

            foreach (Poem poem in _poems)
            {
                if (poem.Theme.IndexOf(theme, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    result.Add(poem);
                }
            }

            return result;
        }

        public List<Poem> FindByYear(int year)
        {
            List<Poem> result = new List<Poem>();

            foreach (Poem poem in _poems)
            {
                if (poem.Year == year)
                {
                    result.Add(poem);
                }
            }

            return result;
        }

        public List<Poem> FindByWordInText(string word)
        {
            List<Poem> result = new List<Poem>();

            foreach (Poem poem in _poems)
            {
                if (poem.Text.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    result.Add(poem);
                }
            }

            return result;
        }

        public List<Poem> FindByLength(int minLength, int maxLength)
        {
            List<Poem> result = new List<Poem>();

            foreach (Poem poem in _poems)
            {
                if (poem.Text.Length >= minLength && poem.Text.Length <= maxLength)
                {
                    result.Add(poem);
                }
            }

            return result;
        }

        public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Poem poem in _poems)
                {
                    string safeText = poem.Text.Replace("\r\n", "\\n").Replace("\n", "\\n");
                    writer.WriteLine($"{poem.Title}|{poem.Author}|{poem.Year}|{poem.Theme}|{safeText}");
                }
            }
        }

        public void LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found", filePath);

            List<Poem> loadedPoems = new List<Poem>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 5 && int.TryParse(parts[2], out int year))
                    {
                        string restoredText = parts[4].Replace("\\n", Environment.NewLine);
                        Poem poem = new Poem(parts[0], parts[1], year, restoredText, parts[3]);
                        loadedPoems.Add(poem);
                    }
                }
            }

            _poems = loadedPoems;
        }
    }
}