using KatlaSport.Services;
using KatlaSport.Services.TransportManagement;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.Web.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/transport")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class TransportController : ApiController
    {
        private readonly IRepository<Transport, UpdateTransportRequest> _transportRepositoryService;
        private readonly IRepository<Information, UpdateInformationRequest> _informationRepositoryService;

        public TransportController(IRepository<Transport, UpdateTransportRequest> transportRepositoryService, IRepository<Information, UpdateInformationRequest> informationRepositoryService)
        {
            _transportRepositoryService = transportRepositoryService ?? throw new ArgumentNullException(nameof(transportRepositoryService));
            _informationRepositoryService = informationRepositoryService ?? throw new ArgumentNullException(nameof(informationRepositoryService));
        }

        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns all transports.", Type = typeof(Transport[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetTransports()
        {
            var transports = await _transportRepositoryService.GetAllEntitiesAsync();
            return Ok(transports);
        }

        [HttpGet]
        [Route("{transportId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns an transport entity.", Type = typeof(Transport))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetTransport(int transportId)
        {
            var transport = await _transportRepositoryService.GetEntityAsync(transportId);
            return Ok(transport);
        }

        [HttpPost]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new transport entity.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddTransport([FromBody] UpdateTransportRequest createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _transportRepositoryService.AddEntityAsync(createRequest);

            return Ok();
        }

        [HttpPut]
        [Route("{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existing transport.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateTransport([FromUri] int id, [FromBody] UpdateTransportRequest updateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _transportRepositoryService.UpdateEntityAsync(updateRequest, id);

            return Ok();
        }

        [HttpDelete]
        [Route("{id:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes transport entity.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteTransport([FromUri] int id)
        {
            await _transportRepositoryService.RemoveEntityAsync(id);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpPatch]
        [Route("{id:int:min(1)}/info")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Upload info to transport.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public async Task<IHttpActionResult> PatchInformation([FromUri] int id)
        {
            var httpRequest = HttpContext.Current.Request;
            var attachedInfo = httpRequest.Files["fileKey"];
            await SaveInformation(id, attachedInfo);

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        private async Task SaveInformation(int id, HttpPostedFile attachedInfo)
        {
            string nameInfo = null;
            if (attachedInfo != null)
            {
                nameInfo = new String(Path.GetFileNameWithoutExtension(attachedInfo.FileName).Take(10).ToArray()).Replace(" ", "-");
                nameInfo = nameInfo + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(attachedInfo.FileName);

                await UploadFileToStorage(attachedInfo.InputStream, nameInfo);
                //await _informationRepositoryService.AddEntityAsync(new Information()
                //{
                //    File = await ConvertInfoToBytes(attachedInfo),
                //    Name = nameInfo
                //});

                var transport = await _transportRepositoryService.GetEntityAsync(id);

                var cvs = await _informationRepositoryService.GetAllEntitiesAsync();

                transport.InformationId = cvs.First(p => p.Name == nameInfo).Id;

                //await _transportRepositoryService.UpdateEntityAsync(transport);
            }
        }

        private async Task<byte[]> ConvertInfoToBytes(HttpPostedFile attachedInfo)
        {
            byte[] fileData = null;
            using (var binaryReader = new BinaryReader(attachedInfo.InputStream))
            {
                fileData = binaryReader.ReadBytes(attachedInfo.ContentLength);
            }

            return fileData;
        }

        private async Task<bool> UploadFileToStorage(Stream fileStream, string fileName)
        {
            StorageCredentials storageCredentials = new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]);
            CloudStorageAccount storageAccount = new CloudStorageAccount(storageCredentials, true);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(ConfigurationManager.AppSettings["BlobContainer"]);
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
            await blockBlob.UploadFromStreamAsync(fileStream);
            return await Task.FromResult(true);
        }
    }
}