using eAgendaMedica.Domain.AuthModule;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace eAgendaMedica.Application.AuthModule
{
    public class AuthAppService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthAppService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Result<User>> RegisterAsync(User user, string password)
        {
            Result result = ValidateUser(user);

            if (result.IsFailed)
                return Result.Fail(result.Errors);

            IdentityResult identityResult = await _userManager.CreateAsync(user, password);

            if (identityResult.Succeeded == false)
                return Result.Fail(identityResult.Errors
                    .Select(error => new Error(error.Description)));

            return Result.Ok(user);
        }

        public async Task<Result<User>> Login(string login, string password)
        {
            var loginResult = await _signInManager.PasswordSignInAsync(login, password, false, false);

            var errors = new List<IError>();

            if (loginResult.IsLockedOut)
                errors.Add(new Error("O acesso para este usuário foi bloqueado"));

            if (loginResult.IsNotAllowed)
                errors.Add(new Error("O login ou a senha estão incorretas"));

            if (!loginResult.Succeeded)
                errors.Add(new Error("O login ou a senha estão incorretas"));

            if (errors.Count > 0)
                return Result.Fail(errors);

            var user = await _userManager.FindByNameAsync(login);

            return Result.Ok(user);
        }

        public async Task<Result<User>> Logout()
        {
            await _signInManager.SignOutAsync();

            return Result.Ok();
        }

        private static Result ValidateUser(User user)
        {
            var validator = new UserValidator();

            var validationResult = validator.Validate(user);

            List<Error> errors = new();

            foreach (var error in validationResult.Errors)
                errors.Add(new Error(error.ErrorMessage));

            if (errors.Any())
                return Result.Fail(errors);

            return Result.Ok();
        }
    }
}
