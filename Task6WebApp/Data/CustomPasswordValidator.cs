using Microsoft.AspNetCore.Identity;
using Task6WebApp.Data.Entities;

namespace Task6WebApp.Data;

internal class CustomPasswordValidator : PasswordValidator<User>
{
    public override async Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string password)
    {
        return IdentityResult.Success;
    }
}

internal class CustomPasswordHasher : PasswordHasher<User>
{
    public override PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword)
    {
        return PasswordVerificationResult.Success;
    }
}