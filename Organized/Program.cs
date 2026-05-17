using Organized.Application.Achievements;
using Organized.Application.Friends;
using Organized.Application.Meetings;
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
builder.Services.AddScoped<UpdateUserLastOnlineRequestHandler>();
builder.Services.AddScoped<GetUserProfileRequestHandler>();
builder.Services.AddScoped<UpdateUserDisplayNameRequestHandler>();
builder.Services.AddScoped<GetAllUsersForAdminRequestHandler>();
builder.Services.AddScoped<SearchUsersForMeetingRequestHandler>();

builder.Services.AddScoped<GetAllTablesRequestHandler>();

builder.Services.AddScoped<CreateReservationRequestHandler>();
builder.Services.AddScoped<GetUserReservationsRequestHandler>();
builder.Services.AddScoped<CancelReservationRequestHandler>();
builder.Services.AddScoped<GetReservedDatesForTableRequestHandler>();
builder.Services.AddScoped<GetReservationsByDateRequestHandler>();

builder.Services.AddScoped<GetUserAchievementsRequestHandler>();
builder.Services.AddScoped<AchievementTracker>();

builder.Services.AddScoped<SendFriendRequestRequestHandler>();
builder.Services.AddScoped<GetPendingFriendRequestsRequestHandler>();
builder.Services.AddScoped<AcceptFriendRequestRequestHandler>();
builder.Services.AddScoped<DeclineFriendRequestRequestHandler>();
builder.Services.AddScoped<GetUserFriendsRequestHandler>();
builder.Services.AddScoped<RemoveFriendRequestHandler>();
builder.Services.AddScoped<SearchUsersRequestHandler>();

builder.Services.AddScoped<CreateMeetingRequestHandler>();
builder.Services.AddScoped<CancelMeetingRequestHandler>();
builder.Services.AddScoped<GetMeetingsCreatedByAdminRequestHandler>();
builder.Services.AddScoped<GetMeetingDetailsRequestHandler>();
builder.Services.AddScoped<GetUserMeetingInvitesRequestHandler>();
builder.Services.AddScoped<GetUserUpcomingMeetingsRequestHandler>();
builder.Services.AddScoped<AcceptMeetingInviteRequestHandler>();
builder.Services.AddScoped<DeclineMeetingInviteRequestHandler>();
builder.Services.AddScoped<GetMeetingRoomsRequestHandler>();

var app = builder.Build();

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
