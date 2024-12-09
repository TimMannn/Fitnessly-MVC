using BLL.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

public interface IAccountData
{
	Task<IdentityResult> CreateUserAsync(IdentityUser user, string password);
	Task<SignInResult> LoginAsync(LoginModel model);
	Task LogoutAsync();
	Task<IdentityUser> FindByUserNameAsync(string userName); // Voeg deze methode toe
}
