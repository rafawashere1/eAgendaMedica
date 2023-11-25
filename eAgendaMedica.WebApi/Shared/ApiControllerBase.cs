using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace eAgendaMedica.WebApi.Shared
{
    public class ApiControllerBase : ControllerBase
    {
        public override OkObjectResult Ok(object? value)
        {
            return base.Ok(new
            {
                Success = true,
                Data = value
            });
        }

        public override NotFoundObjectResult NotFound(object? value)
        {
            var errorMessages = ((IList<IError>)value).Select(x => x.Message);

            return base.NotFound(new
            {
                Success = false,
                Errors = errorMessages
            });
        }

        public override BadRequestObjectResult BadRequest(object? value)
        {
            var errorMessages = ((IList<IError>)value).Select(x => x.Message);

            return base.BadRequest(new
            {
                Success = false,
                Errors = errorMessages
            });
        }
    }
}
