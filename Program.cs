using MudBlazor.Services;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddValidatorsFromAssemblyContaining<FluentBuilderDemo_BlazorServer.Pages.OrderVmValidator>();
var app = builder.Build();

if (!app.Environment.IsDevelopment()) { 
    app.UseExceptionHandler("/Error"); 
    app.UseHsts();
}
app.UseHttpsRedirection(); 
app.UseStaticFiles(); 
app.UseRouting();
app.MapBlazorHub(); 
app.MapFallbackToPage("/_Host");
app.Run();
