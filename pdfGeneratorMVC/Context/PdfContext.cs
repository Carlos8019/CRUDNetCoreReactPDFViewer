using System;
using Microsoft.EntityFrameworkCore;
using pdfGeneratorMVC;

namespace pdfGeneratorMVC
{
    public class PdfContext:DbContext
    {
        public PdfContext(DbContextOptions<PdfContext> options): base(options)
        {
            
        }
        public DbSet<PdfModel> product{ get; set; }
        //public DbSet<pdfGeneratorMVC.PdfModel> PdfModel { get; set; }
    }
}
