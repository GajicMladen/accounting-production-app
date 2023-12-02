import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { PaymentItem } from 'src/app/shared/model/payment/paymentItem';

@Component({
  selector: 'app-payment-item-table',
  templateUrl: './payment-item-table.component.html',
  styleUrls: ['./payment-item-table.component.css']
})
export class PaymentItemTableComponent implements OnInit {

  @Input() displayedColumns: string[] = [ 'name', 'value','options'];
  @Input() dataSource : PaymentItem[] = [];

  @Output() deletedPaymentItem : EventEmitter<any> = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  deletePaymentItem(paymentItem : PaymentItem){
    this.deletedPaymentItem.emit(paymentItem);
  }
}
