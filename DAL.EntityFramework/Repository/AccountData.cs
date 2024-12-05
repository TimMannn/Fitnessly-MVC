using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DAL.EntityFramework.Repository
{
	public class AccountData : IAccountData
	{
		private readonly UserManager<IdentityUser> _userManager;

		public AccountData(UserManager<IdentityUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IdentityUser> GetUserByUsernameAsync(string username)
		{
			return await _userManager.FindByNameAsync(username);
		}

		public async Task<IdentityResult> CreateUserAsync(IdentityUser user, string password)
		{
			return await _userManager.CreateAsync(user, password);
		}
	}
}
