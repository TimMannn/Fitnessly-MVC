using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using BLL.Models;

namespace BLL
{
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Identity;

	public class AccountService
	{
		private readonly IAccountData _accountData;
		private readonly SignInManager<IdentityUser> _signInManager;

		public AccountService(IAccountData accountData, SignInManager<IdentityUser> signInManager)
		{
			_accountData = accountData;
			_signInManager = signInManager;
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
			var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
			if (result.Succeeded)
			{
				return "Login successful";
			}
			return "Invalid login attempt";
		}
	}
}
