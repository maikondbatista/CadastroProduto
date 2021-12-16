using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Categories.Api.Controllers
{
    public class ApiController : ControllerBase
    {
        protected List<string> _notifications;

        public ApiController()
        {
            _notifications = new List<string>();

        }


        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> ResponseAsync(object result = null)
        {
            if (Valid())
            {
                return await ReturnResult(HttpStatusCode.OK, result);
            }
            else
            {
                return await ReturnResult(HttpStatusCode.BadRequest, GetNotificationsAndValidations());
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private string GetNotificationsAndValidations()
        {
            return string.Join(", ", _notifications);
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

        [ApiExplorerSettings(IgnoreApi = true)]
        private async Task<IActionResult> ReturnResult(HttpStatusCode status)
        {
            return await ReturnResult(status, null);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public bool Valid()
        {
            if (_notifications.Count > 0)
                return false;

            return true;
        }
    }
}
