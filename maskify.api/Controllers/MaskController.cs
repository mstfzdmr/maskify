using maskify.core;
using maskify.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<string>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
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
