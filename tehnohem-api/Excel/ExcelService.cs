using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using tehnohem_api.Model;
using tehnohem_api.Model.Invoice;

namespace tehnohem_api.Excel
{
    public class ExcelService : IExcelService
    {

        public XLWorkbook gnerateXMLFile() { 
            XLWorkbook workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("Faktura");

            //Dobavljac
            ws.Cell(9,1).SetValue("DOBAVLJAČ: \"TEHNOHEM\" doo Zvornik");
            ws.Cell(10,1).SetValue("SJEDIŠTE: Karakaj 80, Karakaj, 75400 Zvornik");
            ws.Cell(11,1).SetValue("MBS: 59-01-0056-16, Okružni privredni sud Bijeljina");
            ws.Cell(12,1).SetValue("MB: 11146406");
            ws.Cell(13, 1).SetValue("JIB: 4404057800001");
            ws.Cell(14,1).SetValue("IB: 404057800001");
            ws.Cell(15,1).SetValue("Ž.R. 5620098134054364");

            //Kupac
            ws.Cell(9, 9).SetValue("KUPAC:");
            ws.Cell(11, 9).SetValue("ADRESA:");
            ws.Cell(12, 9).SetValue("MIJESTO:");
            ws.Cell(13, 9).SetValue("JIB:");  
            ws.Cell(14, 9).SetValue("IB:");

            ws.Cell(9, 10).SetValue("\"LM COMERCE\" D.O.O.");
            ws.Cell(11, 10).SetValue("Trg K.Petra b.b.");
            ws.Cell(12, 10).SetValue("75450 Šekovići");
            ws.Cell(13, 10).SetValue("4400292490006");
            ws.Cell(14, 10).SetValue("400292490006");

            //Naslov
            ws.Cell(16, 2).SetValue("Otpremnica/Faktura br.");
            ws.Cell(16,2).Style.Font.FontSize= 18;
            centerCell(ws, 16, 2);
            ws.Cell(16, 9).SetValue("85/23");
            ws.Cell(16, 9).Style.Font.FontSize = 18;
            centerCell(ws, 16, 9);

            ws.Range("B16:H17").Merge();
            ws.Range("I16:I17").Merge();

            //Sub-naslov
            ws.Cell(18, 1).SetValue("Datum izdavanja fakrue:");
            ws.Cell(18, 4).SetValue("16.03.2023");

            ws.Cell(18, 7).SetValue("Mesto izdavanja fakture: ZVORNIK");

            ws.Cell(20, 1).SetValue("Datum isporuke dobra:");
            ws.Cell(20, 4).SetValue("16.03.2023");
            ws.Cell(20, 6).SetValue("Valuta");
            ws.Cell(20, 7).SetValue("09.04.2023");
            ws.Cell(20, 9).SetValue("Nacin isporuke: J97-T-226");

            //table 
            //header
            this.insertTableHeaderRow(ws, 22);

            InvoiceItem invoiceItem = new InvoiceItem() { 
                Name = "Jestivo sirce 1/1",
                Unit = "kom",
                Amount= 100,
                SinglePrice = 0.94f,
                TotalValueWithoutPDV = 225.60f,
                Rabat = 22.56f,
                TotalValueOfPDV = 34.52f,
                TotalValue = 237.56f,
                SinglePricePdv = 0.99f,
            };

            InvoiceItem invoiceItem2 = new InvoiceItem()
            {
                Name = "Jestivo sirce 3/1",
                Unit = "kom",
                Amount = 8,
                SinglePrice = 2.72f,
                TotalValueWithoutPDV = 27.76f,
                Rabat = 2.18f,
                TotalValueOfPDV = 3.33f,
                TotalValue = 22.91f,
                SinglePricePdv = 2.89f,
            };

            insertTableRow(ws, 26, 1, invoiceItem);

            insertTableRow(ws, 28, 2, invoiceItem2);

            insertTableTotalRow(ws, 30);

            insertSummary(ws, 33);

            insertFooter(ws, 36);

            return workbook;
        }

        public XLWorkbook gnerateXMLFile(Invoice invoice)
        {
            XLWorkbook workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("Faktura");

            //Dobavljac
            ws.Cell(9, 1).SetValue("DOBAVLJAČ: \"TEHNOHEM\" doo Zvornik");
            ws.Cell(10, 1).SetValue("SJEDIŠTE: Karakaj 80, Karakaj, 75400 Zvornik");
            ws.Cell(11, 1).SetValue("MBS: 59-01-0056-16, Okružni privredni sud Bijeljina");
            ws.Cell(12, 1).SetValue("MB: 11146406");
            ws.Cell(13, 1).SetValue("JIB: 4404057800001");
            ws.Cell(14, 1).SetValue("IB: 404057800001");
            ws.Cell(15, 1).SetValue("Ž.R. 5620098134054364");

            //Kupac
            ws.Cell(9, 9).SetValue("KUPAC:");
            ws.Cell(11, 9).SetValue("ADRESA:");
            //ws.Cell(12, 9).SetValue("MIJESTO:");
            ws.Cell(13, 9).SetValue("JIB:");
            ws.Cell(14, 9).SetValue("IB:");

            ws.Cell(9, 10).SetValue(invoice.Customer.Name);
            ws.Cell(11, 10).SetValue(invoice.Customer.Address);
            //ws.Cell(12, 10).SetValue("75450 Šekovići");
            ws.Cell(13, 10).SetValue(invoice.Customer.JIB);
            ws.Cell(14, 10).SetValue(invoice.Customer.IB);

            //Naslov
            ws.Cell(16, 2).SetValue("Otpremnica/Faktura br.");
            ws.Cell(16, 2).Style.Font.FontSize = 18;
            centerCell(ws, 16, 2);
            ws.Cell(16, 8).SetValue(invoice.companyInvoiceID);
            ws.Cell(16, 8).Style.Font.FontSize = 18;
            centerCell(ws, 16, 8);

            ws.Range("B16:G17").Merge();
            ws.Range("H16:I17").Merge();

            //Sub-naslov
            ws.Cell(18, 1).SetValue("Datum izdavanja fakrue:");
            ws.Cell(18, 4).SetValue(invoice.Date.ToString("dd.MM.yyyy"));

            ws.Cell(18, 7).SetValue("Mesto izdavanja fakture: ZVORNIK");

            ws.Cell(20, 1).SetValue("Datum isporuke dobra:");
            ws.Cell(20, 4).SetValue(invoice.Date.ToString("dd.MM.yyyy"));
            ws.Cell(20, 6).SetValue("Valuta");
            ws.Cell(20, 7).SetValue(DateTime.Now.ToString("dd.MM.yyyy"));
            ws.Cell(20, 9).SetValue("Nacin isporuke: J97-T-226");

            //table 
            //header
            this.insertTableHeaderRow(ws, 22);
            int i = 0;
            foreach(InvoiceItem invoiceItem in invoice.InvoiceItems)
            {
                insertTableRow(ws, 26 + i*2, i+1, invoiceItem);
                i++;
            }

            insertTableTotalRow(ws, 26+i*2);

            insertSummary(ws, 26+i*2+3);

            insertFooter(ws, 26 + i * 2 + 6);

            return workbook;
        }

        public void tableheader(IXLWorksheet ws,int x, int y) {
            centerCell(ws, x, y);
            borderCell(ws, x, y);
        }

        public void centerCell(IXLWorksheet ws,int x,int y) {
            ws.Cell(x, y).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell(x, y).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        }

        public void borderCell(IXLWorksheet ws, int x, int y) {
            ws.Cell(x, y).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        }
        public void insertTableHeaderRow(IXLWorksheet ws,int x) {

            for (int i = 1; i < 16; i++)
            {
                tableheader(ws, x, i);
                tableheader(ws, x + 1, i);
                tableheader(ws, x + 2, i);
                tableheader(ws, x + 3, i);
                ws.Range(x, i, x + 3, i).Merge();
            }

            ws.Cell(x, 1).SetValue("red.\nbroj");

            ws.Cell(x, 2).SetValue("\tNAZIV I VRSTA DOBRA");
            ws.Range(x,2,x+3,7).Merge();

            ws.Cell(x, 7).SetValue("jed.\nmere");

            ws.Cell(x, 8).SetValue("koli\nčina");

            ws.Cell(x, 9).SetValue("Cena\njde.\nbez\nPDVa");

            ws.Cell(x, 10).SetValue("Vrednost\ndobara bez\nPDVa");

            ws.Cell(x, 11).SetValue("rabat%\n10");

            ws.Cell(x, 12).SetValue("osnovica\nPDV-a");

            ws.Cell(x, 13).SetValue("iznos\nPDV-a\nstopa E\n17%");

            ws.Cell(x, 14).SetValue("vrednost\ndobara sa\nPDV-om");

            ws.Cell(x, 15).SetValue("cena\njed.\nsa\nPDV-om");
        }
        public void insertTableRow(IXLWorksheet ws, int x,int rowNum, InvoiceItem invoiceItem) {

            for (int i = 1; i < 16; i++)
            {
                tableheader(ws, x, i);
                tableheader(ws, x + 1, i);
                ws.Range(x, i, x + 1, i).Merge();
            }

            ws.Cell(x, 1).SetValue(rowNum);
            ws.Range(x, 1, x+1, 1).Merge();


            ws.Cell(x, 2).SetValue(invoiceItem.Name+ "\nbar kod: 3877000735037");
            ws.Range(x,2,x+1,7).Merge();

            ws.Cell(x, 7).SetValue(invoiceItem.Unit);
            centerCell(ws, x, 7);

            ws.Cell(x, 8).SetValue(invoiceItem.Amount);

            ws.Cell(x, 9).SetValue(Math.Round(invoiceItem.SinglePrice,2));

            //Change!!!! without rabat
            ws.Cell(x, 10).SetValue(Math.Round(invoiceItem.TotalValueWithoutPDV,2));

            ws.Cell(x, 11).SetValue(Math.Round(invoiceItem.Rabat.Value,2));

            ws.Cell(x, 12).SetValue(Math.Round(invoiceItem.TotalValueWithoutPDV,2));

            ws.Cell(x, 13).SetValue(Math.Round(invoiceItem.TotalValueOfPDV,2));

            ws.Cell(x, 14).SetValue(Math.Round(invoiceItem.TotalValue,2));
            
            ws.Cell(x, 15).SetValue(Math.Round(invoiceItem.SinglePricePdv.Value,2));
        }

        public void insertTableTotalRow(IXLWorksheet ws, int x) {
            ws.Cell(x, 7).SetValue("Ukupno").Style.Font.Bold = true;
            centerCell(ws, x, 7);
            ws.Range(x,7,x,9).Merge();

            ws.Cell(x, 10).SetValue(247.36);
            ws.Cell(x, 11).SetValue(24.36);
            ws.Cell(x, 12).SetValue(222.36);
            ws.Cell(x, 13).SetValue(37.85);
            ws.Cell(x, 14).SetValue(260.47);

            for (int i = 10; i < 15; i++) {
                tableheader(ws, x, i);
            }
        }

        public void insertSummary(IXLWorksheet ws, int x) {

            for (int i = 0; i < 3; i++) {
                centerCell(ws, x + i, 9);
                ws.Range(x + i, 9, x + i, 12).Merge();

                tableheader(ws,x + i, 13);
                tableheader(ws, x + i, 14);
                ws.Range(x+i, 13, x+i, 14).Merge();
            }

            ws.Cell(x, 9).SetValue("Osnovica PDV-a:").Style.Font.Bold = true;
            ws.Cell(x, 13).SetValue(222.62).Style.Font.Bold = true;


            ws.Cell(x + 1, 9).SetValue("Iznos PDV-a (stopa 17%):").Style.Font.Bold = true;
            ws.Cell(x + 1, 13).SetValue(37.85).Style.Font.Bold = true;

            ws.Cell(x + 2, 9).SetValue("Ukupan iznos za uplatu sa PDV-om:").Style.Font.Bold = true;
            ws.Cell(x + 2, 13).SetValue(260.47).Style.Font.Bold = true;
        }

        public void insertFooter(IXLWorksheet ws,int x) {

            ws.Cell(x + 1, 1).SetValue("Reklamacije se primaju u roku od 3 dana, na osnovu propisanog zapisnika.");
            ws.Cell(x + 2, 1).SetValue("Plaćanje virmanom u roku od    20 dana ili do 09.04.2020. godine");
            ws.Cell(x + 3, 1).SetValue("Za plaćanje preko 20 dana zaračunava se zakonska zatezna kamata.");
            ws.Cell(x + 4, 1).SetValue("U slučaju spora nadležan je opštinski sud u Zvorniku.");

            ws.Cell(x + 6, 2).SetValue("Fakturisao:");
            ws.Cell(x + 7, 2).SetValue("_______________________");
            centerCell(ws, x + 7, 2);
            ws.Range("B" + (x + 7).ToString() + ":D" + (x + 7).ToString()).Merge();

            ws.Cell(x + 6, 10).SetValue("Dobra (robu) primio:");
            ws.Cell(x + 7, 10).SetValue("______________________");
            centerCell(ws, 7, 10);
            ws.Range("J" + (x + 7).ToString() + ":L" + (x + 7).ToString()).Merge();

            ws.Cell(x + 9, 2).SetValue("MP");
        }

        public XLWorkbook gnerateXMLFileInternalIssueRaw(Invoice invoice)
        {

            XLWorkbook workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("Izdatnica repromaterijala");

            ws.Cell(1,1).SetValue("\"TEHNOHEM\" doo \t   IZDATNICA REPRODUKCIONOG MATERIJALA  (periodična specifikacija)");
            ws.Cell(2, 1).SetValue("Broj izdatnice: " + invoice.companyInvoiceID + " \t Broj radnog naloga: \t Period izdavanja: \t Datum: "+invoice.Date);

            ws.Cell(4, 1).SetValue("MATERIJAL");
            ws.Cell(4, 3).SetValue("jed. mere");
            ws.Cell(4, 4).SetValue("cena, KM");
            ws.Range(4, 4, 4, 5).Merge();
            ws.Cell(4, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell(4, 6).SetValue("količina izdavanja");
            ws.Cell(4, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Range(4, 6, 4, 8).Merge();
            ws.Cell(4, 9).SetValue("Ukupno ");
            ws.Cell(5, 9).SetValue("izdato");
            ws.Cell(4, 10).SetValue("Ukupna ");
            ws.Cell(5, 10).SetValue("vrednost");

            return workbook;
        }
    }
}
