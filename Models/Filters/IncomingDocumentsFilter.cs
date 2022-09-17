using DocumentManager.Models.DocumentsModels;

namespace DocumentManager.Models.Filters
{
    public class IncomingDocumentsFilter
    {
        public BaseDocumentFilter BaseDocumentFilter { get; set; }
        public DeliveryMethod ByDeliveryMethod { get; set; }
        public Counterparty ByCounterparty { get; set; }
    }
}
