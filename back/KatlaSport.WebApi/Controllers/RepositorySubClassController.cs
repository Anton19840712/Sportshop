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
    [RoutePrefix("api/repositorySubClass")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class RepositorySubClassController : ApiController
    {
        private readonly IRepository _repository;
        public RepositorySubClassController(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of sportNutritionSubClasses.", Type = typeof(SportNutritionSubClass[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetSportNutritionSubClasses()
        {
            var sportNutritionSubClasses = await _repository.GetAllAsync();
            return Ok(sportNutritionSubClasses);
        }

        [HttpGet]
        [Route("{sportNutritionSubClassId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a sportNutritionSubClass.", Type = typeof(SportNutritionSubClass))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetSportNutritionSubClass(int sportNutritionSubClassID)
        {
            var sportNutritionSubClass = await _repository.FindByIdAsync(sportNutritionSubClassID);
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

            var sportNutritionSubClass = await _repository.CreateAsync(createRequest);
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

            await _repository.UpdateAsync(sportNutritionSubClassID, updateRequest);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpDelete]
        [Route("{sportNutritionSubClassID:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed sportNutritionSubClass.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> Remove([FromUri] int sportNutritionSubClassID)
        {
            await _repository.RemoveAsync(sportNutritionSubClassID);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));

        }
    }
}