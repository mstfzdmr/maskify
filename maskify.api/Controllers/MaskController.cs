using maskify.api.Models;
using maskify.core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace maskify.api.Controllers
{
    [Consumes("application/json")]
    public class MaskController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MaskController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [Route("api/mask")]
        public IActionResult Mask<T>([FromBody] RequestModel<T> request)
        {
            using (var scope = _httpContextAccessor.HttpContext.RequestServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<IMaskify<T>>();
                var response = context.Mask(request.Model, request.KeyValueJsonModel, request.Replacement);
                return Ok(response);
            }
        }
    }
}
