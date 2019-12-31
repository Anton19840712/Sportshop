namespace KatlaSport.Services.TransportManagement
{
    public class UpdateInformationRequest
    {
        public byte[] File { get; set; }

        public string Name { get; set; }

        public int TransportId { get; set; }
    }
}
