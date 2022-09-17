using DocumentManager.Models.DocumentsModels;
using DocumentManager.Models.Filters;
using System;
using System.Collections.Generic;

namespace DocumentManager.Models
{
    public class DocumentManager
    {
        private readonly DatabaseClient _databaseClient;

        private readonly Dictionary<string, Guid> _documentsGuids = new Dictionary<string, Guid>
        {
            {"baseDocumentGuid", Guid.NewGuid()},
            {"incomingDocumentGuid", Guid.NewGuid()}
        };

        public DocumentManager()
        {
            _databaseClient = new DatabaseClient();
        }

        public IEnumerable<BaseDocument> GetBaseDocuments(BaseDocumentFilter filter = null)
        {
            return _databaseClient.GetAllBaseDocuments(filter);
        }

        public IEnumerable<IncomingDocument> GetIncomingDocuments(IncomingDocumentsFilter filter = null)
        {
            return _databaseClient.GetAllIncomingDocuments(filter);
        }

        public void AddToBaseRegister(string name, string subject)
        {
            var baseDocument = new BaseDocumentBuilder()
                .AddDiscriminator(_documentsGuids["baseDocumentGuid"])
                .AddName(name)
                .AddDocumentKind(0, "BaseDocument")
                .AddSubject(subject)
                .AddCreationDate(DateTime.Now)
                .AddDocumentNumber(Guid.NewGuid().ToString())
                .Build();
            _databaseClient.AddBaseDocument(baseDocument);
        }
        public void AddToIncomingRegister(string name, string subject, string addressee, string counterparty, string deliveryMethod, string cameFrom)
        {
            var addresseeSplitted = addressee.Split(' ');

            var baseDocument = new BaseDocumentBuilder()
                .AddDiscriminator(_documentsGuids["incomingDocumentGuid"])
                .AddName(name)
                .AddDocumentKind(0, "IncomingDocument")
                .AddSubject(subject)
                .AddCreationDate(DateTime.Now)
                .AddDocumentNumber(Guid.NewGuid().ToString())
                .Build();
            var incomingDocument = new IncomingDocumentBuilder()
            .AddBaseDocument(baseDocument)
            .AddAddressee(0, addresseeSplitted[0], addresseeSplitted[1], addresseeSplitted[2])
            .AddCounterparty(0, counterparty)
            .AddDeliveryMethod(0, deliveryMethod)
            .AddCameFrom(0, cameFrom)
            .Build();
            _databaseClient.AddIncomingDocument(incomingDocument);
        }

        public void UpdateBaseDocument(BaseDocument valueForUpdate)
        {
            _databaseClient.UpdateBaseDocument(valueForUpdate);
        }

        public void UpdateIncomingDocument(IncomingDocument valueForUpdate)
        {
            _databaseClient.UpdateIncomingDocument(valueForUpdate);
        }
    }
}
