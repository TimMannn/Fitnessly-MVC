using BLL.Models;
using BLL;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
	private readonly AccountService _accountService;

	public AccountController(AccountService accountService)
	{
		_accountService = accountService;
	}

	[HttpPost("register")]
	public async Task<IActionResult> Register([FromBody] RegisterModel model)
	{
		var result = await _accountService.RegisterAsync(model);
		if (result == "Registration successful")
		{
			return Ok(new { Result = "Registration successful" });
		}
		return BadRequest(new { Error = result });
	}

	[HttpPost("login")]
	public async Task<IActionResult> Login([FromBody] LoginModel model)
	{
		var result = await _accountService.LoginAsync(model);
		if (result == "Login successful")
		{
			return Ok(new { Result = "Login successful" });
		}
		return Unauthorized(new { Error = result });
	}

	[HttpPost("logout")]
	public async Task<IActionResult> Logout()
	{
		Console.WriteLine("API aangeroepen");
		await _accountService.LogoutAsync();
		return Ok(new { message = "Logged out successfully" });
	}

}
