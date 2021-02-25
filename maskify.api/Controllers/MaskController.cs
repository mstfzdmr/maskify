using maskify.api.Exceptions;
using maskify.api.Filters;
using maskify.api.Models;
using maskify.core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Rest;
using System.Net;

namespace maskify.api.Controllers
{
    [ApiController]
    [Consumes("application/json")]
    [Route("api/mask")]
    public class MaskController : ControllerBase
    {
        #region Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<MaskController> _logger;
        
        #endregion

        #region Ctor
        
        public MaskController(IHttpContextAccessor httpContextAccessor, ILogger<MaskController> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        #endregion

        #region Actions
        
        [HttpPost]
        [TransformException(typeof(RestException), HttpStatusCode.InternalServerError, "Error on service")]
        [TransformException(typeof(MessageExceptions), HttpStatusCode.BadRequest, "")]
        public Response<T> Post<T>([FromBody] Request<T> request)
        {
            using (var scope = _httpContextAccessor.HttpContext.RequestServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<IMaskify<T>>();
                return new Response<T>
                {
                    Data = context.Mask(request.Model, request.KeyValueJsonModel, request.Replacement),
                    Code = 200
                };
            }
        }
        
        #endregion
    }
}
