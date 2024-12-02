using BLL.Models;
using BLL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
	private readonly IAccountData _accountData;
	private readonly SignInManager<IdentityUser> _signInManager;

	public AccountController(IAccountData accountData, SignInManager<IdentityUser> signInManager)
	{
		_accountData = accountData;
		_signInManager = signInManager;
	}

	[HttpPost("register")]
	public async Task<IActionResult> Register([FromBody] RegisterModel model)
	{
		var user = new IdentityUser { UserName = model.UserName, Email = model.Email };
		var result = await _accountData.CreateUserAsync(user, model.Password);
		if (result.Succeeded)
		{
			return Ok(new { Result = "Registration successful" });
		}
		return BadRequest(new { Error = string.Join(", ", result.Errors.Select(e => e.Description)) });
	}

	[HttpPost("login")]
	public async Task<IActionResult> Login([FromBody] LoginModel model)
	{
		var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
		if (result.Succeeded)
		{
			return Ok(new { Result = "Login successful" });
		}
		return Unauthorized(new { Error = "Invalid login attempt" });
	}
}
