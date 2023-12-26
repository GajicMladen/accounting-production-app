import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { InternalDocumentData} from 'src/app/shared/model/internalDocumentsData';
import { DetailInvoiceInfo } from 'src/app/shared/model/invoices/detailInvoiceInfo';
import { InternalDocumentsDialogComponent } from '../../dialogs/internal-documents-dialog/internal-documents-dialog.component';
import { ExcelService } from 'src/app/shared/services/excel-service/excel.service';

@Component({
  selector: 'app-invoices-table',
  templateUrl: './invoices-table.component.html',
  styleUrls: ['./invoices-table.component.css']
})
export class InvoicesTableComponent implements OnInit ,OnChanges{

  @Input() displayedColumns: string[] = [ 'supplierName', 'customerName','invoiceID','date','value_out_pdv', 'value_pdv' ,'value_total','options' ];
  @Input() dataSource : DetailInvoiceInfo[] = [];
  @Input() showSummary : boolean = true;
  @Input() viewDetailsOption : boolean = true;
  @Input() enableSelectingInvoice : boolean = false;
  @Input() inlineOptions: boolean = false;

  @Output() selectedInvoice : EventEmitter<any> = new EventEmitter();  
  
  selectedInvoicee : DetailInvoiceInfo | undefined;

  total_value_out_pdv:number = 0;
  total_value_pdv : number= 0;
  total_value : number = 0;

  constructor(
    public dialog:MatDialog,
    private excelService: ExcelService,
  ) { }
  ngOnChanges(changes: SimpleChanges): void {
    if (changes['dataSource']) {
      // Trigger your function when the input list arrives
      this.updateTotalValues();
    }
  }

  ngOnInit(): void {
    this.updateTotalValues();
  }

  openInvoiceDetails(invoice:DetailInvoiceInfo){
    let dialogData : InternalDocumentData ={
      title:"Ulazna faktura",
      documentType:invoice.invoiceType,
      isReadonly:true,
      invoice: invoice
    }
    const dialogRef = this.dialog.open(InternalDocumentsDialogComponent,{
      data: dialogData
    });
  }
  
  printInvoice(invoice: DetailInvoiceInfo){
    this.excelService.getInvoiceExcelFile(invoice.invoiceIDsystem).subscribe(
      blob => this.downloadExcel(blob,'test.xlsx')
    )
  } 

  
  downloadExcel(response:any, fileName:string) {
    // Doing it this way allows you to name the file
    var link = document.createElement('a');
    link.href = window.URL.createObjectURL(response);
    link.download = fileName;
    link.click();
  }

  updateTotalValues(){
    this.total_value_out_pdv = 0;
    this.total_value_pdv = 0;
    this.total_value  = 0;
    this.dataSource.forEach( i => {
      this.total_value_out_pdv += i.valueOutPdv;
      this.total_value_pdv += i.valuePdv;
      this.total_value  += i.valueTotal;
    })
  }

  selectInvoice(invoice:DetailInvoiceInfo){
    if(this.enableSelectingInvoice){
      if(this.selectedInvoicee == invoice)
        this.selectedInvoicee = undefined
      else
        this.selectedInvoicee = invoice;
      this.selectedInvoice.emit(invoice);
    }
  }

  isInvoiceSelected(invoice:DetailInvoiceInfo){
    return this.selectedInvoicee?.invoiceID === invoice.invoiceID;
  }
}
