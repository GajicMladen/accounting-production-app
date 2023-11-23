import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ProductToSell } from '../../model/productToSell';
import { RawToSell } from '../../model/rawToSell';
import { Raw } from '../../model/raw';
import { InvoiceItem } from '../../model/invoices/invoiceItem';



@Component({
  selector: 'app-sell-raw-table',
  templateUrl: './sell-raw-table.component.html',
  styleUrls: ['./sell-raw-table.component.css']
})
export class SellRawTableComponent implements OnInit {
  displayedColumns: string[] = [ 
    "name",
    "count",
    "unit",
    "price_single",
    "pdv",
    "value_out_pdv",
    "value_pdv",
    "value_total",
    "delete"
  ];
  
  @Input() rawsToSell : RawToSell[] | InvoiceItem[] = [];
  @Input() isReadonly: boolean = false;

  @Output() deletedRow: EventEmitter<any> = new EventEmitter();

  selectedRow : ProductToSell | undefined;
  constructor(
  ) { }

  ngOnInit(): void {
  }
  
  isRowSelected(row:ProductToSell):boolean{
    if(this.selectedRow != undefined){
      return this.selectedRow!.productId === row.productId;
    }
    return false; 
  }
  clickRow(row:ProductToSell):ProductToSell | undefined{
    
    if(this.selectedRow != undefined && this.selectedRow.productId === row.productId)
      return undefined;
    
    return row; 
  }

  deleteProduct(product:ProductToSell){
    this.deletedRow.emit(product);
  }

  addProduct(newProduct:ProductToSell){
  }

  editProduct(productToEdit: ProductToSell){
    
  }
}
