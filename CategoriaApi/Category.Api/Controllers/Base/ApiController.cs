using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Categories.Api.Controllers
{
    public class ApiController : ControllerBase
    {
        private List<ValidationResult> _validations;
        public ApiController()
        {
            _validations = new List<ValidationResult>();
        }


        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ResponseAsync(object result)
        {
            if(Valid())
            {
                return await ReturnResult(HttpStatusCode.OK, result);
            }
            else
            {
                return await ReturnResult(HttpStatusCode.BadRequest, result);
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private async Task<IActionResult> ReturnResult(HttpStatusCode status, object result) 
        {
            return (status) switch
            {
                HttpStatusCode.NotFound => NotFound(result),

                HttpStatusCode.Conflict => Conflict(result),

                HttpStatusCode.NoContent => NoContent(),

                HttpStatusCode.OK => Ok(result),

                HttpStatusCode.Unauthorized => Unauthorized(result),

                _ => BadRequest(result),
            };
        }

        private async Task<IActionResult> ReturnResult(HttpStatusCode status)
        {
            return await ReturnResult(status, null);
        }

        private bool Valid()
        {
            if (_validations.Count > 0)
                return false;

            return true;
        }
    }
}
