namespace KatlaSport.Services.TransportManagement
{
    public class UpdateTransportRequest
    {
        public int? CoordinatorId { get; set; }

        public string Name { get; set; }

        public int ModeId { get; set; }

        public int InformationId { get; set; }
    }
}
