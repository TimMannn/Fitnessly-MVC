using BLL.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace BLL
{
	public class AccountService
	{
		private readonly IAccountData _accountData;

		public AccountService(IAccountData accountData)
		{
			_accountData = accountData;
		}

		public async Task<string> RegisterAsync(RegisterModel model)
		{
			var user = new IdentityUser { UserName = model.UserName, Email = model.Email };
			var result = await _accountData.CreateUserAsync(user, model.Password);
			if (result.Succeeded)
			{
				return "Registration successful";
			}
			return string.Join(", ", result.Errors.Select(e => e.Description));
		}

		public async Task<string> LoginAsync(LoginModel model)
		{
			var result = await _accountData.LoginAsync(model);
			if (result.Succeeded)
			{
				return "Login successful";
			}
			return "Invalid login attempt";
		}

		public async Task LogoutAsync()
		{
			Console.WriteLine("LogoutAsync called");
			await _accountData.LogoutAsync();
		}
	}
}
