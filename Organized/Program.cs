using Organized.Application.Reservations;
using Organized.Application.Tables;
using Organized.Application.Users.User;
using Organized.Components;
using Organized.Infrastructure.Database;
using Organized.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddScoped<UserStateService>();

builder.Services.AddScoped<CreateUserRequestHandler>();
builder.Services.AddScoped<GetUserByEmailRequestHandler>();

builder.Services.AddScoped<GetAllTablesRequestHandler>();

builder.Services.AddScoped<CreateReservationRequestHandler>();
builder.Services.AddScoped<GetUserReservationsRequestHandler>();
builder.Services.AddScoped<CancelReservationRequestHandler>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
