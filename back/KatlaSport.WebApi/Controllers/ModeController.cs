using KatlaSport.Services;
using KatlaSport.Services.TransportManagement;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;


namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/mode")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class ModeController : ApiController
    {
        private readonly IRepository<Mode, UpdateModeRequest> _modeRepositoryService;

        public ModeController(IRepository<Mode, UpdateModeRequest> modeRepositoryService)
        {
            _modeRepositoryService = modeRepositoryService ?? throw new ArgumentNullException(nameof(modeRepositoryService));
        }

        [HttpGet]
        [Route("getall")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of modes.", Type = typeof(Mode[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetAllModesAsync()
        {
            var modes = await _modeRepositoryService.GetAllEntitiesAsync();
            return Ok(modes);
        }
        [HttpGet]
        [Route("getone/{modeId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns mode.", Type = typeof(Mode[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetModeAsync(int modeId)
        {
            var modes = await _modeRepositoryService.GetEntityAsync(modeId);
            return Ok(modes);
        }

        [HttpPost]
        [Route("create")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new mode.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddMode([FromBody] UpdateModeRequest createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mode = await _modeRepositoryService.AddEntityAsync(createRequest);
            var location = string.Format("/api/modes/single/{0}", mode.Id);
            return Ok();
        }

        [HttpPost]
        [Route("update/{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates mode.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateMode([FromUri] int id, [FromBody] UpdateModeRequest updateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _modeRepositoryService.UpdateEntityAsync(updateRequest, id);
            return Ok(ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent)).ToString());
        }

        [HttpPost]
        [Route("clean/{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes mode.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteMode([FromUri] int id)
        {
            await _modeRepositoryService.RemoveEntityAsync(id);
            return Ok(ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent)).ToString());
        }

    }
}
