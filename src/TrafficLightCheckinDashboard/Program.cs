using Dashboard;
using Dashboard.Helpers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiUrl = builder.Configuration["ApiUrl"];
ArgumentNullException.ThrowIfNull(apiUrl, nameof(apiUrl));
builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(apiUrl) });
builder.Services.AddSingleton<ApiHelper>();

await builder.Build().RunAsync();
