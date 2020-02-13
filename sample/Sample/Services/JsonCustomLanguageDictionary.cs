using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Services
{
    public class JsonCustomLanguageDictionary : ILanguageDictionary
    {
        private readonly Func<string, Task<string>> jsonGetter;
        private Dictionary<string, string> locale;

        /* CTOR */

        public JsonCustomLanguageDictionary(Func<string, Task<string>> jsonGetter)
        {
            this.jsonGetter = jsonGetter;
        }

        /* PROP */

        public string this[string key] => locale[key];

        public string LanguageKey { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        /* METHODE */

        public async Task SetLanguage(string langKey)
        {
            string text = await jsonGetter(langKey);
            Console.WriteLine(text);
            locale = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(text);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(langKey)));
        }
    }
}
