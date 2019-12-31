using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using KatlaSport.Services.SportNutritionClassManagement;
using KatlaSport.Services.SportNutritionSubClassManagement;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/sportNutritionClasses")] //something departments/show...
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class SportNutritionClassesController : ApiController
    {
        private readonly ISportNutritionClassService _sportNutritionClassService;

        private readonly ISportNutritionSubClassService _sportNutritionSubClassService;
        public SportNutritionClassesController(ISportNutritionClassService sportNutritionClassService, ISportNutritionSubClassService sportNutritionSubClassService)
        {
            _sportNutritionClassService = sportNutritionClassService ?? throw new ArgumentNullException(nameof(sportNutritionClassService));
            _sportNutritionSubClassService = sportNutritionSubClassService ?? throw new ArgumentNullException(nameof(sportNutritionSubClassService));
        }

        [HttpGet] //create/1
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of sportNutritionClasses.", Type = typeof(SportNutritionClass[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetSportNutritionClasses()
        {
            var sportNutritionClasses = await _sportNutritionClassService.GetSportNutritionClassesAsync();
            return Ok(sportNutritionClasses);
        }

        // добавил метод
        [HttpGet]
        [Route("{classId:int:min(1)}/subclasses")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of subclasses for specified class.", Type = typeof(SportNutritionSubClassListItem))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetHiveSections(int classId)
        {
            var hive = await _sportNutritionSubClassService.GetSportNutritionSubClassesAsync(classId);
            return Ok(hive);
        }

        [HttpGet]
        [Route("{sportNutritionClassId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a sportNutritionClass.", Type = typeof(SportNutritionClass))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetSportNutritionClass(int sportNutritionClassID)
        {
            var sportNutritionClass = await _sportNutritionClassService.GetSportNutritionClassAsync(sportNutritionClassID);
            return Ok(sportNutritionClass);
        }

        [HttpPost]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new sportNutritionClass.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddSportNutritionClass([FromBody] UpdateSportNutritionClassRequest createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sportNutritionClass = await _sportNutritionClassService.CreateSportNutritionClassAsync(createRequest);
            var location = string.Format("/api/aupplements/{0}", sportNutritionClass.SportNutritionClassID);
            return Created<SportNutritionClass>(location, sportNutritionClass);
        }

        [HttpPut] //update/id
        [Route("{sportNutritionClassID:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed sportNutritionClass.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateSportNutritionClass([FromUri] int sportNutritionClassID, [FromBody] UpdateSportNutritionClassRequest updateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _sportNutritionClassService.UpdateSportNutritionClassAsync(sportNutritionClassID, updateRequest);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }
               
        [HttpDelete]
        [Route("{sportNutritionClassID:int:min(1)}")] //destroy/id
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed sportNutritionClass.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteSportNutritionClass([FromUri] int sportNutritionClassID)
        {
            await _sportNutritionClassService.DeleteSportNutritionClassAsync(sportNutritionClassID);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));

        }
    }
}