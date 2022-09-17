namespace DocumentManager.Models.DocumentsModels
{
    public class IncomingDocument
    {
        public BaseDocument BaseDocument { get; set; }
        public Addressee Addresses { get; set; }
        public Counterparty Counterparty { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public Counterparty CameFrom { get; set; }
    }
}
