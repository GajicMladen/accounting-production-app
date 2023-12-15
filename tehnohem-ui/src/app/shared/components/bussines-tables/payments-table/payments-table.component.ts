import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DetailInvoiceInfo } from 'src/app/shared/model/invoices/detailInvoiceInfo';
import { PaymentRecordDialogComponent } from '../../dialogs/payment-record-dialog/payment-record-dialog.component';
import { Payment } from 'src/app/shared/model/payment/payment';

@Component({
  selector: 'app-payments-table',
  templateUrl: './payments-table.component.html',
  styleUrls: ['./payments-table.component.css']
})
export class PaymentsTableComponent implements OnInit {

  @Input() displayedColumns: string[] = [ 'paymentID', 'payerName','receiverName','date','value_total','options' ];
  @Input() dataSource : Payment[] = [];
  @Input() showSummary : boolean = true;
  @Input() viewDetailsOption : boolean = true;
  @Input() enableSelectingInvoice : boolean = false;
  @Input() inlineOptions: boolean = false;

  @Output() slectedPayment : EventEmitter<any> = new EventEmitter();  
  @Output() deletedPayment : EventEmitter<any> = new EventEmitter();  
  
  selectedPayment : Payment | undefined;

  total_value_out_pdv:number = 0;
  total_value_pdv : number= 0;
  total_value : number = 0;

  constructor(
    public dialog:MatDialog,
  ) { }

  ngOnInit(): void {
    this.updateTotalValues();
  }

  openPaymentDetails(payment:Payment){
    let dialogData : any ={
      paymentType:payment.paymentType,
      isReadonly:true,
      payment:payment
    }
    const dialogRef = this.dialog.open(PaymentRecordDialogComponent,{
      data: dialogData
    });
  }
  

  updateTotalValues(){
  }

  selectPayment(payment:Payment){
    if(this.enableSelectingInvoice){
      if(this.selectedPayment == payment)
        this.selectedPayment = undefined;
      else
        this.selectedPayment = payment;
      
      this.slectedPayment.emit(payment);
    }
  }

  isPaymentSelected(payment:Payment){
    return this.selectedPayment?.paymentId === payment.paymentId;
  }

  deletePayment(payment:Payment){
    this.deletedPayment.emit(payment);
  }
}
