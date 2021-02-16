using System;
using System.ComponentModel.DataAnnotations;

namespace pdfGeneratorMVC
{
    public class PdfModel
    {
        [Key]
        public int id { get; set; }
        public string productName { get; set; }
        public string productDetail { get; set; }
    }
}
