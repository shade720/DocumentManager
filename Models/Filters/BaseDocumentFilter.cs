using System;

namespace DocumentManager.Models.Filters
{
    public class BaseDocumentFilter
    {
        public string DocumentKind { get; }
        public string DocumentNumber { get; set; }
        public string ByName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public BaseDocumentFilter(string documentKind)
        {
            DocumentKind = documentKind;
        }
    }
}
