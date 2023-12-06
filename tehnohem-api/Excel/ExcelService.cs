using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using tehnohem_api.Model;

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
            ws.Cell(22, 1).SetValue("red.\nbroj");
            tableheader(ws, 22, 1);
            ws.Range("A22:A25").Merge();
            
            ws.Cell(22, 2).SetValue("\tNAZIV I VRSTA DOBRA");
            tableheader(ws, 22, 2);
            ws.Range("B22:F25").Merge();

            ws.Cell(22, 7).SetValue("jed.\nmere");
            tableheader(ws, 22, 7);
            ws.Range("G22:G25").Merge();

            ws.Cell(22, 8).SetValue("koli\nčina");
            tableheader(ws, 22, 8);
            ws.Range("H22:H25").Merge();

            ws.Cell(22, 9).SetValue("Cena\njde.\nbez\nPDVa");
            tableheader(ws, 22, 9);
            ws.Range("I22:I25").Merge();

            ws.Cell(22, 10).SetValue("Vrednost\ndobara bez\nPDVa");
            tableheader(ws, 22, 10);
            ws.Range("J22:J25").Merge();

            ws.Cell(22, 11).SetValue("rabat%");
            ws.Cell(23, 11).SetValue(10);
            tableheader(ws, 22, 11);
            ws.Range("K22:K25").Merge();

            ws.Cell(22, 12).SetValue("osnovica\nPDV-a");
            tableheader(ws, 22, 12);
            ws.Range("L22:L25").Merge();

            ws.Cell(22, 13).SetValue("iznos\nPDV-a\nstopa E\n17%");
            tableheader(ws, 22, 13);
            ws.Range("M22:M25").Merge();

            ws.Cell(22, 14).SetValue("vrednost\ndobara sa\nPDV-om");
            tableheader(ws, 22, 14);
            ws.Range("N22:N25").Merge();

            ws.Cell(22, 15).SetValue("cena\njed.\nsa\nPDV-om");
            tableheader(ws, 22, 15);
            ws.Range("O22:O25").Merge();

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

            insertRow(ws, 26, 1, invoiceItem);

            insertRow(ws, 28, 2, invoiceItem);

            ws.Cell(30, 7).SetValue("Ukupno").Style.Font.Bold = true;
            centerCell(ws,30, 7);
            ws.Range("G30:I30").Merge();

            ws.Cell(30, 10).SetValue(247.36);
            ws.Cell(30, 11).SetValue(24.36);
            ws.Cell(30, 12).SetValue(222.36);
            ws.Cell(30, 13).SetValue(37.85);
            ws.Cell(30, 14).SetValue(260.47);

            ws.Cell(32, 10).SetValue("Osnovica PDV-a:").Style.Font.Bold = true;
            ws.Range("J32:L32").Merge();
            ws.Cell(32, 13).SetValue(222.62).Style.Font.Bold = true;
            centerCell(ws, 32, 13);
            ws.Range("M32:N32").Merge();


            ws.Cell(33, 9).SetValue("Iznos PDV-a (stopa 17%):").Style.Font.Bold = true;
            ws.Range("I33:L33").Merge();
            ws.Cell(33, 13).SetValue(37.85).Style.Font.Bold = true;
            centerCell(ws, 33, 13);
            ws.Range("M33:N33").Merge();

            ws.Cell(34, 9).SetValue("Ukupan iznos za uplatu sa PDV-om:").Style.Font.Bold = true;
            ws.Range("I34:L34").Merge();
            ws.Cell(34, 13).SetValue(260.47).Style.Font.Bold = true;
            centerCell(ws, 34, 13);
            ws.Range("M34:N34").Merge();


            ws.Cell(36, 1).SetValue("Reklamacije se primaju u roku od 3 dana, na osnovu propisanog zapisnika.");
            ws.Cell(37, 1).SetValue("Plaćanje virmanom u roku od    20 dana ili do 09.04.2020. godine");
            ws.Cell(38, 1).SetValue("Za plaćanje preko 20 dana zaračunava se zakonska zatezna kamata.");
            ws.Cell(39, 1).SetValue("U slučaju spora nadležan je opštinski sud u Zvorniku.");

            ws.Cell(41, 2).SetValue("Fakturisao:");
            ws.Cell(42, 2).SetValue("_______________________");
            centerCell(ws, 42, 2);
            ws.Range("B42:D42").Merge();

            ws.Cell(41, 10).SetValue("Dobra (robu) primio:");
            ws.Cell(42, 10).SetValue("______________________");
            centerCell(ws, 42, 10);
            ws.Range("J42:L42").Merge();

            ws.Cell(44, 2).SetValue("MP");

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
            ws.Cell(x, y).Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
        }

        public void insertRow(IXLWorksheet ws, int x,int rowNum, InvoiceItem invoiceItem) {
            ws.Cell(x, 1).SetValue(rowNum);
            centerCell(ws, x, 1);

            ws.Cell(x, 2).SetValue(invoiceItem.Name+ "\nbar kod: 3877000735037");
            ws.Range("B" + x.ToString() + ":F" + x.ToString()).Merge();
            ws.Range("B" + (x+1).ToString() + ":F" + (x+1).ToString()).Merge();

            for (int i = 7; i < 16; i++) {
                tableheader(ws, x, i);
            }

            ws.Cell(x, 7).SetValue(invoiceItem.Unit);
            centerCell(ws, x, 7);

            ws.Cell(x, 8).SetValue(invoiceItem.Amount);
            centerCell(ws, x, 8);

            ws.Cell(x, 9).SetValue(Math.Round(invoiceItem.SinglePrice,2));
            centerCell(ws, x, 9);

            //Change!!!! without rabat
            ws.Cell(x, 10).SetValue(Math.Round(invoiceItem.TotalValueWithoutPDV,2));
            centerCell(ws, x, 10);

            ws.Cell(x, 11).SetValue(Math.Round(invoiceItem.Rabat.Value,2));
            centerCell(ws, x, 11);

            ws.Cell(x, 12).SetValue(Math.Round(invoiceItem.TotalValueWithoutPDV,2));
            centerCell(ws, x, 12);

            ws.Cell(x, 13).SetValue(Math.Round(invoiceItem.TotalValueOfPDV,2));
            centerCell(ws, x, 13);

            ws.Cell(x, 14).SetValue(Math.Round(invoiceItem.TotalValue,2));
            centerCell(ws, x, 14);
            
            ws.Cell(x, 15).SetValue(Math.Round(invoiceItem.SinglePricePdv.Value,2));
            centerCell(ws, x, 15);
        }

    }
}
