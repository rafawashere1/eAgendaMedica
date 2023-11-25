using AutoMapper;
using eAgendaMedica.Application.AuthModule;
using eAgendaMedica.Domain.AuthModule;
using eAgendaMedica.WebApi.Config.Extensions;
using eAgendaMedica.WebApi.Shared;
using eAgendaMedica.WebApi.ViewModels.AuthModule;
using Microsoft.AspNetCore.Mvc;

namespace eAgendaMedica.WebApi.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AuthController : ApiControllerBase
    {
        private readonly AuthAppService _authService;
        private readonly IMapper _mapper;

        public AuthController(AuthAppService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserViewModel viewModel)
        {
            var user = _mapper.Map<User>(viewModel);

            var userResult = await _authService.RegisterAsync(user, viewModel.Password);

            if (userResult.IsFailed)
                return BadRequest(userResult.Errors);

            var tokenViewModel = user.GenerateJwt(DateTime.Now.AddDays(5));

            return Ok(tokenViewModel);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserViewModel viewModel)
        {
            var userResult = await _authService.Login(viewModel.Login, viewModel.Password);

            if (userResult.IsFailed)
                return BadRequest(userResult.Errors);

            var user = userResult.Value;

            var tokenViewModel = user.GenerateJwt(DateTime.Now.AddDays(5));

            return Ok(tokenViewModel);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.Logout();

            return Ok();
        }
    }
}
