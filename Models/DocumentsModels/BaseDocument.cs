using System;

namespace DocumentManager.Models.DocumentsModels
{
    public class BaseDocument
    {
        public int Id { get; set; }
        public Guid Discriminator { get; set; }
        public string Name { get; set; }
        public DocumentKind DocumentKind { get; set; }
        public string Subject { get; set; }
        public DateTime CreatedDate { get; set; }
        public string DocumentNumber { get; set; }
    }
}
