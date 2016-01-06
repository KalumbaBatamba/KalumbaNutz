using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

/// <summary>
/// 
/// </summary>
/// Erstellt von Adrian Glasnek
namespace NWAT.Printer
{
    class CriterionstructurePrinter
    {
        Document doc;

        public CriterionstructurePrinter()

        {
        
        this.doc = new Document();
        
        }

        public void printCriterionForCostumer()
        {
        
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream("CostumerCrit.pdf", FileMode.Create));
           

        }
    }
}
