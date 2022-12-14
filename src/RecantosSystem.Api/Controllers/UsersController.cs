using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecantosSystem.Api.DTOs;
using RecantosSystem.Api.Interfaces;
using RecantosSystem.Api.Services.Logging;

namespace RecantosSystem.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[ApiConventionType(typeof(DefaultApiConventions))]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly LogService _logService;
		public UsersController(IUserService userService, LogService logService)
		{
			_userService = userService;
			_logService = logService;
		}

		/// <summary>
		/// Registers a new user to the system.
		/// </summary>
		/// <param name="userDto">The User data transfer object to register the new one.</param>
		/// <returns></returns>
		[HttpPost("register")]
		public async Task<ActionResult> Register([FromBody] UserDTO userDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("The user data is incorrect!");
			}
			return Ok(await _userService.RegisterUser(userDto));
		}

		/// <summary>
		/// Logs an existing user in the system.
		/// </summary>
		/// <param name="loginDto">The login data transfer object.</param>
		/// <returns></returns>
		[HttpPost("login")]
		public async Task<ActionResult> Login([FromBody] LoginDTO loginDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("The login data is incorrect");
			}

			return Ok(await _userService.Login(loginDto));
		}
	}
}