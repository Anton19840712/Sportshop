using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using KatlaSport.Services.SportNutritionClientManagement;
using KatlaSport.Services.SportNutritionOrderManagement;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/sportNutritionClient")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class SportNutritionClientsController : ApiController
    {
        private readonly ISportNutritionClientService _sportNutritionClientService;

        private readonly ISportNutritionOrderService _sportNutritionOrderService;
        public SportNutritionClientsController(ISportNutritionClientService sportNutritionClientService, ISportNutritionOrderService sportNutritionOrderService)
        {
            _sportNutritionClientService = sportNutritionClientService ?? throw new ArgumentNullException(nameof(sportNutritionClientService));
            _sportNutritionOrderService = sportNutritionOrderService ?? throw new ArgumentNullException(nameof(sportNutritionOrderService));
        }

        [HttpGet]
        [Route("list clients")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of sportNutritionClients.", Type = typeof(SportNutritionClient[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetSportNutritionClients()
        {
            var sportNutritionClients = await _sportNutritionClientService.GetSportNutritionClientsAsync();
            return Ok(sportNutritionClients);
        }

        [HttpGet]
        [Route("show one by id/{sportNutritionClientId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a sportNutritionClient.", Type = typeof(SportNutritionClient))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetSportNutritionClient(int sportNutritionClientID)
        {
            var sportNutritionClient = await _sportNutritionClientService.GetSportNutritionClientAsync(sportNutritionClientID);
            return Ok(sportNutritionClient);
        }

        //добавочный метод
        [HttpGet]
        [Route("orders/{clientId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of orders for specified client.", Type = typeof(SportNutritionOrderListItem))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetSportNutritionOrders(int clientId)
        {
            var client = await _sportNutritionOrderService.GetSportNutritionOrdersAsync(clientId);
            return Ok(client);
        }

        [HttpPost]
        [Route("create")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new sportNutritionClient.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddSportNutritionClient([FromBody] UpdateSportNutritionClientRequest createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sportNutritionClient = await _sportNutritionClientService.CreateSportNutritionClientAsync(createRequest);
            var location = string.Format("/api/sportNutritionClients/{0}", sportNutritionClient.SportNutritionClientID);
            return Created<SportNutritionClient>(location, sportNutritionClient);
        }

        [HttpPost]
        [Route("update/{sportNutritionClientID:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed sportNutritionClient.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateSportNutritionClient([FromUri] int sportNutritionClientID, [FromBody] UpdateSportNutritionClientRequest updateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _sportNutritionClientService.UpdateSportNutritionClientAsync(sportNutritionClientID, updateRequest);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpPost]
        [Route("annihilate/{sportNutritionClientID:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed sportNutritionClient.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteSportNutritionClient([FromUri] int sportNutritionClientID)
        {
            await _sportNutritionClientService.DeleteSportNutritionClientAsync(sportNutritionClientID);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));

        }
    }
}