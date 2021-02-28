using maskify.api.Exceptions;
using maskify.api.Filters;
using maskify.core;
using maskify.models;
using Microsoft.AspNetCore.Mvc;
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

        private readonly IMaskify _maskify;
        private readonly ILogger<MaskController> _logger;

        #endregion

        #region Ctor

        public MaskController(IMaskify maskify, ILogger<MaskController> logger)
        {
            _maskify = maskify;
            _logger = logger;
        }

        #endregion

        #region Actions

        [HttpPost]
        [TransformException(typeof(RestException), HttpStatusCode.InternalServerError, "Error on service")]
        [TransformException(typeof(MessageExceptions), HttpStatusCode.BadRequest, "")]
        public MaskifyResponse<object> Post([FromBody] MaskifyRequest request)
        {
            MaskifyObject maskifyObject = _maskify.Mask(request.Model, request.ReplacedJsonKeyValues, request.Replacement);
            return new MaskifyResponse<object>
            {
                Data = maskifyObject.Properties,
                Code = 200
            };
        }

        #endregion
    }
}
