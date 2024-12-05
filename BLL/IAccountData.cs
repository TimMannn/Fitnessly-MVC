using Microsoft.AspNetCore.Identity;
using BLL.Models;
using System.Threading.Tasks;

namespace BLL
{
	public interface IAccountData
	{
		Task<IdentityResult> CreateUserAsync(IdentityUser user, string password);
		Task<SignInResult> LoginAsync(LoginModel model);
		Task LogoutAsync();
	}
}
