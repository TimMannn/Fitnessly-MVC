using Microsoft.AspNetCore.Identity;
using BLL;
using BLL.Models;
using System.Threading.Tasks;

namespace DAL.EntityFramework.Repository
{
	public class AccountData : IAccountData
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;

		public AccountData(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public async Task<IdentityResult> CreateUserAsync(IdentityUser user, string password)
		{
			return await _userManager.CreateAsync(user, password);
		}

		public async Task<SignInResult> LoginAsync(LoginModel model)
		{
			return await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
		}

		public async Task LogoutAsync()
		{
			await _signInManager.SignOutAsync();
		}
	}
}