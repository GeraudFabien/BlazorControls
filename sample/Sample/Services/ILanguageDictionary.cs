using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Services
{
    public interface ILanguageDictionary : INotifyPropertyChanged
    {
        string this[string key] { get; }
        
        string LanguageKey { get; }

        /// <summary>
        /// Set the language and load the correct dictionary
        /// </summary>
        /// <param name="langKey">639-1 language code</param>
        Task SetLanguage(string langKey);
    }
}
