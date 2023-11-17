import { Component, Input, OnInit } from '@angular/core';
import { Expenses } from 'src/app/shared/model/expenses';

@Component({
  selector: 'app-bussines-table-paid',
  templateUrl: './bussines-table-paid.component.html',
  styleUrls: ['./bussines-table-paid.component.css']
})
export class BussinesTablePaidComponent implements OnInit {

  @Input() displayedColumns: string[] = [ 'customer', 'invoice_id','date','total_price' ];
  @Input() dataSource : Expenses[] = [];
  constructor() { }

  ngOnInit(): void {
  }

}
