using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Sample.Services;
using Sample.Services;
using Microsoft.AspNetCore.Components;
using System.Net.Http;

namespace Sample
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            // Services
            builder.Services.AddSingleton<NavBarService>();

            // TODO : This is a mess for now
            builder.Services.AddSingleton<ILanguageDictionary, JsonCustomLanguageDictionary>((sp)=> {
                JsonCustomLanguageDictionary dictionary = new JsonCustomLanguageDictionary(async (key) => {
                    // Get URl
                    string url = sp.GetRequiredService<NavigationManager>().BaseUri;
                    url += $"Dictionary/{key.ToLower()}.json";

                    return await sp.GetRequiredService<HttpClient>().GetStringAsync(url);
                });
                
                return dictionary;
            });

            var webhost = builder.Build();
            await webhost.Services.GetRequiredService<ILanguageDictionary>().SetLanguage("en");

            await webhost.RunAsync();


        }
    }
}
