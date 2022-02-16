namespace EnglishWords
{
    public class Word
    {
        public Word(string english, string hungarian)
        {
            English = english;
            Hungarian = hungarian;
        }

        public string English { get; }
        public string Hungarian { get; }
    }
}