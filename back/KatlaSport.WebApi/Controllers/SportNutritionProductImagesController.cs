using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using KatlaSport.Services.SportNutritionProductImageManagement;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/sportNutritionProductImages")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class SportNutritionProductImagesController : ApiController
    {
        private readonly ISportNutritionProductImageService _sportNutritionProductImageService;
        public SportNutritionProductImagesController(ISportNutritionProductImageService sportNutritionProductImageService)
        {
            _sportNutritionProductImageService = sportNutritionProductImageService ?? throw new ArgumentNullException(nameof(sportNutritionProductImageService));
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of sportNutritionProductImages.", Type = typeof(SportNutritionProductImage[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetSportNutritionProductImages()
        {
            var sportNutritionProductImages = await _sportNutritionProductImageService.GetSportNutritionProductImagesAsync();
            return Ok(sportNutritionProductImages);
        }

        [HttpGet]
        [Route("{sportNutritionProductImageId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a sportNutritionProductImage.", Type = typeof(SportNutritionProductImage))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetSportNutritionProductImage(int sportNutritionProductImageID)
        {
            var sportNutritionProductImage = await _sportNutritionProductImageService.GetSportNutritionProductImageAsync(sportNutritionProductImageID);
            return Ok(sportNutritionProductImage);
        }

        [HttpPut]
        [Route("{sportNutritionProductImageID:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed sportNutritionProductImage.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateSportNutritionProductImage([FromUri] int sportNutritionProductImageID, [FromBody] UpdateSportNutritionProductImageRequest updateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _sportNutritionProductImageService.UpdateSportNutritionProductImageAsync(sportNutritionProductImageID, updateRequest);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpDelete]
        [Route("{sportNutritionProductImageID:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed sportNutritionProductImage.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteSportNutritionProductImage([FromUri] int sportNutritionProductImageID)
        {
            await _sportNutritionProductImageService.DeleteSportNutritionProductImageAsync(sportNutritionProductImageID);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));

        }

        [HttpPost]
        [Route("upload")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new sportNutritionProductImage.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddImage()
        {
            MultipartMemoryStreamProvider provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);

            var sportNutritionProductImage = await _sportNutritionProductImageService.UploadSportNutritionProductImageAsync(provider);
            var location = string.Format("/api/images/{0}", sportNutritionProductImage.SportNutritionProductImageID);
            return Created<SportNutritionProductImage>(location, sportNutritionProductImage);
        }
    }
}