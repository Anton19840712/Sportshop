using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using KatlaSport.Services.SportNutritionSubClassManagement;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/sportNutritionSubClasses")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class SportNutritionSubClassesController : ApiController
    {
        private readonly ISportNutritionSubClassService _sportNutritionSubClassService;
        public SportNutritionSubClassesController(ISportNutritionSubClassService sportNutritionSubClassService)
        {
            _sportNutritionSubClassService = sportNutritionSubClassService ?? throw new ArgumentNullException(nameof(sportNutritionSubClassService));
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of sportNutritionSubClasses.", Type = typeof(SportNutritionSubClass[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetSportNutritionSubClasses()
        {
            var sportNutritionSubClasses = await _sportNutritionSubClassService.GetSportNutritionSubClassesAsync();
            return Ok(sportNutritionSubClasses);
        }

        [HttpGet]
        [Route("{sportNutritionSubClassId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a sportNutritionSubClass.", Type = typeof(SportNutritionSubClass))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetSportNutritionSubClass(int sportNutritionSubClassID)
        {
            var sportNutritionSubClass = await _sportNutritionSubClassService.GetSportNutritionSubClassAsync(sportNutritionSubClassID);
            return Ok(sportNutritionSubClass);
        }

        [HttpPost]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new sportNutritionSubClass.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddSportNutritionSubClass([FromBody] UpdateSportNutritionSubClassRequest createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sportNutritionSubClass = await _sportNutritionSubClassService.CreateSportNutritionSubClassAsync(createRequest);
            var location = string.Format("/api/subClasses/{0}", sportNutritionSubClass.SportNutritionSubClassID);
            return Created<SportNutritionSubClass>(location, sportNutritionSubClass);
        }

        [HttpPut]
        [Route("{sportNutritionSubClassID:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed sportNutritionSubClass.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateSportNutritionSubClass([FromUri] int sportNutritionSubClassID, [FromBody] UpdateSportNutritionSubClassRequest updateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MultipartMemoryStreamProvider provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);

            //var location = string.Format("/api/images/{0}", sportNutritionProductImage.SportNutritionProductImageID);
            //return Created<SportNutritionProductImage>(location, sportNutritionProductImage);

            await _sportNutritionSubClassService.UpdateSportNutritionSubClassAsync(sportNutritionSubClassID, updateRequest);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpDelete]
        [Route("{sportNutritionSubClassID:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed sportNutritionSubClass.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteSportNutritionSubClass([FromUri] int sportNutritionSubClassID)
        {
            await _sportNutritionSubClassService.DeleteSportNutritionSubClassAsync(sportNutritionSubClassID);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));

        }

        [HttpPatch]
        [Route("{id:int:min(1)}/upload")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new sportNutritionSubClassImage.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddImage()
        {
            MultipartMemoryStreamProvider provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);

            var sportNutritionSubClass = await _sportNutritionSubClassService.UploadSportNutritionSubClassImageAsync(provider);
            var location = string.Format("/api/images/{0}", sportNutritionSubClass.SportNutritionSubClassID);
            return Created<SportNutritionSubClass>(location, sportNutritionSubClass);
        }

    }
}