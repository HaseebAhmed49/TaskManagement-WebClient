using System.Net.Http.Headers;
using TaskManagement_WebClient.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

// Specify WebAPI base address
ClientHttp.client.BaseAddress = new Uri("https://localhost:7040");

// Specify headers
var val = "application/json";
var media = new MediaTypeWithQualityHeaderValue(val);
ClientHttp.client.DefaultRequestHeaders.Accept.Clear();
ClientHttp.client.DefaultRequestHeaders.Accept.Add(media);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Task}/{action=Index}/{id?}");

app.Run();

