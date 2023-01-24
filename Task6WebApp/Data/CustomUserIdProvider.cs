using Microsoft.AspNetCore.SignalR;

namespace Task6WebApp.Data;

public class CustomUserIdProvider : IUserIdProvider
{
    public string GetUserId(HubConnectionContext connection)
    {
        return connection.User.Identity.Name;
    }
}