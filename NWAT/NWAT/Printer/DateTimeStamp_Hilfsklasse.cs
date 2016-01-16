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
using iTextSharp.text.log;

namespace NWAT.Printer
{
    //PdfPageEventHelper Klasse ableiten und das OnEndPage Ereignis überschreiben => Timestamp auf PDF einfügen

    public class PdfPageEvents : PdfPageEventHelper
    {
        // ------------------------------------------------------------------------
        private float MilimetersToPoints(int mm)
        {
            return Utilities.MillimetersToPoints(Convert.ToSingle(mm));
        }

        // ------------------------------------------------------------------------
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);
            PdfContentByte FooterDate = writer.DirectContent;

            Rectangle pageSize = document.PageSize;


            // Footer Datum
            FooterDate.BeginText();
            FooterDate.SetFontAndSize(new Font(iTextSharp.text.Font.FontFamily.UNDEFINED, 9, iTextSharp.text.Font.NORMAL).GetCalculatedBaseFont(false), 9);
            FooterDate.ShowTextAligned(PdfContentByte.ALIGN_RIGHT,
                DateTime.Now.ToString("dd. MMMMM, yyyy"),
                pageSize.GetRight(MilimetersToPoints(25)),
                pageSize.GetBottom(MilimetersToPoints(5)), 0);
            FooterDate.EndText();
        }
    }
}
