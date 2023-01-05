using Netcompany.RoutePlanning.Core;
using Netcompany.RoutePlanning.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSimpleAuthentication();
builder.Services.AddApiTokenAuthorization(builder.Configuration);
builder.Services.AddInmemoryDatabase();
builder.Services.AddRoutePlanningDomain(builder.Configuration);

var app = builder.Build();

await app.InitializeDatabase();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
