using MTGMVC.Clients;
using MTGMVC.Repositories;
using MTGMVC.Repositories.CommandText;
using MTGMVC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("MTG", (serviceProvider, httpClient) =>
{
    //var mtgSettings = serviceProvider.GetRequiredService<IOptions<MtgSettings>>().Value;
    httpClient.BaseAddress = new Uri("https://api.magicthegathering.io/v1/");
});
builder.Services.AddHttpClient("Scryfall", (serviceProvider, httpClient) =>
{
    //var mtgSettings = serviceProvider.GetRequiredService<IOptions<MtgSettings>>().Value;
    httpClient.BaseAddress = new Uri("https://api.scryfall.com/");
});

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("RedisConnection");
    options.InstanceName = "mtg-redis";
});

//Register own services
builder.Services.AddScoped<IMTGService, MTGService>();
builder.Services.AddScoped<IMTGClient, MTGClient>();
builder.Services.AddScoped<IScryfallClient, ScryfallClient>();
builder.Services.AddTransient<ICommandText, CommandText>();
builder.Services.AddTransient<ISetRepository, SetRepository>();
builder.Services.AddTransient<IMagicDataWriterService, MagicDataWriterService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
