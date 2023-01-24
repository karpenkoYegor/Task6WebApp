using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace Task6WebApp.Hubs;

public class MessageHub : Hub
{
    public async Task Send(string message, string to)
    {
        var user = Context.User;
        var userName = user.Identity.Name;;
    }
}