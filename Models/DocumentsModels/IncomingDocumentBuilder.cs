namespace DocumentManager.Models.DocumentsModels
{
    public class IncomingDocumentBuilder
    {
        private readonly IncomingDocument _incomingDocument = new IncomingDocument();

        public IncomingDocumentBuilder AddBaseDocument(BaseDocument baseDocument)
        {
            _incomingDocument.BaseDocument = baseDocument;
            return this;
        }
        public IncomingDocumentBuilder AddAddressee(int id, string surname, string name, string patronymic)
        {
            _incomingDocument.Addresses = new Addressee {Id = id, Surname = surname, Name = name, Patronymic = patronymic};
            return this;
        }
        public IncomingDocumentBuilder AddCounterparty(int id, string organizationName)
        {
            _incomingDocument.Counterparty = new Counterparty { Id = id, OrganizationName = organizationName};
            return this;
        }

        public IncomingDocumentBuilder AddDeliveryMethod(int id, string methodName)
        {
            _incomingDocument.DeliveryMethod = new DeliveryMethod {Id = id, MethodName = methodName};
            return this;
        }

        public IncomingDocumentBuilder AddCameFrom(int id, string organizationName)
        {
            _incomingDocument.CameFrom = new Counterparty { Id = id, OrganizationName = organizationName };
            return this;
        }

        public IncomingDocument Build()
        {
            return _incomingDocument;
        }
    }
}
