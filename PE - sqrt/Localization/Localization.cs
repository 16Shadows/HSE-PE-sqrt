using System.IO;
using System.Collections.Generic;

namespace PE___sqrt.Localization
{
    static class Localization
    {
        public sealed class LanguageEntry
        {
            public string LanguageName { get; private set; }
            private readonly Dictionary<string, string> Phrases;

            public LanguageEntry(string name)
            {
                LanguageName = name;
                Phrases = new Dictionary<string, string>();
            }

            public LanguageEntry(string name, Dictionary<string, string> phrases)
            {
                LanguageName = name;
                Phrases = phrases;
            }

            public string GetPhrase(string key)
            {
                if(key != null && key.Length > 0 && Phrases.TryGetValue(key, out string phrase)) return phrase;
                else return "Error";
            }
        }

        static Localization()
        {
            Languages = new Dictionary<string, LanguageEntry>();
        }

        static public Dictionary<string, LanguageEntry> Languages { get; private set; }

        public static bool Load(string file = "locale.dat")
        {
            if(file == null) return false;

            Languages.Clear();

            try
            {
                using(StreamReader reader = new StreamReader(file))
                {
                    string line = null;

                    int index;
                    bool languageEntry = false;
                    string languageKey = null;
                    string languageName = null;
                    Dictionary<string, string> languagePhrases = null;

                    while( (line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("LANGUAGE "))
                        {
                            if (languageEntry) return false;
                            else
                            {
                                languageKey = line.Substring(9);
                                if (languageKey?.Length > 0)
                                {
                                    languageEntry = true;
                                    languageName = null;
                                    languagePhrases = new Dictionary<string, string>();
                                }
                                else return false;
                            }
                        }
                        else if (line.StartsWith("ENDLANGUAGE"))
                        {
                            if(!languageEntry) return false;
                            else
                            {
                                languageEntry = false;
                                Languages.Add(languageKey, new LanguageEntry(languageName, languagePhrases));
                            }
                        }
                        else if(languageEntry)
                        {
                            if(line.StartsWith("LanguageName "))
                            {
                                if(languageName != null) return false;
                                else
                                {
                                    languageName = line.Substring(13);
                                    if(languageName?.Length == 0) return false;
                                }
                            }
                            else if( (index = line.IndexOf(' ')) != -1 ) languagePhrases.Add(line.Substring(0, index), line.Substring(index+1) );
                        }
                    }

                }
            }
            catch { }

            return true;
        }
    }
}
