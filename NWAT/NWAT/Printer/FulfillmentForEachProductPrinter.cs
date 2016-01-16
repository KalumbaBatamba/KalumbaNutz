using NWAT.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

/// <summary>
/// 
/// </summary>
/// Erstellt von Adrian Glasnek
namespace NWAT.Printer
{

    class FulfillmentForEachProductPrinter
    {


        public void PrintFulfillment()
        {

            SaveFileDialog SfdFulfillment = new SaveFileDialog();
            SfdFulfillment.Filter = "Pdf File |*.pdf";
            if (SfdFulfillment.ShowDialog() == DialogResult.OK)
            {
                Document FulfillmentPrinter = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                PdfWriter writer = PdfWriter.GetInstance(FulfillmentPrinter, new FileStream("FulfillmentEachProduct.pdf", FileMode.Create));
            }
        }
    }
}
