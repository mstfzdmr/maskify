using maskify.api.Exceptions;
using maskify.api.Filters;
using maskify.core;
using maskify.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Rest;
using System.Collections.Generic;
using System.Linq;
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
        #endregion

        #region Ctor
        public MaskController(IMaskify maskify)
        {
            _maskify = maskify;
        }
        #endregion

        #region Actions
        [HttpPost]
        [TransformException(typeof(RestException), HttpStatusCode.InternalServerError, "Error on service")]
        [TransformException(typeof(MessageExceptions), HttpStatusCode.BadRequest, "Error on service")]
        public MaskifyResponse<object> Post([FromBody] MaskifyRequest request)
        {
            if (request.Model.IsArrayModel())
            {
                List<MaskifyObject> maskifyObject = _maskify.Masks(request.Model, request.ReplacedJsonKeyValues, request.Replacement);
                return new MaskifyResponse<object>
                {
                    Data = maskifyObject.Select(o => o.Properties).ToList(),
                    Code = 200
                };
            }
            else
            {
                MaskifyObject maskifyObject = _maskify.Mask(request.Model, request.ReplacedJsonKeyValues, request.Replacement);
                return new MaskifyResponse<object>
                {
                    Data = maskifyObject.Properties,
                    Code = 200
                };
            }
        }
        #endregion
    }
}
