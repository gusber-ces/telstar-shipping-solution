using Netcompany.Net.Cqs;
using Netcompany.Net.ErrorHandling;
using Netcompany.Net.Logging.Serilog;
using Netcompany.Net.UnitOfWork;
using Netcompany.Net.Validation;
using RoutePlanning.Application;
using RoutePlanning.Infrastructure;
using RoutePlanning.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRoutePlanningInfrastructure();
builder.Services.AddRoutePlanningApplication();

builder.Services.AddCqs(options => options.UseValidation().UseUnitOfWork());
builder.Services.AddUnhandledExceptionMiddleware();
builder.Services.AddValidationMiddleware();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSimpleAuthentication();
builder.Services.AddApiTokenAuthorization(builder.Configuration);

builder.Host.ConfigureLogging(loggingBuilder => loggingBuilder.ClearProviders());
builder.Host.UseNetcompanyLogging(nameof(RoutePlanning.Web));

var app = builder.Build();

await DatabaseInitialization.SeedDatabase(app);

app.UseUnhandledExceptionMiddleware();
app.UseValidationMiddleware();

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
