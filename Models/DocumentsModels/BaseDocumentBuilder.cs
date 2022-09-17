using System;

namespace DocumentManager.Models.DocumentsModels
{
    public class BaseDocumentBuilder
    {
        private readonly BaseDocument _baseDocument = new BaseDocument();
        public BaseDocumentBuilder AddId(int id)
        {
            _baseDocument.Id = id;
            return this;
        }
        public BaseDocumentBuilder AddDiscriminator(Guid guid)
        {
            _baseDocument.Discriminator = guid;
            return this;
        }
        public BaseDocumentBuilder AddName(string name)
        {
            _baseDocument.Name = name;
            return this;
        }
        public BaseDocumentBuilder AddDocumentKind(int id, string documentKind)
        {
            _baseDocument.DocumentKind = new DocumentKind { Id = id, Name = documentKind };
            return this;
        }
        public BaseDocumentBuilder AddSubject(string subject)
        {
            _baseDocument.Subject = subject;
            return this;
        }
        public BaseDocumentBuilder AddCreationDate(DateTime createdDate)
        {
            _baseDocument.CreatedDate = createdDate;
            return this;
        }
        public BaseDocumentBuilder AddDocumentNumber(string documentNumber)
        {
            _baseDocument.DocumentNumber = documentNumber;
            return this;
        }

        public BaseDocument Build()
        {
            return _baseDocument;
        }
    }
}
