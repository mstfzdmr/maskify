using maskify.api.V1.Models.Requests;
using maskify.api.V1.Models.Responses;
using maskify.core;
using maskify.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maskify.api.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/masks")]
    [ApiExplorerSettings(GroupName = "Masks")]
    public class MaskV1Controller : ControllerBase
    {
        private readonly IMaskify _maskify;

        public MaskV1Controller(IMaskify maskify)
        {
            _maskify = maskify;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MaskifyResponseModel<object>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> Post([FromBody] MaskifyRequestModel request)
        {
            if (request.Model.IsArrayModel())
            {
                List<MaskifyObject> maskifyObject = _maskify.Masks(request.Model, request.ReplacedJsonKeyValues, request.Replacement);
                return Ok(new MaskifyResponseModel<object>
                {
                    Data = maskifyObject.Select(o => o.Properties)
                });
            }
            else
            {
                MaskifyObject maskifyObject = _maskify.Mask(request.Model, request.ReplacedJsonKeyValues, request.Replacement);
                return Ok(new MaskifyResponseModel<object>
                {
                    Data = maskifyObject.Properties
                });
            }
        }
    }
}
