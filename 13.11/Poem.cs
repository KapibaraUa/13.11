using System;

namespace PoemCollectionHw
{
    public class Poem
    {
        private string _title = String.Empty;
        private string _author = String.Empty;
        private int _year;
        private string _text = String.Empty;
        private string _theme = String.Empty;

        public string Title
        {
            get { return _title; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _title = value;
                else
                    throw new ArgumentException("Title cannot be empty");
            }
        }

        public string Author
        {
            get { return _author; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _author = value;
                else
                    throw new ArgumentException("Author cannot be empty");
            }
        }

        public int Year
        {
            get { return _year; }
            set
            {
                if (value > 0 && value <= 2026)
                    _year = value;
                else
                    throw new ArgumentException("Invalid year");
            }
        }

        public string Text
        {
            get { return _text; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _text = value;
                else
                    throw new ArgumentException("Text cannot be empty");
            }
        }

        public string Theme
        {
            get { return _theme; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _theme = value;
                else
                    throw new ArgumentException("Theme cannot be empty");
            }
        }

        public Poem()
        {
            _title = "Untitled";
            _author = "Unknown";
            _year = 2000;
            _text = "No text";
            _theme = "General";
        }

        public Poem(string title, string author, int year, string text, string theme)
        {
            Title = title;
            Author = author;
            Year = year;
            Text = text;
            Theme = theme;
        }

        public override string ToString()
        {
            return $"Title: {Title}\nAuthor: {Author}\nYear: {Year}\nTheme: {Theme}\nLength: {Text.Length}\nText:\n{Text}";
        }
    }
}