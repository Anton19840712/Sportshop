namespace KatlaSport.Services.TransportManagement
{
    public class Transport
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ModeId { get; set; }

        public int? CoordinatorId { get; set; }

        public int InformationId { get; set; }
    }
}
