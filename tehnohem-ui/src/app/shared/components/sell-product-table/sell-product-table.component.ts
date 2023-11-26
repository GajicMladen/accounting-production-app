import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ProductToSell } from '../../model/productToSell';
import { Product } from '../../model/product';
import { InvoiceItem } from '../../model/invoices/invoiceItem';
;

@Component({
  selector: 'app-sell-product-table',
  templateUrl: './sell-product-table.component.html',
  styleUrls: ['./sell-product-table.component.css']
})
export class SellProductTableComponent implements OnInit {
  displayedColumns: string[] = [ 
    "name",
    "amount",
    "price_single",
    "rabat",
    "discount",
    "value_out_pdv",
    "pdv",
    "value_pdv",
    "value_total",
    "price_single_no_pdv",
    "price_single_pdv",
    "delete"
  ];
  @Input() productsToSell : ProductToSell[] = [];
  
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

}
