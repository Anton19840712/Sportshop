using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using KatlaSport.Services.ShipperManagement;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/shippers")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class ShippersController : ApiController
    {
        private readonly IShipperService _shipperService;
        public ShippersController(IShipperService shipperService)
        {
            _shipperService = shipperService ?? throw new ArgumentNullException(nameof(shipperService));
        }

        [HttpGet]
        [Route("GetAll")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of shippers.", Type = typeof(Shipper[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetShippers()
        {
            var shippers = await _shipperService.GetShippersAsync();
            return Ok(shippers);
        }

        [HttpGet]
        [Route("{shipperId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a shipper.", Type = typeof(Shipper))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetShipper(int shipperID)
        {
            var shipper = await _shipperService.GetShipperAsync(shipperID);
            return Ok(shipper);
        }

        [HttpPost]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new shipper.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddShipper([FromBody] UpdateShipperRequest createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shipper = await _shipperService.CreateShipperAsync(createRequest);
            var location = string.Format("/api/shippers/{0}", shipper.ShipperID);
            return Created<Shipper>(location, shipper);
        }

        [HttpPut]
        [Route("{shipperID:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed shipper.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateShipper([FromUri] int shipperID, [FromBody] UpdateShipperRequest updateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _shipperService.UpdateShipperAsync(shipperID, updateRequest);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpDelete]
        [Route("{shipperID:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed shipper.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteShipper([FromUri] int shipperID)
        {
            await _shipperService.DeleteShipperAsync(shipperID);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));

        }
    }
}