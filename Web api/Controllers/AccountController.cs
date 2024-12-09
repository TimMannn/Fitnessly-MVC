using BLL.Models;
using BLL;
using Microsoft.AspNetCore.Mvc;

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
		Console.WriteLine("Login API");
		var token = await _accountService.LoginAsync(model); // Gebruik de gegenereerde token
		if (token == "Invalid login attempt")
		{
			Console.WriteLine("Login API Fail");
			return Unauthorized(new { Error = token });
		}
		Console.WriteLine("Login API Success");
		return Ok(new { Token = token }); // Stuur de token terug in de response
	}

	[HttpPost("logout")]
	public async Task<IActionResult> Logout()
	{
		await _accountService.LogoutAsync();
		return Ok(new { message = "Logged out successfully" });
	}
}
