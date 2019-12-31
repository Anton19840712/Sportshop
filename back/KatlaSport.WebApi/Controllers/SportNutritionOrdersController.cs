using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using KatlaSport.Services.ShipperManagement;
using KatlaSport.Services.SportNutritionOrderManagement;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/sportNutritionOrders")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class SportNutritionOrdersController : ApiController
    {
        private readonly ISportNutritionOrderService _sportNutritionOrderService;
        private readonly IShipperService _shipperService;
        public SportNutritionOrdersController(ISportNutritionOrderService sportNutritionOrderService, IShipperService shipperService)
        {
            _sportNutritionOrderService = sportNutritionOrderService ?? throw new ArgumentNullException(nameof(sportNutritionOrderService));
            _shipperService = shipperService ?? throw new ArgumentNullException(nameof(shipperService));
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of sportNutritionOrders.", Type = typeof(SportNutritionOrder[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetSportNutritionOrders()
        {
            var sportNutritionOrders = await _sportNutritionOrderService.GetSportNutritionOrdersAsync();
            return Ok(sportNutritionOrders);
        }

        [HttpGet]
        [Route("{sportNutritionOrderId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a sportNutritionOrder.", Type = typeof(SportNutritionOrder))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetSportNutritionOrder(int sportNutritionOrderID)
        {
            var sportNutritionOrder = await _sportNutritionOrderService.GetSportNutritionOrderAsync(sportNutritionOrderID);
            return Ok(sportNutritionOrder);
        }

        //добавочный метод!!!!!!!!!!!!!смотрю СЭДА!
        [HttpGet]
        [Route("{sportNutritionOrderId:int:min(1)}/shippers")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of shipperd for specified client.", Type = typeof(SportNutritionOrderListItem))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetShippers(int sportNutritionOrderId)
        {
            var client = await _shipperService.GetShippersAsync(sportNutritionOrderId);
            return Ok(client);
        }


        [HttpPost]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new sportNutritionOrder.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddSportNutritionOrder([FromBody] UpdateSportNutritionOrderRequest createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sportNutritionOrder = await _sportNutritionOrderService.CreateSportNutritionOrderAsync(createRequest);
            var location = string.Format("/api/sportNutritionOrders/{0}", sportNutritionOrder.SportNutritionOrderID);
            return Created<SportNutritionOrder>(location, sportNutritionOrder);
        }

        [HttpPut]
        [Route("{sportNutritionOrderID:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed sportNutritionOrder.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateSportNutritionOrder([FromUri] int sportNutritionOrderID, [FromBody] UpdateSportNutritionOrderRequest updateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _sportNutritionOrderService.UpdateSportNutritionOrderAsync(sportNutritionOrderID, updateRequest);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpDelete]
        [Route("{sportNutritionOrderID:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed sportNutritionOrder.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteSportNutritionOrder([FromUri] int sportNutritionOrderID)
        {
            await _sportNutritionOrderService.DeleteSportNutritionOrderAsync(sportNutritionOrderID);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));

        }
    }
}