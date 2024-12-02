using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BLL
{

	public interface IAccountData
	{
		Task<IdentityUser> GetUserByUsernameAsync(string username);
		Task<IdentityResult> CreateUserAsync(IdentityUser user, string password);
	}

}
